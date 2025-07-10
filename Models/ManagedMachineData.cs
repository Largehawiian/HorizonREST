using System.Text.Json;
using System.Text.Json.Serialization;

namespace HorizonREST.Models
{
    public class ManagedMachineData
    {
        [JsonPropertyName("create_time")]
        public long? CreateTime { get; set; }

        [JsonIgnore]
        public DateTime? CreateDateTime
        {
            get
            {
                if (CreateTime.HasValue)
                {
                    // Convert from Unix milliseconds to DateTime (UTC)
                    return DateTimeOffset.FromUnixTimeMilliseconds(CreateTime.Value).UtcDateTime;
                }
                return null;
            }
        }

        public static List<ManagedMachineData> FromJson(string response)
        {
            return JsonSerializer.Deserialize<List<ManagedMachineData>>(response);
        }
    }
}