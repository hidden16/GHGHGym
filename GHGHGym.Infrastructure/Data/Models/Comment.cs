using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
