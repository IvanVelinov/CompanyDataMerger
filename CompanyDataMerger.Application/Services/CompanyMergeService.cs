using CompanyDataMerger.Application.Interfaces;
using CompanyDataMerger.Domain.Entities;
using CompanyDataMerger.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace CompanyDataMerger.Application.Services
{
    public class CompanyMergeService : ICompanyMergeService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyDataProvider _companyDataProvider;
        private readonly ILogger<CompanyMergeService> _logger;

        public CompanyMergeService(ICompanyRepository companyRepository, ICompanyDataProvider companyDataProvider, ILogger<CompanyMergeService> logger)
        {
            _companyRepository = companyRepository;
            _companyDataProvider = companyDataProvider;
            _logger = logger;
        }
        public async Task MergeAndSaveCompaniesAsync()
        {
            _logger.LogInformation("Starting company merge process...");

            var allCompanies = await _companyDataProvider.LoadAllCompaniesAsync();

            _logger.LogInformation($"Total companies loaded before merging: {allCompanies.Count}");

            var mergedCompanies = new Dictionary<string, Company>();

            foreach (var company in allCompanies)
            {
                if (string.IsNullOrWhiteSpace(company.Domain))
                {
                    _logger.LogWarning("Company skipped due to missing domain.");
                    continue;
                }

                var domainKey = company.Domain.ToLower();

                if (mergedCompanies.TryGetValue(domainKey, out var existingCompany))
                {
                    if (company.SourcePriority < existingCompany.SourcePriority)
                    {
                        existingCompany.SourcePriority = company.SourcePriority;
                    }

                    MergeFields(existingCompany, company);
                }
                else
                {
                    mergedCompanies[domainKey] = company;
                }
            }

            _logger.LogInformation($"Total unique merged companies before standardization: {mergedCompanies.Count}");

            // Standardize all merged companies
            foreach (var company in mergedCompanies.Values)
            {
                CompanyStandardizer.Standardize(company);
            }

            _logger.LogInformation("Data standardization completed.");

            await _companyRepository.AddRangeAsync(mergedCompanies.Values.ToList());
            await _companyRepository.SaveChangesAsync();

            _logger.LogInformation("Company merge process completed successfully.");
        }

        private void MergeFields(Company target, Company source)
        {
            if (string.IsNullOrWhiteSpace(target.Name)) target.Name = source.Name;
            if (string.IsNullOrWhiteSpace(target.Industry)) target.Industry = source.Industry;
            if (string.IsNullOrWhiteSpace(target.CompanySize)) target.CompanySize = source.CompanySize;
            if (string.IsNullOrWhiteSpace(target.Country)) target.Country = source.Country;
            if (string.IsNullOrWhiteSpace(target.Description)) target.Description = source.Description;
            if (string.IsNullOrWhiteSpace(target.LogoUrl)) target.LogoUrl = source.LogoUrl;
            if (string.IsNullOrWhiteSpace(target.LinkedInUrl)) target.LinkedInUrl = source.LinkedInUrl;
        }
    }
}
