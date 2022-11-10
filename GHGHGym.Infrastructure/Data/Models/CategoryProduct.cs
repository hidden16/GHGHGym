using GHGHGym.Infrastructure.Abstractions.Contracts;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class CategoryProduct : IDeletableEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}