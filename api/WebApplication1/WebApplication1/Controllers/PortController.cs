using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PortController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPorts()
        {
            var ports = dbContext.Port.ToListAsync();

            return Ok(ports);
        }

        [HttpPost]
        public IActionResult AddPort(PortDto portDto)
        {
            var port = new Port
            {
                Name = portDto.Name,
                CountryId = portDto.CountryId,
            };
            dbContext.Port.Add(port);
            dbContext.SaveChanges();

            return Ok(port);
        }


        [HttpPut("{id}")]
        public IActionResult EditPort(int id, PortDto portDto)
        {
            var port = dbContext.Port.Find(id);
            if (port == null)
            {
                return NotFound();
            }
            port.Name = portDto.Name;
            port.CountryId = portDto.CountryId;

            dbContext.SaveChanges();

            return Ok(port);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePort(int id)
        {
            var port = dbContext.Port.Find(id);
            if (port == null)
            {
                return NotFound();
            }
            dbContext.Port.Remove(port);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
