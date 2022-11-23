using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class AddedAppUserIdToTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Trainers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("99e3ef20-84b5-4d9c-ad6c-577c759c5cd4"), 0, new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(8936), null, false, null, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("00c9f804-c69a-4836-9533-16c01c6ab9b0"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6743), null, false, null, "Monthly" },
                    { new Guid("1967accc-e206-496a-9e60-25b666d6ec1d"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6664), null, false, null, "Weekly" },
                    { new Guid("3580039a-3a75-4d01-96ff-7ed0961b4ba4"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6746), null, false, null, "Weekly with trainer" },
                    { new Guid("74c63bbc-0223-49ca-a2c6-dfa776f2d781"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6746), null, false, null, "Monthly with trainer" },
                    { new Guid("be7e2eab-60f3-41ef-9ed7-5a84592445cd"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6747), null, false, null, "Yearly with trainer" },
                    { new Guid("dc73bf36-3f27-4172-9a48-daf11c06000d"), new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(6745), null, false, null, "Yearly" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("46ca0c48-f371-4945-8a24-2110def8a14b"), 1, new DateTime(2022, 11, 15, 11, 43, 51, 522, DateTimeKind.Utc).AddTicks(8940), null, false, null, "Proteins", new Guid("99e3ef20-84b5-4d9c-ad6c-577c759c5cd4") });

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_ApplicationUserId",
                table: "Trainers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_ApplicationUserId",
                table: "Trainers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_ApplicationUserId",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_ApplicationUserId",
                table: "Trainers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46ca0c48-f371-4945-8a24-2110def8a14b"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("00c9f804-c69a-4836-9533-16c01c6ab9b0"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("1967accc-e206-496a-9e60-25b666d6ec1d"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("3580039a-3a75-4d01-96ff-7ed0961b4ba4"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("74c63bbc-0223-49ca-a2c6-dfa776f2d781"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("be7e2eab-60f3-41ef-9ed7-5a84592445cd"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("dc73bf36-3f27-4172-9a48-daf11c06000d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("99e3ef20-84b5-4d9c-ad6c-577c759c5cd4"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Trainers");

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
    }
}
