using CompanyDataMerger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Application.Helpers
{
    public static class HelperMethods
    {

        public static string MapCompanySize(string size)
        {
            if (size.Contains("myself only") || size.Contains("1-10"))            
               return "1-10";            
            else if (size.Contains("11-50"))
                return "11-50";
            
            else if (size.Contains("51-200"))            
                return "51-200";            
            else if (size.Contains("201-500"))
                return "201-500";            
            else if (size.Contains("501-1000"))
                return "501-1000";
            else if (size.Contains("1001-5000"))
                return "1001-5000";
            else if (size.Contains("5001-10000") || size.Contains("5001-10,000"))
                return "5001-10000";
            else if (size.Contains("10001") || size.Contains("10,001"))
                return "10001+";
            else
                return "Unknown";
            
        }
        public static bool IsValidCompanySizeFormat(string size)
        {
            // Accept only these valid patterns
            var validPatterns = new[]
            {
                "myself only",
                "1-10",
                "11-50",
                "51-200",
                "201-500",
                "501-1000",
                "1001-5000",
                "5001-10000",
                "5001-10,000",
                "10001+",
                "10,001+",
                "1-10 employees",
                "11-50 employees",
                "51-200 employees",
                "201-500 employees",
                "501-1000 employees",
                "1001-5000 employees",
                "5001-10000 employees",
                "5001-10,000 employees",
                "10001+ employees",
                "10,001+ employees"
            };

            return validPatterns.Any(pattern => size.Contains(pattern));
        }
        public static string FixThePrefixCompanySize(string rawSize)
        {
            // Remove "the" prefix
            var numericPart = rawSize.Substring(3); // skip "the"

            if (int.TryParse(numericPart, out int number))
            {
                // Now map based on the number
                if (number <= 10)
                    return "1-10";
                if (number <= 50)
                    return "11-50";
                if (number <= 200)
                    return "51-200";
                if (number <= 500)
                    return "201-500";
                if (number <= 1000)
                    return "501-1000";
                if (number <= 5000)
                    return "1001-5000";
                if (number <= 10000)
                    return "5001-10000";
                if (number > 10000)
                    return "10001+";
            }

            // If parsing fails, fallback
            return "Unknown";
        }
        public static string MapIndustry(string normalized)
        {
            if (normalized.Contains("information technology") || normalized.Contains("computer software") || normalized.Contains("internet") || normalized.Contains("program development") || normalized.Contains("online media") || normalized.Contains("computer hardware") || normalized.Contains("computer games"))
                return "Information Technology";

            else if (normalized.Contains("biotechnology") || normalized.Contains("mental health") || normalized.Contains("health care") || normalized.Contains("pharmaceuticals") || normalized.Contains("medical device") || normalized.Contains("medical practice"))
                return "Healthcare";

            else if (normalized.Contains("banking") || normalized.Contains("investment banking") || normalized.Contains("financial service") || normalized.Contains("investment management") || normalized.Contains("insurance") || normalized.Contains("accounting"))
                return "Financial Services";

            else if (normalized.Contains("consulting") || normalized.Contains("professional training") || normalized.Contains("coaching"))
                return "Consulting";

            else if (normalized.Contains("education management") || normalized.Contains("higher education") || normalized.Contains("e learning") || normalized.Contains("primary/secondary education"))
                return "Education";

            else if (normalized.Contains("retail") || normalized.Contains("consumer goods") || normalized.Contains("supermarket") || normalized.Contains("apparel") || normalized.Contains("luxury goods"))
                return "Retail";

            else if (normalized.Contains("electrical") || normalized.Contains("mechanical") || normalized.Contains("industrial automation") || normalized.Contains("machinery") || normalized.Contains("manufacture"))
                return "Manufacturing";

            else if (normalized.Contains("construction") || normalized.Contains("building materials") || normalized.Contains("civil engineering"))
                return "Construction";

            else if (normalized.Contains("oil") || normalized.Contains("energy") || normalized.Contains("renewables") || normalized.Contains("mining"))
                return "Energy";

            else if (normalized.Contains("transportation") || normalized.Contains("railroad") || normalized.Contains("airlines") || normalized.Contains("logistics") || normalized.Contains("shipping"))
                return "Transportation";

            else if (normalized.Contains("media production") || normalized.Contains("entertainment") || normalized.Contains("publishing") || normalized.Contains("broadcast") || normalized.Contains("performing arts") || normalized.Contains("events services"))
                return "Media and Entertainment";

            else if (normalized.Contains("food production") || normalized.Contains("food") || normalized.Contains("beverage") || normalized.Contains("restaurant"))
                return "Food and Beverage";

            else if (normalized.Contains("real estate"))
                return "Real Estate";

            else if (normalized.Contains("law practice") || normalized.Contains("legal services"))
                return "Law and Legal";

            else if (normalized.Contains("marketing") || normalized.Contains("public relations") || normalized.Contains("graphic design"))
                return "Marketing";

            else if (normalized.Contains("environmental services"))
                return "Environmental Services";

            else if (normalized.Contains("government administration") || normalized.Contains("civic & social organization"))
                return "Public Sector";

            else
                return "Other";
        }
        public static string MapCountry(string normalized)
        {
            switch (normalized)
            {
                case "united states":
                case "usa":
                case "us":
                    return "United States";

                case "united kingdom":
                case "uk":
                    return "United Kingdom";

                case "brasil":
                    return "Brazil";

                case "espanha":
                    return "Spain";

                case "deutschland":
                    return "Germany";

                case "maroc":
                    return "Morocco";

                case "emirados árabes unidos":
                case "united arab emirates":
                    return "United Arab Emirates";

                case "corea":
                case "korea":
                case "south korea":
                    return "South Korea";

                case "colômbia":
                    return "Colombia";

                case "suisse":
                    return "Switzerland";

                case "reino unido":
                    return "United Kingdom";

                case "portugal":
                    return "Portugal";

                case "france":
                    return "France";

                case "germany":
                    return "Germany";

                case "brazil":
                    return "Brazil";

                case "spain":
                    return "Spain";

                case "italy":
                    return "Italy";

                case "india":
                    return "India";

                case "netherlands":
                    return "Netherlands";

                case "australia":
                    return "Australia";

                case "poland":
                    return "Poland";

                case "sweden":
                    return "Sweden";

                case "canada":
                    return "Canada";

                case "argentina":
                    return "Argentina";

                case "romania":
                    return "Romania";

                case "turkey":
                    return "Turkey";

                case "switzerland":
                    return "Switzerland";

                case "belgium":
                    return "Belgium";

                case "japan":
                    return "Japan";

                case "china":
                    return "China";

                case "hong kong":
                    return "Hong Kong";

                case "ireland":
                    return "Ireland";

                case "lebanon":
                    return "Lebanon";

                case "philippines":
                    return "Philippines";

                case "indonesia":
                    return "Indonesia";

                case "pakistan":
                    return "Pakistan";

                case "norway":
                    return "Norway";

                case "ethiopia":
                    return "Ethiopia";

                case "slovenia":
                    return "Slovenia";

                case "egypt":
                    return "Egypt";

                case "latvia":
                    return "Latvia";

                case "macedonia":
                    return "North Macedonia";

                case "ghana":
                    return "Ghana";

                case "morocco":
                    return "Morocco";

                case "hungary":
                    return "Hungary";

                case "taiwan":
                    return "Taiwan";

                case "central african republic":
                    return "Central African Republic";

                case "senegal":
                    return "Senegal";

                case "dominican republic":
                    return "Dominican Republic";

                case "new zealand":
                    return "New Zealand";

                case "greece":
                    return "Greece";

                case "croatia":
                    return "Croatia";

                case "czech republic":
                    return "Czech Republic";

                case "kazakhstan":
                    return "Kazakhstan";

                case "chile":
                    return "Chile";

                case "iran":
                    return "Iran";

                case "peru":
                    return "Peru";

                case "colombia":
                    return "Colombia";

                case "singapore":
                    return "Singapore";

                case "fiji":
                    return "Fiji";

                case "unknown":
                case "other":
                    return "Unknown";

                default:
                    return "Unknown";
            }
        }


    }
}
