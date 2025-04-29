using System.Text.Json.Serialization;


namespace CompanyDataMerger.Infrastructure.Entities
{
    public class Source3Root
    {
        [JsonPropertyName("rows")]
        public List<Source3Json>? Rows { get; set; }
    }
}
