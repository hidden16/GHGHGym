using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Core.Models.TrainingPrograms
{
    public class CreateTrainingProgramViewModel
    {
        public Guid TrainerId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ProgramDescription { get; set; } = null!;

        public List<IFormFile>? Files { get; set; } = new List<IFormFile>();
        //filled in controller
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
