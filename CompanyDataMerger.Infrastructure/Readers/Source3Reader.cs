using CompanyDataMerger.Domain.Interfaces;
using CompanyDataMerger.Domain.Entities;
using CompanyDataMerger.Infrastructure.Entities;
using System.Text.Json;


namespace CompanyDataMerger.Infrastructure.Readers
{
    public class Source3Reader : ICompanyReader
    {
        public string filePath { get; } = "Source3.json";
        public int sourcePriority { get; } = 30;
        public async Task<List<Company>> ReadCompaniesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(filePath);

            var root = JsonSerializer.Deserialize<Source3Root>(jsonData);

            var companies = new List<Company>();

            if (root?.Rows != null)
            {
                foreach (var row in root.Rows)
                {
                    var company = new Company
                    {
                        Domain = row.Domain ?? string.Empty,
                        Name = row.Name,
                        Industry = row.Industry,
                        CompanySize = row.Size,
                        LinkedInUrl = row.Profiles,
                        SourcePriority = sourcePriority
                    };

                    companies.Add(company);
                }
            }

            return companies;
        }
    }
}
