using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class ShipDto
    {
        public required string Name { get; set; }
        public required int MaxSpeed { get; set; }
    }
}
