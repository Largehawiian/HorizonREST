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

            access_token = root.GetProperty("access_token").GetString();
            refresh_token = root.GetProperty("refresh_token").GetString();
            HorizonServer = server;
        }
        public static AuthResponse FromJson(string server, string json)
        {
            return new AuthResponse(server, json);
        }
    }
}
