using System;
using System.Net.Http;

namespace Vecc.LogCorrelation.Example.Source.Services
{
    public interface IRequestMessageFactory
    {
        HttpRequestMessage GetHttpRequestMessage();
        HttpRequestMessage GetHttpRequestMessage(HttpMethod httpMethod, string requestUri);
        HttpRequestMessage GetHttpRequestMessage(HttpMethod httpMethod, Uri requestUri);
    }
}
