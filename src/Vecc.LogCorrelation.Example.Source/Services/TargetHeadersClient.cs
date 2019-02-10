using System.Net.Http;
using System.Threading.Tasks;

namespace Vecc.LogCorrelation.Example.Source.Services
{
    public class TargetHeadersClient
    {
        private readonly HttpClient _httpClient;

        public TargetHeadersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> DumpAsync()
        {
            var response = await _httpClient.GetAsync("Headers/Dump");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
