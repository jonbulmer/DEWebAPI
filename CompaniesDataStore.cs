using Companies.API.Models;
using System.Collections.Generic;
namespace Companies.API
{
    public class CompaniesDataStore
    {
        public static CompaniesDataStore Current {get; } = new CompaniesDataStore();
        public List<CompanyDto> Companies {get; set;}

        public CompaniesDataStore()
        {
            Companies = new List<CompanyDto>()
            {
                 new CompanyDto()


                 {
                      Id = 1,
                      CompanyName = "DiamondEdge",
                      CompanyDescription = "Host company",
                      Status = "Mock"

                 },
                 new CompanyDto()
                 {
                     Id = 2,
                     CompanyName = "Zero2Coding",
                      CompanyDescription = "teaching company",
                      Status = "Mock"                     
                 }
            };
        }
    }
}