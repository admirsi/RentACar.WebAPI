namespace RentACar.WebAPI.Dto
{
    public class CarSearchDto
    {

        public int PageSize { get; set; } = 10;


        public int Page { get; set; }

        public string? Title { get; set; }
    }
}
