using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ShipController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllShips()
        {
            var ships = dbContext.Ship.ToListAsync();

            return Ok(ships);
        }

        [HttpPost]
        public IActionResult AddShip(ShipDto shipDto)
        {
            var ship = new Ship
            {
                Name = shipDto.Name,
                MaxSpeed = shipDto.MaxSpeed,
            };

             dbContext.Ship.Add(ship);
             dbContext.SaveChanges();

            return Ok(ship);
        }

        [HttpPut("{id}")]
        public IActionResult EditShip(int id, ShipDto shipDto)
        {
            var ship = dbContext.Ship.Find(id);
            if (ship == null)
            {
                return NotFound();
            }

            ship.Name = shipDto.Name;
            ship.MaxSpeed = shipDto.MaxSpeed;

            dbContext.SaveChanges();

            return Ok(ship);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShip(int id)
        {
            var ship = dbContext.Ship.Find(id);
            if (ship == null)
            {
                return NotFound();
            }
            dbContext.Ship.Remove(ship);
            dbContext.SaveChanges();

            return Ok(ship);
        }
    }
}
