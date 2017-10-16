
using Microsoft.AspNetCore.Mvc;
using Companies.API.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Companies.API.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private ILogger<CompaniesController> _logger;

        public CompaniesController(ILogger<CompaniesController> logger)
        {
            _logger = logger;
        }
        [HttpGet()]
        public IActionResult getCompanies()
        {
            return Ok(CompaniesDataStore.Current.Companies);
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult GetCompany(int id){
            var companyToReturn = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);
            if (companyToReturn == null)
            {
                _logger.LogInformation($"Company with id {id} was not found ");
                return NotFound();
            }
            return Ok(companyToReturn);
        } 

        [HttpPost()]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto Company)
        {
            if(Company == null)
            {
                return BadRequest();
            }

            var finalCompany = new CompanyDto()
            {
                Id = 3,
                CompanyName = Company.Company,
                CompanyDescription = Company.Company,
                Status = Company.Company

            };
            CompaniesDataStore.Current.Companies.Add(finalCompany);

            return CreatedAtRoute("GetCompany",new {id = 3 },finalCompany);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id,[FromBody] CompanyForCreationDto Company)
        {
            if(Company == null)
            {
                return BadRequest();
            }
            var companyFromStore = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);
            
            if(companyFromStore == null)
            {
                return NotFound();
            }
            companyFromStore.CompanyName = Company.Company;

            return NoContent();

        }    

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var companyFromStore = CompaniesDataStore.Current.Companies.FirstOrDefault(c => c.Id == id);
            if (companyFromStore == null)
            {
                return NotFound();
            }
            CompaniesDataStore.Current.Companies.Remove(companyFromStore);
            return NoContent();
        }                                       
    }
}