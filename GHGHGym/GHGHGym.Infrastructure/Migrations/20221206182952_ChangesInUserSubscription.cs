using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangesInUserSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UsersSubscriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UsersSubscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "UsersSubscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersSubscriptions_TrainerId",
                table: "UsersSubscriptions",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSubscriptions_Trainers_TrainerId",
                table: "UsersSubscriptions",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersSubscriptions_Trainers_TrainerId",
                table: "UsersSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_UsersSubscriptions_TrainerId",
                table: "UsersSubscriptions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UsersSubscriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UsersSubscriptions");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "UsersSubscriptions");
        }
    }
}
