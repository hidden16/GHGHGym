namespace GHGHGym.Infrastructure.Data.Models
{
    public class CategoryProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}