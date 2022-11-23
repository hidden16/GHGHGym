using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("95b12632-572f-40f8-8a36-54549817ca4c"), 0, new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(2197), null, false, null, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("13038120-b205-4e15-96ab-c6bdb3d124b4"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(263), null, false, null, "Yearly" },
                    { new Guid("41edfe77-e89d-462b-a206-d4683b4db075"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(252), null, false, null, "Monthly" },
                    { new Guid("537b930c-279f-41cf-afa1-5a3c0942a7ee"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(266), null, false, null, "Yearly with trainer" },
                    { new Guid("613710f1-6baf-46be-b6f8-35bc0b67e1f8"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(264), null, false, null, "Weekly with trainer" },
                    { new Guid("6864ef9c-1c18-4591-9bde-e761cb3e5e56"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(265), null, false, null, "Monthly with trainer" },
                    { new Guid("b7041124-a7e1-4dff-b6a1-edaf1666bdb3"), new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(223), null, false, null, "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("81024304-f142-48a6-b573-ba3252163fcd"), 1, new DateTime(2022, 11, 15, 11, 4, 17, 478, DateTimeKind.Utc).AddTicks(2208), null, false, null, "Proteins", new Guid("95b12632-572f-40f8-8a36-54549817ca4c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("81024304-f142-48a6-b573-ba3252163fcd"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("13038120-b205-4e15-96ab-c6bdb3d124b4"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("41edfe77-e89d-462b-a206-d4683b4db075"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("537b930c-279f-41cf-afa1-5a3c0942a7ee"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("613710f1-6baf-46be-b6f8-35bc0b67e1f8"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("6864ef9c-1c18-4591-9bde-e761cb3e5e56"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b7041124-a7e1-4dff-b6a1-edaf1666bdb3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("95b12632-572f-40f8-8a36-54549817ca4c"));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
