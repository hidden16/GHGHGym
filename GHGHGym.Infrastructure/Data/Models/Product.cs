﻿using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Product : BaseDeletableModel
    {
        /// <summary>
        /// Id of the product
        /// </summary>
        [Key]
        [Comment("Id of the product")]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        [Required]
        [StringLength(NameMaxLength)]
        [Comment("Name of the product")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Price of the product
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        [Comment("Price of the product")]
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the product")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Comments for the product
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();

        /// <summary>
        /// Users that purchased a product
        /// </summary>
        public List<ApplicationUser> AppUsersPurchases { get; set; } = new List<ApplicationUser>();

        /// <summary>
        /// List of images for the products
        /// </summary>
        public List<ProductImage> ProductsImages { get; set; } = new List<ProductImage>();

        /// <summary>
        /// List of product's categories
        /// </summary>
        public List<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
