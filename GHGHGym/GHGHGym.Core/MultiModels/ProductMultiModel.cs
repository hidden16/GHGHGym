using GHGHGym.Core.Models.Comments;
using GHGHGym.Core.Models.Product;

namespace GHGHGym.Core.MultiModels
{
    public class ProductMultiModel
    {
        public ProductViewModel? ProductDto { get; set; }
        public PurchaseProductViewModel? PurchaseProductDto { get; set; }
        public IEnumerable<CommentViewModel>? Comments { get; set; }
    }
}
