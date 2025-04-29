using CompanyDataMerger.Application.Interfaces;
using CompanyDataMerger.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Infrastructure.Data
{
    public class CompanyDataProvider : ICompanyDataProvider
    {
        private readonly IEnumerable<ICompanyReader> _companyReaders;
        private readonly ILogger<CompanyDataProvider> _logger;

        public CompanyDataProvider(IEnumerable<ICompanyReader> companyReaders, ILogger<CompanyDataProvider> logger)
        {
            _companyReaders = companyReaders;
            _logger = logger;
        }
        public async Task<List<Company>> LoadAllCompaniesAsync()
        {
            var allCompanies = new List<Company>();

            foreach (var reader in _companyReaders)
            {
                _logger.LogInformation($"Loading from {reader.filePath}...");
                var companies = await reader.ReadCompaniesAsync();
                allCompanies.AddRange(companies);
            }

            _logger.LogInformation($"Loaded total {allCompanies.Count} companies from all sources.");
            return allCompanies;
        }
    }
}
