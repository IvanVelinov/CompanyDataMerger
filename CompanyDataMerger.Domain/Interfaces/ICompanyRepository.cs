using CompanyDataMerger.Domain.Entities;

namespace CompanyDataMerger.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddRangeAsync(List<Company> companies);    
        Task SaveChangesAsync();
    }
}
