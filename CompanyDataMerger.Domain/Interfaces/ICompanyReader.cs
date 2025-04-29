using CompanyDataMerger.Domain.Entities;

namespace CompanyDataMerger.Domain.Interfaces
{
    public interface ICompanyReader
    {
        string filePath { get; }
        int sourcePriority { get; }
        Task<List<Company>> ReadCompaniesAsync();
    }
}
