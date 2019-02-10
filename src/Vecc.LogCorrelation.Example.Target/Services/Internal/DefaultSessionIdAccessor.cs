using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Vecc.LogCorrelation.Example.Target.Services.Internal
{
    public class DefaultSessionIdAccessor : ISessionIdAccessor
    {
        private readonly ILogger<DefaultSessionIdAccessor> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DefaultSessionIdAccessor(ILogger<DefaultSessionIdAccessor> logger, IHttpContextAccessor httpContextAccessor)
        {
            this._logger = logger;
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetSessionId()
        {
            try
            {
                var context = this._httpContextAccessor.HttpContext;
                var result = context?.Items["X-SessionId"] as string;

                return result;
            }
            catch (Exception exception)
            {
                this._logger.LogWarning(exception, "Unable to get session id header");
            }

            return string.Empty;
        }
    }
}
