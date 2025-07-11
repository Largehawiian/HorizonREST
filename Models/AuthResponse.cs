using System.Text.Json;

namespace HorizonREST.Models
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string HorizonServer { get; set; }
        public AuthResponse() { }

        public AuthResponse(string server, string response)
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            if (root.TryGetProperty("access_token", out var accessTokenProp))
                access_token = accessTokenProp.GetString();
            else
                ConnectionState.Log("access_token not found in AuthResponse JSON.");

            if (root.TryGetProperty("refresh_token", out var refreshTokenProp))
                refresh_token = refreshTokenProp.GetString();
            else
                ConnectionState.Log("refresh_token not found in AuthResponse JSON.");

            HorizonServer = server;
        }
        public static void RefreshToken(string response)
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;
            if (root.TryGetProperty("access_token", out var accessTokenProp))
            AuthContainer.Instance.LastAuthResponse.access_token = accessTokenProp.GetString();
        }

        public static AuthResponse FromJson(string server, string json)
        {
            return new AuthResponse(server, json);
        }
    }
}
