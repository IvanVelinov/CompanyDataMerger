using CompanyDataMerger.Infrastructure.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanyDataMerger.Infrastructure.Entities
{
    public class Source2Root
    {
        [JsonPropertyName("table")]
        public string? Table { get; set; }

        [JsonPropertyName("rows")]
        public List<Source2Json>? Rows { get; set; }
    }
}
