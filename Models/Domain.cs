using System.Text.Json.Serialization;

namespace Temp_mail_API.Models
{
    public class Domain
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("domain")]
        public string? Name { get; set; }
    }
}
