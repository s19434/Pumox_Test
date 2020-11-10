
using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox_Test.Services
{
    public interface IEmployeeDbService
    {
        List<Employee> GroupEmployees(List<Employee> employees);
        List<Company> GroupCompanies(List<Employee> employees);

        IQueryable<Employee> Employees { get; }

        List<Employee> FindByKeyword(string keyword);
        List<Employee> FindByDate(DateTime from, DateTime to);
        List<Employee> FindByJob(List<string> job);

    }
}
