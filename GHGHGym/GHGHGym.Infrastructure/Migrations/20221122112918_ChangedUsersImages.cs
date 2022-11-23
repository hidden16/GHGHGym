using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangedUsersImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersImages");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UsersImages",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersImages", x => new { x.UserId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_UsersImages_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersImages_ApplicationUserId",
                table: "UsersImages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersImages_ImageId",
                table: "UsersImages",
                column: "ImageId");
        }
    }
}
