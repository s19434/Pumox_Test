using Microsoft.EntityFrameworkCore;
using Pumox_Test.Exceptions;
using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox_Test.Services
{
    public class SqlServerCompanyDbService : ICompanyDbService
    {
        private readonly SqlDbContext _context;

        public SqlServerCompanyDbService(SqlDbContext context)
        {
            _context = context;
        }

        [Obsolete]
        public IQueryable<Company> Companies
        {
            get
            {
                return _context.Query<Company>();
            }
        }

        [Obsolete]
        public void Delete(int id)
        {
            try
            {
                var model = Companies.Where(p =>
                       p.IdCompany == id)
                        .FirstOrDefault();

                if (model != null)
                {
                    _context.Companies.Remove(model);
                    _context.SaveChanges();
                }
            }
            catch (CompanyDeleteException)
            {
                throw new CompanySaveException("Error, can not delete company");
            }
        }

        [Obsolete]
        public List<Company> FindByKeyword(string keyword)
        {
            return Companies.Where(p => p.Name.Contains(keyword))
                                   .Include(p => p.Employees)
                                   .ToList();
        }

        public long Save(Company company)
        {
            try
            {
                Company comp = new Company();

                comp.IdCompany = company.IdCompany;
                comp.Name = company.Name;
                comp.EstablishmentYear = company.EstablishmentYear;
                comp.Employees = company.Employees;

                _context.Companies.Add(comp);
                _context.SaveChanges();
                return comp.IdCompany;
            }
            catch (CompanySaveException)
            {
                throw new CompanySaveException("Error, can not create company");
            }
        }

        [Obsolete]
        public void Update(Company company)
        {
            try
            {
                var model = Companies.Where(x =>
                x.IdCompany == company.IdCompany)
                    .FirstOrDefault();

                _context.Entry(model)
                    .CurrentValues
                    .SetValues(company);

                _context.SaveChanges();
            }
            catch (CopmanyUpdateException)
            {
                throw new CompanySaveException("Error, can not update company");
            }
        }
    }
}


