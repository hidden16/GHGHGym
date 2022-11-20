﻿// <auto-generated />
using System;
using GHGHGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221120213453_ChangedProductDescriptionMaxLength")]
    partial class ChangedProductDescriptionMaxLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserProduct", b =>
                {
                    b.Property<Guid>("AppUsersPurchasesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PurchasedProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppUsersPurchasesId", "PurchasedProductsId");

                    b.HasIndex("PurchasedProductsId");

                    b.ToTable("ApplicationUserProduct");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TrainerId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dca51d5a-bb2b-4258-a0e6-b489fd517912"),
                            CategoryType = 0,
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(2853),
                            IsDeleted = false,
                            Name = "Sports Supplements"
                        },
                        new
                        {
                            Id = new Guid("2dbf0505-bce5-4de4-81c5-f1abcc5eaa65"),
                            CategoryType = 1,
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(2867),
                            IsDeleted = false,
                            Name = "Proteins",
                            ParentCategoryId = new Guid("dca51d5a-bb2b-4258-a0e6-b489fd517912")
                        });
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.ProductImage", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("ProductsImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.TrainerImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ImageId", "TrainerId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainersImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.TrainingProgramImage", b =>
                {
                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ImageId", "TrainingProgramId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingProgramImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.UserImage", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "ImageId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ImageId");

                    b.ToTable("UsersImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.Property<Guid>("SubscriptionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.SubscriptionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae062bf7-0ee2-4642-b1d4-c164f03f4872"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(176),
                            IsDeleted = false,
                            Name = "Weekly"
                        },
                        new
                        {
                            Id = new Guid("8eed35e5-1d2a-4096-b785-d2235c8762d5"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(210),
                            IsDeleted = false,
                            Name = "Monthly"
                        },
                        new
                        {
                            Id = new Guid("ab891026-a217-45d3-8b96-92e3899d5925"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(211),
                            IsDeleted = false,
                            Name = "Yearly"
                        },
                        new
                        {
                            Id = new Guid("45a8bdf3-d417-4b0e-98d0-ba00d5fab6f5"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(212),
                            IsDeleted = false,
                            Name = "Weekly with trainer"
                        },
                        new
                        {
                            Id = new Guid("06f25094-a93a-4bb4-aaef-1e1a7ec9a873"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(213),
                            IsDeleted = false,
                            Name = "Monthly with trainer"
                        },
                        new
                        {
                            Id = new Guid("8f7e6013-13c4-461a-85fc-b152286991d7"),
                            CreatedOn = new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(223),
                            IsDeleted = false,
                            Name = "Yearly with trainer"
                        });
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("InstagramLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.TrainingProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerPrograms");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.UserSubscription", b =>
                {
                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SubscriptionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscriptionStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriptionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSubscriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ApplicationUserProduct", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("AppUsersPurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("PurchasedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Trainer", null)
                        .WithMany("UsersWithTrainer")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Category", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", "ApplicationUser")
                        .WithMany("Comments")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId");

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Trainer", "Trainer")
                        .WithMany("Comments")
                        .HasForeignKey("TrainerId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Product");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.ProductImage", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Image", "Image")
                        .WithMany("ProductImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Product", "Product")
                        .WithMany("ProductsImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.TrainerImage", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Image", "Image")
                        .WithMany("TrainersImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Trainer", "Trainer")
                        .WithMany("TrainersImages")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.TrainingProgramImage", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Image", "Image")
                        .WithMany("TrainingProgramImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingProgramImages")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.ImageMapping.UserImage", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", "ApplicationUser")
                        .WithMany("UsersImages")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Image", "Image")
                        .WithMany("UsersImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Product", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Subscription", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", "ApplicationUser")
                        .WithOne("Trainer")
                        .HasForeignKey("GHGHGym.Infrastructure.Data.Models.Trainer", "ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.TrainingProgram", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Trainer", "Trainer")
                        .WithMany("TrainerPrograms")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.UserSubscription", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Subscription", "Subscription")
                        .WithMany("UsersSubscriptions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", "User")
                        .WithMany("UsersSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Account.ApplicationUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Trainer");

                    b.Navigation("UsersImages");

                    b.Navigation("UsersSubscriptions");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Image", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("TrainersImages");

                    b.Navigation("TrainingProgramImages");

                    b.Navigation("UsersImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ProductsImages");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Subscription", b =>
                {
                    b.Navigation("UsersSubscriptions");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.Trainer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TrainerPrograms");

                    b.Navigation("TrainersImages");

                    b.Navigation("UsersWithTrainer");
                });

            modelBuilder.Entity("GHGHGym.Infrastructure.Data.Models.TrainingProgram", b =>
                {
                    b.Navigation("TrainingProgramImages");
                });
#pragma warning restore 612, 618
        }
    }
}
