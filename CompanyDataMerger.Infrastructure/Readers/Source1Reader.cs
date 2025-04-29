using CompanyDataMerger.Domain.Interfaces;
using CompanyDataMerger.Domain.Entities;
using CompanyDataMerger.Infrastructure.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CompanyDataMerger.Infrastructure.Readers
{
    public class Source1Reader : ICompanyReader
    {
        public string filePath { get; } = "Source1.csv";
        public int sourcePriority { get; } = 10;

        public async Task<List<Company>> ReadCompaniesAsync()
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            var records = csv.GetRecordsAsync<Source1>();
            var companies = new List<Company>();

           await foreach (var record in records)
            {
                var company = new Company
                {
                    Domain = record.Domain ?? string.Empty,
                    Name = record.Name,
                    Industry = record.Industry,
                    CompanySize = record.EmployeeCountRange,
                    Country = record.Country,
                    Location = record.City,
                    Description = record.Description,
                    LogoUrl = record.Logo,
                    LinkedInUrl = record.PublicProfileUrl,
                    SourcePriority = sourcePriority
                };

                companies.Add(company);
            }

            return companies;

        }
    }
}
