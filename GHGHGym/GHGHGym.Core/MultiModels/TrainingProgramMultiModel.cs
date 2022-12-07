using GHGHGym.Core.Models.TrainingPrograms;

namespace GHGHGym.Core.MultiModels
{
    public class TrainingProgramMultiModel
    {
        public IEnumerable<TrainingProgramViewModel> TrainingPrograms { get; set; }
        public string? ReturnUrl { get; set; }

    }
}
