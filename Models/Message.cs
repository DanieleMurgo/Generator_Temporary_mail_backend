using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Temp_mail_API.Models
{
    public class Message
    {
        public string? Id { get; set; }

        public string? AccountId { get; set; }

        [JsonPropertyName("msgid")]
        public string? MessageId { get; set; }

        public UserInfo? From { get; set; }

        public UserInfo[]? To { get; set; }

        public string? Subject { get; set; }

        public string? Intro { get; set; }

        public bool Seen { get; set; }

        public bool IsDeleted { get; set; }

        public bool HasAttachments { get; set; }

        public int Size { get; set; }

        public string? DownloadUrl { get; set; }
    }
    public class UserInfo
    {
        public string? Address { get; set; }

        public string? Name { get; set; }
    }

}

