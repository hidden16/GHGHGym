using GHGHGym.Core.Contracts;
using GHGHGym.Core.Services;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using GHGHGym.Core.Services.CloudinaryService.Models;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GHGHGymServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ITrainingProgramService, TrainingProgramService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            return services;
        }
    }
}