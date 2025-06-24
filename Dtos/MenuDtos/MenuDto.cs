namespace BadmintonHub.Dtos.MenuDtos
{
    public class MenuDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Description { get; init; } = null!;
        public double Price { get; init; }
        public string ImageUrl { get; init; } = null!;
    }
}
