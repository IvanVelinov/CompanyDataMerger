using CompanyDataMerger.Application.Interfaces;
using CompanyDataMerger.Domain.Entities;
using CompanyDataMerger.Infrastructure.Entities;
using System.Text.Json;

namespace CompanyDataMerger.Infrastructure.Readers
{
    public class Source2Reader : ICompanyReader
    {
        public string filePath { get; } = "Source2.json";
        public int sourcePriority { get; } = 20;
        public async Task<List<Company>> ReadCompaniesAsync()
        {
            var jsonData = await File.ReadAllTextAsync(filePath);

            var root = JsonSerializer.Deserialize<Source2Root>(jsonData);

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
                        Country = row.HeadquartersCountryRestored ?? row.HeadquartersCountryParsed,
                        Description = row.Description,
                        LogoUrl = row.LogoUrl,
                        LinkedInUrl = row.Url,
                        SourcePriority = sourcePriority
                    };

                    companies.Add(company);
                }
            }

            return companies;
        }
    }

  

    
}
