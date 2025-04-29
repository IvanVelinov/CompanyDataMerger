using CompanyDataMerger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataMerger.Application.Interfaces
{
    public interface ICompanyDataProvider
    {
        Task<List<Company>> LoadAllCompaniesAsync();
    }
}
