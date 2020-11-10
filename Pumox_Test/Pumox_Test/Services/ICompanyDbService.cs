
using Pumox_Test.Models;
using System.Collections.Generic;
using System.Linq;


namespace Pumox_Test.Services
{
    public interface ICompanyDbService
    {
        long Save(Company company);
        void Update(Company company);
        void Delete(int id);

        List<Company> FindByKeyword(string keyword);
        IQueryable<Company> Companies { get; }
    }
}
