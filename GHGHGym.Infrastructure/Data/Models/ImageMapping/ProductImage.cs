using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class ProductImage
    {
        public Guid ProductId { get; set; }
        [Required]
        public Product Product { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
    }
}
