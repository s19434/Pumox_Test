using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox_Test.Services.Response
{
    public class EmployeeResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
    public static class EmployeResponseExtensions
    {
        public static EmployeeResponse ToResponse(this Employee employee)
        {
            return employee != null
                ? new EmployeeResponse()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    JobTitle = Enum.GetName(typeof(Job_Titles), employee.JobTitle)
                }
                : null;
        }
        public static List<EmployeeResponse> ToResponseList(this IEnumerable<Employee> employee)
        {
            List<EmployeeResponse> responses = new List<EmployeeResponse>();
            if (employee != null)
            {
                responses.AddRange(employee.Select(p => p.ToResponse()));
            }

            return responses;
        }
    }
}