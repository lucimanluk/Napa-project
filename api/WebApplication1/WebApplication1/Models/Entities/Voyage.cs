using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class Voyage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateOnly VoyageDate {  get; set; }

        public int DeparturePortId { get; set; }
        public Port DeparturePort { get; set; } = null!;

        public int ArrivalPortId { get; set; }
        public Port ArrivalPort { get; set; } = null!;

        public DateTime VoyageStart { get; set; }
        public DateTime VoyageEnd { get; set; }

        public int ShipId { get; set; }
        public Ship? Ship { get; set; }
    }
}
