namespace GHGHGym.Core.Models.Product
{
    public class ProductWithDeletedViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string>? ImageUrls { get; set; }
        public string? IsDeleted { get; set; }
    }
}
