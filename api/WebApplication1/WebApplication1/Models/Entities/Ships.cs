namespace WebApplication1.Models.Entities
{

    public class Ships
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int MaxSpeed { get; set; }
    }
}
