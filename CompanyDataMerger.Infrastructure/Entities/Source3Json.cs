using System;
using System.Text.Json.Serialization;

namespace CompanyDataMerger.Infrastructure.Entities
{
    public class Source3Json
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("NAME")]
        public string? Name { get; set; }

        [JsonPropertyName("Industry")]
        public string? Industry { get; set; }

        [JsonPropertyName("Size")]
        public string? Size { get; set; }

        [JsonPropertyName("PROFILES")]
        public string? Profiles { get; set; }
    }
}
