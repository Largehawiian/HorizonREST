using HorizonREST.Models;
using System.Management.Automation;
using System.Text;
using System.Text.Json;

namespace HorizonREST.Classes
{
    public class HorizonREST
    {
        public static class ApiClient
        {
            private static readonly HttpClient httpClient = new();

            public static async Task<AuthResponse> ConnectHorizon(string server, PSCredential Credentials)
            {
                var creds = new
                {
                    domain = Credentials.GetNetworkCredential().Domain,
                    password = Credentials.GetNetworkCredential().Password,
                    username = Credentials.GetNetworkCredential().UserName
                };
                string auth = JsonSerializer.Serialize(creds);
                UriBuilder uri = new("https", server)
                {
                    Path = Endpoints.Api["Login"]
                };
                var body = new StringContent(auth, Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(uri.Uri, body);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  AuthResponse.FromJson(server, responseBody);
            }
            public static async Task<List<MachineData>> GetMachines()
            {
                var auth = AuthContainer.Instance.LastAuthResponse;
                UriBuilder uri = new("https", AuthContainer.Instance.LastAuthResponse.HorizonServer)
                {
                    Path = Endpoints.Api["Machines"]
                };
                using var request = new HttpRequestMessage(HttpMethod.Get, uri.Uri);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", auth.access_token);
                using var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return MachineData.FromJson(responseBody);
            }
            public static async Task<List<PoolData>> GetPools()
            {
                var auth = AuthContainer.Instance.LastAuthResponse;
                UriBuilder uri = new UriBuilder("https", AuthContainer.Instance.LastAuthResponse.HorizonServer)
                {
                    Path = Endpoints.Api["Pools"]
                };
                using var request = new HttpRequestMessage(HttpMethod.Get, uri.Uri);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", auth.access_token);
                using var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return PoolData.FromJson(responseBody);
            }
        }
    }
}
