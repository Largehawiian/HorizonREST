using System.Text.Json;
using System.Text.Json.Serialization;


namespace HorizonREST.Models
{
    public class PoolData
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("display_name")]
        public required string Display_Name { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        public PoolData() { }

        public PoolData(string response)
        {
            var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;

            Name = root.GetProperty(nameof(Name)).GetString();
            Display_Name = root.GetProperty(nameof(Display_Name)).GetString();
            Enabled = root.GetProperty("enabled").GetBoolean();
        }

        public static List<PoolData> FromJson(string response)
        {
            return JsonSerializer.Deserialize<List<PoolData>>(response);

        }
    }
}
