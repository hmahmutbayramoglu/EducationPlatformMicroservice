namespace EducationPlatformMicroservice.Basket.Api.Dtos
{
    public record BasketDto
    {
        public Guid UserId { get; init; }
        public List<BasketItemDto> BasketItems { get; init; } = new();
    }
}
