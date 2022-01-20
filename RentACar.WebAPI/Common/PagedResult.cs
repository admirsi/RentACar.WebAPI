namespace RentACar.WebAPI.Common
{
    public class PagedResult<T>
    {
        public long TotalCount { get; set; }
        public List<T>? Data { get; set; }
    }
}