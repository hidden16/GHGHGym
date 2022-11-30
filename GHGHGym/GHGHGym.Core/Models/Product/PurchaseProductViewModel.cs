using System.ComponentModel.DataAnnotations;
namespace GHGHGym.Core.Models.Product
{
    public class PurchaseProductViewModel
    {
        [Range(typeof(decimal), $"1", $"9")]
        public decimal Quantity { get; set; }
    }
}
