using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Infrastructure.Migrations
{
    public partial class ChangesInSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Subscriptions");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SubscriptionTypes",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SubscriptionTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Subscriptions",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
