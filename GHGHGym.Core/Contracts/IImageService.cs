﻿using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Contracts
{
    public interface IImageService
    {
        Task<Image> AddImage(string imageUrl);
        Task<List<Image>> AddImages(ICollection<string> imageUrls);
        Task SetDeletedRangeByUrls(IEnumerable<string> imageUrls);
    }
}
