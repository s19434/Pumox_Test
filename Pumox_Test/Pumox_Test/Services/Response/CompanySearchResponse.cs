using Pumox_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Services.Response
{
    public class CompanySearchResponse
    {
        public List<CompanyResponse> Responses { get; set; }
    }
    public static class CompanySearchResponseExtensions
    {
        public static CompanySearchResponse ToSearchResponse(this List<Company> companies)
        {
            if (companies.Count == 0 || companies == null)
            {
                return null;
            }

            var result = new CompanySearchResponse
            {
                Responses = companies.ToResponseList()
            };
            return result;
        }
    }
}
