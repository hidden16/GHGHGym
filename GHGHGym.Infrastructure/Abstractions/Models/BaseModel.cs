using GHGHGym.Infrastructure.Abstractions.Contracts;

namespace GHGHGym.Infrastructure.Abstractions.Models
{
    public abstract class BaseModel : IAuditInfo
    {
        public BaseModel()
        {
            CreatedOn = DateTime.UtcNow;
        }
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
