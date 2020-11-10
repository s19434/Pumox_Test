using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Models
{
    public class Employee
    {
        public long IdEmployee { get; set; }
        public long IdCompany { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int JobTitle { get; set; }
        public Company Company { get; set; }
    }
}
