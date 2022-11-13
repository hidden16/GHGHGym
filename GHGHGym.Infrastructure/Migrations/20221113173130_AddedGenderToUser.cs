using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class AddedGenderToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f8ddfc4-2dc9-4eca-a58f-904dc06b6a5d"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("0e3e25b4-c213-41ea-aa0e-ade24b0312a0"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("38a7c80f-b9de-4151-8ac7-11deae82933d"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6c1d421d-c9e0-44e9-ac1f-bc32db175e9b"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("c75171ed-8faf-4aa5-9c25-a63229384a32"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f728809f-2e4d-483e-8c6e-b2c927ea29c5"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("fa1c5b75-b0d4-4436-b550-862752a59759"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5c7247c6-08fb-4609-91fe-59e07483f272"));

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "RemovedOn",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Categories",
                newName: "CreatedOn");

            migrationBuilder.AlterTable(
                name: "Trainers",
                oldComment: "Trainers in the gym");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TrainingProgramImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingProgramImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TrainersImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainersImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Link for Twitter profile");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number of the trainer");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Trainers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "Last name of the trainer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Trainers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the entity deleted from the database");

            migrationBuilder.AlterColumn<string>(
                name: "InstagramLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Link for Instagram profile");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Trainers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "First name of the trainer");

            migrationBuilder.AlterColumn<string>(
                name: "FacebookLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Link for Facebook profile");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Email address of the trainer");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trainers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Trainer description");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Trainers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Primary key");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Trainers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Trainers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Trainers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProgramDescription",
                table: "TrainerPrograms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Description of the training program");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainerPrograms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Name of the program");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainerPrograms",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the entity deleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TrainerPrograms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "TrainerPrograms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TrainerPrograms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "SubscriptionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionTypeId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the subscription");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Subscriptions",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldComment: "Price of the subscription");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the subscription deleted");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Primary key");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Subscriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Subscriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ProductsImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductsImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldComment: "Price of the product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Name of the product");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Description of the product");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the product");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "URL of the image as a string");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the image");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainerId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Id of the trainer for which the comment is related");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Text of the comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Id of the product for which the comment is related");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the entity deleted from the database");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "The date on which the comment was posted");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id of the user who wrote the comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Primary key");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CategoriesProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoriesProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Account creation date");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "User's last name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the account deleted");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldComment: "User's first name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "User's birthdate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("69a5216e-0341-4263-815d-3fd3732c2b7d"), 0, new DateTime(2022, 11, 13, 17, 31, 30, 103, DateTimeKind.Utc).AddTicks(2041), null, false, null, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("46f0b3dd-5c20-4efc-b22b-ceb799147fda"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9939), null, false, null, "Weekly with trainer" },
                    { new Guid("84d73cc1-7a2f-4097-9c22-c0341890f687"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9941), null, false, null, "Yearly with trainer" },
                    { new Guid("8a85c04d-8d69-40a4-8c02-cbeb5de3e4bb"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9937), null, false, null, "Monthly" },
                    { new Guid("b139f105-d742-418c-8934-426e54b7bbbe"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9940), null, false, null, "Monthly with trainer" },
                    { new Guid("d4c9e3dc-8fb3-4de8-87f4-4b6e7c84f5ba"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9896), null, false, null, "Weekly" },
                    { new Guid("e9a11e16-d9c2-43ed-b803-e7339130b9b9"), new DateTime(2022, 11, 13, 17, 31, 30, 102, DateTimeKind.Utc).AddTicks(9938), null, false, null, "Yearly" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("d2f0802a-d7b2-46f4-a558-a7c717f1d4d0"), 1, new DateTime(2022, 11, 13, 17, 31, 30, 103, DateTimeKind.Utc).AddTicks(2045), null, false, null, "Proteins", new Guid("69a5216e-0341-4263-815d-3fd3732c2b7d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2f0802a-d7b2-46f4-a558-a7c717f1d4d0"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("46f0b3dd-5c20-4efc-b22b-ceb799147fda"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("84d73cc1-7a2f-4097-9c22-c0341890f687"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("8a85c04d-8d69-40a4-8c02-cbeb5de3e4bb"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b139f105-d742-418c-8934-426e54b7bbbe"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("d4c9e3dc-8fb3-4de8-87f4-4b6e7c84f5ba"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("e9a11e16-d9c2-43ed-b803-e7339130b9b9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69a5216e-0341-4263-815d-3fd3732c2b7d"));

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TrainingProgramImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingProgramImages");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TrainersImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainersImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TrainerPrograms");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "TrainerPrograms");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TrainerPrograms");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ProductsImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductsImages");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CategoriesProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoriesProducts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Categories",
                newName: "AddedOn");

            migrationBuilder.AlterTable(
                name: "Trainers",
                comment: "Trainers in the gym");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Link for Twitter profile",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number of the trainer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Trainers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "Last name of the trainer",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Trainers",
                type: "bit",
                nullable: false,
                comment: "Is the entity deleted from the database",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "InstagramLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Link for Instagram profile",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Trainers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "First name of the trainer",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FacebookLink",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Link for Facebook profile",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Email address of the trainer",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trainers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Trainer description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Trainers",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Trainers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Trainer add date");

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedOn",
                table: "Trainers",
                type: "datetime2",
                nullable: true,
                comment: "Trainer removal date");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramDescription",
                table: "TrainerPrograms",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Description of the training program",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainerPrograms",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Name of the program",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TrainerPrograms",
                type: "bit",
                nullable: false,
                comment: "Is the entity deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriptionTypeId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the subscription",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Subscriptions",
                type: "decimal(7,2)",
                nullable: false,
                comment: "Price of the subscription",
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                comment: "Is the subscription deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(7,2)",
                nullable: false,
                comment: "Price of the product",
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Name of the product",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Description of the product",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the product",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                comment: "URL of the image as a string",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the image",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainerId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Id of the trainer for which the comment is related",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Text of the comment",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Id of the product for which the comment is related",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                comment: "Is the entity deleted from the database",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                comment: "The date on which the comment was posted",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id of the user who wrote the comment",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true,
                comment: "The date on which the comment was edited");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                comment: "Account creation date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "User's last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                comment: "Is the account deleted",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                comment: "User's first name",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                comment: "User's birthdate",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddedOn", "CategoryType", "IsDeleted", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("5c7247c6-08fb-4609-91fe-59e07483f272"), new DateTime(2022, 11, 10, 13, 40, 47, 74, DateTimeKind.Utc).AddTicks(410), 0, false, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0e3e25b4-c213-41ea-aa0e-ade24b0312a0"), false, "Weekly with trainer" },
                    { new Guid("38a7c80f-b9de-4151-8ac7-11deae82933d"), false, "Monthly with trainer" },
                    { new Guid("6c1d421d-c9e0-44e9-ac1f-bc32db175e9b"), false, "Yearly" },
                    { new Guid("c75171ed-8faf-4aa5-9c25-a63229384a32"), false, "Weekly" },
                    { new Guid("f728809f-2e4d-483e-8c6e-b2c927ea29c5"), false, "Monthly" },
                    { new Guid("fa1c5b75-b0d4-4436-b550-862752a59759"), false, "Yearly with trainer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddedOn", "CategoryType", "IsDeleted", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("2f8ddfc4-2dc9-4eca-a58f-904dc06b6a5d"), new DateTime(2022, 11, 10, 13, 40, 47, 74, DateTimeKind.Utc).AddTicks(415), 1, false, "Proteins", new Guid("5c7247c6-08fb-4609-91fe-59e07483f272") });
        }
    }
}
