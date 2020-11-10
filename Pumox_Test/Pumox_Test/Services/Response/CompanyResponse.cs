using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Response
{
    public class CompanyResponse
    {

        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeResponse> Employees { get; set; }
    }
    public static class CompanyResponseExtensions
    {
        public static CompanyResponse ToResponse(this Company company)
        {
            if (company != null)
                return new CompanyResponse()
                {
                    Name = company.Name,
                    EstablishmentYear = company.EstablishmentYear,
                    Employees = company.Employees.ToResponseList()
                };
            else
                return null;
        }
        public static List<CompanyResponse> ToResponseList(this IEnumerable<Company> companies)
        {
            List<CompanyResponse> responses = new List<CompanyResponse>();
            if (companies != null)
            {
                responses.AddRange(companies.Select(p => p.ToResponse()));
            }

            return responses;
        }
    }
}
