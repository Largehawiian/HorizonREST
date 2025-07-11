using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HorizonREST.Models
{
    public class MachineData
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("id")]
        public required string ID { get; set; }

        [JsonPropertyName("state")]
        public required string State { get; set; }

        [Browsable(false)]
        [JsonPropertyName("managed_machine_data")]
        public required ManagedMachineData ManagedMachineData { get; set; }

        [JsonIgnore]
        public DateTime? CreateDateTime => ManagedMachineData?.CreateDateTime;

        public MachineData() { }

        public static List<MachineData> FromJson(string response)
        {
            return JsonSerializer.Deserialize<List<MachineData>>(response);
        }
    }
}
