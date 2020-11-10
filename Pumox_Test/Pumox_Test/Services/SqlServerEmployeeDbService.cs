using Microsoft.EntityFrameworkCore;
using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox_Test.Services
{
    public class SqlServerEmployeeDbService : IEmployeeDbService
    {
        private readonly SqlDbContext _context;

        public SqlServerEmployeeDbService(SqlDbContext context)
        {
            _context = context;
        }

        [Obsolete]
        public IQueryable<Employee> Employees => _context.Query<Employee>();

        [Obsolete]
        public List<Employee> FindByDate(DateTime from, DateTime to)
        {
            return Employees.Where(p => p.DateOfBirth.Date >= from && p.DateOfBirth.Date <= to)
                            .Include(p => p.Company)
                            .ToList();
        }

        [Obsolete]
        public List<Employee> FindByJob(List<string> job)
        {
            return Employees.Include(p => p.Company)
                .ToList()
                .Where(e => job.Any(p => p == Enum.GetName(typeof(Job_Titles), e.JobTitle)))
                .ToList();
        }

        [Obsolete]
        public List<Employee> FindByKeyword(string keyword)
        {
            return Employees.Where(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword))
                            .Include(x => x.Company)
                            .ToList();
        }

        public List<Company> GroupCompanies(List<Employee> employees)
        {
            var result = new List<Company>();
            if (employees != null && employees.Count != 0)
            {
                var group = employees.GroupBy(p =>
                {
                    return p.Company;
                }).Select(p => new Company()
                {
                    IdCompany = p.Key.IdCompany,
                    EstablishmentYear = p.Key.EstablishmentYear,
                    Name = p.Key.Name,
                    Employees = p.Key.Employees
                });
                result.AddRange(group);
            }
            return result;
        }

        public List<Employee> GroupEmployees(List<Employee> employees)
        {
            var result = new List<Employee>();
            if (employees != null && employees.Count != 0)
            {
                var group = employees.GroupBy(p =>
                {
                    return p.IdEmployee;
                }).Select(p => new Employee()
                {
                    IdEmployee = p.Key,
                    Company = p.Select(e => e.Company).FirstOrDefault(),
                    FirstName = p.Select(e => e.FirstName).FirstOrDefault(),
                    LastName = p.Select(e => e.LastName).FirstOrDefault(),
                    DateOfBirth = p.Select(e => e.DateOfBirth).FirstOrDefault(),
                    JobTitle = p.Select(e => e.JobTitle).FirstOrDefault(),
                });
                result.AddRange(group);
            }
            return result;
        }
    }
} 
