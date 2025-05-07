using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class Port
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public  ICollection<Voyage> DepartureVoyages { get; } = new List<Voyage>();
        public ICollection<Voyage> ArrivalVoyages { get; } = new List<Voyage>();
    }
}
