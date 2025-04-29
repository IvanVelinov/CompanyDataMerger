using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanyDataMerger.Infrastructure.Entities
{
    public class Source2Json
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("NAME")]
        public string? Name { get; set; }

        [JsonPropertyName("Industry")]
        public string? Industry { get; set; }

        [JsonPropertyName("Size")]
        public string? Size { get; set; }

        [JsonPropertyName("Headquarters_country_restored")]
        public string? HeadquartersCountryRestored { get; set; }

        [JsonPropertyName("Headquarters_country_parsed")]
        public string? HeadquartersCountryParsed { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Logo_url")]
        public string? LogoUrl { get; set; }

        [JsonPropertyName("Url")]
        public string? Url { get; set; }
    }
}
