using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangedProductAndCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesProducts");

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

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "CategoriesProducts",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CategoriesProducts_ProductId",
                table: "CategoriesProducts",
                column: "ProductId");
        }
    }
}
