using GHGHGym.Infrastructure.Abstractions.Contracts;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class ProductImage : IDeletableEntity
    {
        public Guid ProductId { get; set; }
        [Required]
        public Product Product { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
