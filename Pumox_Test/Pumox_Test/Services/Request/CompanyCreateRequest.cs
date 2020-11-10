using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Request
{
    public class CompanyCreateRequest
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeRequest> Employees { get; set; }
    }

    public static class CompanyRequestExtensions
    {
        public static Company ToModel(this CompanyCreateRequest request, int id = 0)
        {
            return request != null
                ? new Company()
                {
                    IdCompany = id == 0 ? 0 : id,
                    Name = request.Name,
                    EstablishmentYear = request.EstablishmentYear,
                    Employees = request.Employees.ToModelList()
                }
                : null;
        }
    }
}

