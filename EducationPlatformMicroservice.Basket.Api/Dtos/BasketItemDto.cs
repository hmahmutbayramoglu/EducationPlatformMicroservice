namespace EducationPlatformMicroservice.Basket.Api.Dtos
{
    public record BasketItemDto
    {
       
        public Guid CourseId { get; init; }
        public string CourseName { get; init; } = string.Empty;
        public decimal CoursePrice { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
        public decimal? PriceByApplyDiscountRate { get; init; } // indirim varsa indirimli fiyat
    }
}
