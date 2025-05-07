using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public CountryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = dbContext.Country.ToListAsync();

            return Ok(countries);
        }

        [HttpPost]
        public IActionResult AddCountry(CountryDto countryDto)
        {
            var country = new Country
            {
                Name = countryDto.Name,
            };

            dbContext.Country.Add(country);
            dbContext.SaveChanges();
            return Ok(country);
        }

        [HttpPut("{id}")]
        public IActionResult EditCountry(int id, CountryDto countryDto)
        {
            var country = dbContext.Country.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            country.Name = countryDto.Name;

            dbContext.SaveChanges();

            return Ok(country);
        }
    }
}
