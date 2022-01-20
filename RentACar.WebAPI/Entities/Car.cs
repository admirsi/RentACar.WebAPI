namespace RentACar.WebAPI.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? TypeName { get; set; }
        public int ProductionYear { get; set; }            
        public int KilometersDriven { get; set; }
        public string? Origin { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; }
    }
}
