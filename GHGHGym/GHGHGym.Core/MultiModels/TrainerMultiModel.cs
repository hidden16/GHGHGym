using GHGHGym.Core.Models.Comments;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Core.Models.Trainers;

namespace GHGHGym.Core.MultiModels
{
    public class TrainerMultiModel
    {
        public TrainerViewModel TrainerDto { get; set; } = null!;
        public IEnumerable<CommentViewModel> Comments { get; set; } = null!;
    }
}
