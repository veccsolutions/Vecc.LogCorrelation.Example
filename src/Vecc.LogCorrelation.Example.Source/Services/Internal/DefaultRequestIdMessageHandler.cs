using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vecc.LogCorrelation.Example.Source.Services.Internal
{
    public class DefaultRequestIdMessageHandler : DelegatingHandler
    {
        private readonly ISessionIdAccessor _sessionIdAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultRequestIdMessageHandler(ISessionIdAccessor sessionIdAccessor, IHttpContextAccessor httpContextAccessor)
        {
            this._sessionIdAccessor = sessionIdAccessor;
            this._httpContextAccessor = httpContextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Request-Id", _httpContextAccessor.HttpContext.TraceIdentifier);
            request.Headers.Add("X-SessionId", _sessionIdAccessor.GetSessionId());

            return base.SendAsync(request, cancellationToken);
        }
    }
}
