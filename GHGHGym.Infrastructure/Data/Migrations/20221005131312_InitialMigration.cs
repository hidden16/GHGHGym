using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GHGHGym.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "First name of the trainer"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Last name of the trainer"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone number of the trainer"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Email address of the trainer"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Trainer description"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Trainer add date"),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Trainer removal date"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the entity deleted from the database")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                },
                comment: "Trainers in the gym");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
