using CompanyDataMerger.Application.Helpers;
using CompanyDataMerger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Application.Services
{
    public static class CompanyStandardizer
    {
        public static void Standardize(Company company)
        {
            StandardizeIndustry(company);
            StandardizeCompanySize(company);
            StandardizeCountry(company);
        }

        private static void StandardizeIndustry(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.Industry)) return;

            var raw = company.Industry.Trim();

            // In Source3 the Industry data is entered in Pascal case, it must be splitted for the checks bellow.
            string normalized = System.Text.RegularExpressions.Regex
                .Replace(raw, "([a-z])([A-Z])", "$1 $2")
                .Trim()
                .ToLowerInvariant();


            company.Industry = HelperMethods.MapIndustry(normalized);
        }

        private static void StandardizeCompanySize(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.CompanySize)) return;

            var size = company.CompanySize.Trim().ToLowerInvariant();

            //Standardization. The size in Source3 starts with The and the range is not splitted with -
            if (size.StartsWith("the"))
            {
                size = HelperMethods.FixThePrefixCompanySize(size);
            }

            //Standardization. There are dates for example in some of size column in Source1. Check if data is valid before inserting.
            if (!HelperMethods.IsValidCompanySizeFormat(size))
            {
                company.CompanySize = "Unknown";
                return;
            }

            company.CompanySize = HelperMethods.MapCompanySize(size);
        }

        private static void StandardizeCountry(Company company)
        {
            if (string.IsNullOrWhiteSpace(company.Country))
                return;

            var normalized = company.Country.Trim().ToLowerInvariant();

            company.Country = HelperMethods.MapCountry(normalized);
        }

    }
}
