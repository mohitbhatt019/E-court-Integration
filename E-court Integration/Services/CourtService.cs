using E_court_Integration.Models;

namespace E_court_Integration.Services
{
    public class CourtService : ICourtService
    {

        private readonly HttpClient _httpClient;

        public CourtService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://apis.akshit.me/");
        }
        public async Task<string> DistrictCourtGetCase(DistrictCourtGetCase obj)
        {
            // Create an HTTP request to the district court API for case information
            var request = new HttpRequestMessage(HttpMethod.Post, "eciapi/district-court/case");

            // Create the request content with the provided object data
            var content = new StringContent($"{{\n    \"cnr\": \"{obj.CNR}\",\n    \"withBusinessData\": {obj.WithBusinessData},\n    \"withJudgement\": {obj.WithJudgement}\n}}", null, "text/plain");
            request.Content = content;

            // Send the HTTP request and await the response
            var response = await _httpClient.SendAsync(request);

            // Read the response content as a string
            var convert = await response.Content.ReadAsStringAsync();

            // Return the response content as a string
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHighCourtAdvocateName(HighCourtAdvocateNameModel obj)
        {
            // Create an HTTP request to the high court API for advocate name
            var request = new HttpRequestMessage(HttpMethod.Post, "eciapi/high-court/search/advocate-name");

            // Create the request content with the provided object data
            var content = new StringContent($"{{\n    \"name\": \"{obj.Name}\",\n    \"stage\": \"{obj.Stage}\",\n    \"benchId\": \"{obj.ComplexId}\"\n}}", null, "text/plain");
            request.Content = content;

            // Send the HTTP request and await the response
            var response = await _httpClient.SendAsync(request);

            // Read the response content as a string and return it
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHighCourtCase(HighCourtGetCaseModel obj)
        {
            // Create an HTTP request to the high court API for case search
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7205/api/Court/HighCourt-CaseSearch");

            // Create the request content with the provided object data
            var content = new StringContent($"{{\n    \"cnr\": \"{obj.CNR}\",\n    \"withJudgement\": {obj.WithJudgement}\n}}", null, "text/plain");
            request.Content = content;

            // Send the HTTP request and await the response
            var response = await client.SendAsync(request);

            // Read the response content as a string and return it
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHighCourtPartyName(HighCourtPartyNameModel obj)
        {
            // Create an HTTP request to the high court API for party name
            var request = new HttpRequestMessage(HttpMethod.Post, "eciapi/high-court/search/party");

            // Create the request content with the provided object data
            var content = new StringContent($"{{\n    \"name\": \"{obj.Name}\",\n    \"year\": \"{obj.Year}\",\n    \"stage\": \"{obj.Stage}\",\n    \"benchId\": \"{obj.BenchId}\"\n}}", null, "text/plain");
            request.Content = content;

            // Send the HTTP request and await the response
            var response = await _httpClient.SendAsync(request);

            // Read the response content as a string and return it
            return await response.Content.ReadAsStringAsync();
        }

    }
}
