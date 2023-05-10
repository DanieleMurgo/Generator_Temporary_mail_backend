using System.Text.Json.Serialization;

namespace Temp_Mail_API.Models
{
    public class MailAccount
    {

        //classe da utilizzare per l'esportazione e importazione di json tra frontend e backend
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("domain")]
        public string? Domain { get; set; }


        public MailAccount (string username, string password, string domain)
        {
            Username = username;
            Password = password;
            Domain = domain;
            Address = $"{Username}@{Domain}";
        }


    }
}
