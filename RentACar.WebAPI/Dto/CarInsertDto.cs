namespace RentACar.WebAPI.Dto
{
    public class CarInsertDto
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? TypeName { get; set; }
        public int ProductionYear { get; set; }
    }
}
