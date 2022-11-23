using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;
namespace GHGHGym.Core.Models.Product
{
    public class PurchaseProductViewModel
    {
        [MaxLength(QuantityMaxLength)]
        [MinLength(QuantityMinLength)]
        public int Quantity { get; set; }
    }
}
