using System.Collections.Generic;

namespace Pumox_Test.Models
{
    public class Company
    {
        public long IdCompany { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}