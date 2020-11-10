using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pumox_Test.Models;
using Pumox_Test.Services;
using Pumox_Test.Services.Request;
using Pumox_Test.Services.Response;

namespace Pumox_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyDbService _companyContext;
        private readonly IEmployeeDbService _employeeContext;

        public CompanyController(ICompanyDbService companyContext, IEmployeeDbService employeeContext)
        {
            _companyContext = companyContext;
            _employeeContext = employeeContext;
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(CompanyCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Error, 'Name' is require, ");
            }

            if (request.EstablishmentYear == 0)
            {
                return BadRequest("Error, 'EstablishmentYear' is require, ");
            }

            long id = _companyContext.Save(request.ToModel());
            return Ok(id);
        }

        [Authorize]
        [HttpPut]
        [Route("[action]/{id}")]
        public IActionResult Update(CompanyCreateRequest request, int id)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return BadRequest("Error, 'Name' is require, ");
            }

            if (request.EstablishmentYear == 0)
            {
                return BadRequest("Error, 'EstablishmentYear' is require, ");
            }

            _companyContext.Update(request.ToModel(id));
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Search(CompanySearchRequest request)
        {
            List<Company> result = new List<Company>();
            List<Employee> employees = new List<Employee>();
            List<Company> byKeywordFromCompany = new List<Company>();
            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                byKeywordFromCompany = _companyContext.FindByKeyword(request.Keyword);
                var byKeywordFromEmployee = _employeeContext.FindByKeyword(request.Keyword);
                employees.AddRange(byKeywordFromEmployee);
            }
            if (request.EmployeeDateOfBirthFrom != null && request.EmployeeDateOfBirthTo != null)
            {
                var byDate = _employeeContext.FindByDate(request.EmployeeDateOfBirthFrom, request.EmployeeDateOfBirthTo);
                employees.AddRange(byDate);
            }
            if (request.EmployeeJobTitles != null && request.EmployeeJobTitles.Count != 0)
            {
                var byJob = _employeeContext.FindByJob(request.EmployeeJobTitles);
                employees.AddRange(byJob);
            }
            if (employees != null && employees.Count > 0)
            {
                var group = _employeeContext.GroupEmployees(employees);
                result = _employeeContext.GroupCompanies(group);
                result.AddRange(byKeywordFromCompany);
            }
            return Ok(result.ToResponseList());
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Error, 'Id' is require");
            }

            _companyContext.Delete(id);
            return Ok();
        }
    }
}
