using GHGHGym.Infrastructure.Abstractions.Contracts;

namespace GHGHGym.Infrastructure.Abstractions.Models
{
    public abstract class BaseDeletableModel : BaseModel, IDeletableEntity
    {
        public BaseDeletableModel()
        {
            IsDeleted = false;
        }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
