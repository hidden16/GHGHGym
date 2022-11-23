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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }
    }
}