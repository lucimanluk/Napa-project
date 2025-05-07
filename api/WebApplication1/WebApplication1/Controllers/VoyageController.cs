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
    public class VoyageController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VoyageController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetVoyages()
        {
            var voyages = dbContext.Voyage.ToListAsync();

            return Ok(voyages);
        }
        [HttpPost]
        public IActionResult AddVoyage(VoyageDto voyageDto)
        {
            var voyage = new Voyage
            {
                VoyageDate = voyageDto.VoyageDate,
                DeparturePortId = voyageDto.DeparturePortId,
                ArrivalPortId = voyageDto.ArrivalPortId,
                VoyageStart = voyageDto.VoyageStart,
                VoyageEnd = voyageDto.VoyageEnd,
                ShipId = voyageDto.ShipId,
            };

            dbContext.Voyage.Add(voyage);
            dbContext.SaveChanges();

            return Ok(voyage);
        }
        [HttpPut("{id}")]
        public IActionResult EditVoyage(int id, VoyageDto voyageDto)
        {
            var voyage = dbContext.Voyage.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            voyage.VoyageDate = voyageDto.VoyageDate;
            voyage.DeparturePortId = voyageDto.DeparturePortId;
            voyage.ArrivalPortId = voyageDto.ArrivalPortId;
            voyage.VoyageStart = voyageDto.VoyageStart;
            voyage.VoyageEnd = voyageDto.VoyageEnd;
            voyage.ShipId = voyageDto.ShipId;

            dbContext.SaveChanges();

            return Ok(voyage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVoyage(int id)
        {
            var voyage = dbContext.Voyage.Find(id);
            if (voyage == null)
            {
                return NotFound();
            }

            dbContext.Voyage.Remove(voyage);
            dbContext.SaveChanges();

            return Ok(voyage);
        }
    }
}
