using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class VoyageDto
    {
        public DateOnly VoyageDate { get; set; }
        public int DeparturePortId { get; set; }
        public int ArrivalPortId { get; set; }
        public DateTime VoyageStart { get; set; }
        public DateTime VoyageEnd { get; set; }
        public int ShipId { get; set; }
    }
}
