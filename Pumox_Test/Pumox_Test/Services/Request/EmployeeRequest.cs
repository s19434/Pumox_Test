using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox_Test.Services.Request
{
    public class EmployeeRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
    public static class EmployeRequestExtensions
    {
        public static Employee ToModel(this EmployeeRequest request)
        {
            return new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                JobTitle = (int)Enum.Parse(typeof(Job_Titles), request.JobTitle, true)
            };
        }
        public static ICollection<Employee> ToModelList(this IEnumerable<EmployeeRequest> er)
        {
            List<Employee> employee = new List<Employee>();
            if (employee != null)
                employee.AddRange(er.Select(e => e.ToModel()));
            return employee;
        }
    }
}
