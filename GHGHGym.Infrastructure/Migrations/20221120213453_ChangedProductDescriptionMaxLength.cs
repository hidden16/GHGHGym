using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangedProductDescriptionMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("393c4db8-ee1a-493f-a42e-cd6ceb66af86"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("51af037c-0bfe-4d5b-8c44-77aa8079990d"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("7b30dbca-3587-4646-adef-ba0bf1207f06"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("9396c936-8b07-4cca-b3d1-c2232102c40d"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("b0e6fc38-a20c-4c08-a286-42828dc5fafc"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("eb2f8b64-0012-4a08-b139-1fcf9b062750"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("f817fe7d-55b8-4007-b24e-1366d0e4181d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("155481db-99d9-4891-be18-3e6895fbb59c"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("dca51d5a-bb2b-4258-a0e6-b489fd517912"), 0, new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(2853), null, false, null, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("06f25094-a93a-4bb4-aaef-1e1a7ec9a873"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(213), null, false, null, "Monthly with trainer" },
                    { new Guid("45a8bdf3-d417-4b0e-98d0-ba00d5fab6f5"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(212), null, false, null, "Weekly with trainer" },
                    { new Guid("8eed35e5-1d2a-4096-b785-d2235c8762d5"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(210), null, false, null, "Monthly" },
                    { new Guid("8f7e6013-13c4-461a-85fc-b152286991d7"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(223), null, false, null, "Yearly with trainer" },
                    { new Guid("ab891026-a217-45d3-8b96-92e3899d5925"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(211), null, false, null, "Yearly" },
                    { new Guid("ae062bf7-0ee2-4642-b1d4-c164f03f4872"), new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(176), null, false, null, "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("2dbf0505-bce5-4de4-81c5-f1abcc5eaa65"), 1, new DateTime(2022, 11, 20, 21, 34, 53, 382, DateTimeKind.Utc).AddTicks(2867), null, false, null, "Proteins", new Guid("dca51d5a-bb2b-4258-a0e6-b489fd517912") });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2dbf0505-bce5-4de4-81c5-f1abcc5eaa65"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("06f25094-a93a-4bb4-aaef-1e1a7ec9a873"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("45a8bdf3-d417-4b0e-98d0-ba00d5fab6f5"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("8eed35e5-1d2a-4096-b785-d2235c8762d5"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f7e6013-13c4-461a-85fc-b152286991d7"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("ab891026-a217-45d3-8b96-92e3899d5925"));

            migrationBuilder.DeleteData(
                table: "SubscriptionTypes",
                keyColumn: "Id",
                keyValue: new Guid("ae062bf7-0ee2-4642-b1d4-c164f03f4872"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dca51d5a-bb2b-4258-a0e6-b489fd517912"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("155481db-99d9-4891-be18-3e6895fbb59c"), 0, new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(7254), null, false, null, "Sports Supplements", null });

            migrationBuilder.InsertData(
                table: "SubscriptionTypes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("51af037c-0bfe-4d5b-8c44-77aa8079990d"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4460), null, false, null, "Yearly with trainer" },
                    { new Guid("7b30dbca-3587-4646-adef-ba0bf1207f06"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4453), null, false, null, "Monthly" },
                    { new Guid("9396c936-8b07-4cca-b3d1-c2232102c40d"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4455), null, false, null, "Yearly" },
                    { new Guid("b0e6fc38-a20c-4c08-a286-42828dc5fafc"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4457), null, false, null, "Weekly with trainer" },
                    { new Guid("eb2f8b64-0012-4a08-b139-1fcf9b062750"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4415), null, false, null, "Weekly" },
                    { new Guid("f817fe7d-55b8-4007-b24e-1366d0e4181d"), new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(4458), null, false, null, "Monthly with trainer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("393c4db8-ee1a-493f-a42e-cd6ceb66af86"), 1, new DateTime(2022, 11, 20, 16, 5, 9, 133, DateTimeKind.Utc).AddTicks(7283), null, false, null, "Proteins", new Guid("155481db-99d9-4891-be18-3e6895fbb59c") });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
