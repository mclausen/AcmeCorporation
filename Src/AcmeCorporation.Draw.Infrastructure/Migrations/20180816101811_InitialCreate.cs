using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeCorporation.Draw.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerialNumbers",
                columns: table => new
                {
                    Serial = table.Column<string>(nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(nullable: false),
                    UsageCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumbers", x => x.Serial);
                });

            migrationBuilder.CreateTable(
                name: "RaffleSubmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    SerialNumberSerial = table.Column<string>(nullable: true),
                    SubmissionTimeUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaffleSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaffleSubmissions_SerialNumbers_SerialNumberSerial",
                        column: x => x.SerialNumberSerial,
                        principalTable: "SerialNumbers",
                        principalColumn: "Serial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaffleSubmissions_SerialNumberSerial",
                table: "RaffleSubmissions",
                column: "SerialNumberSerial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaffleSubmissions");

            migrationBuilder.DropTable(
                name: "SerialNumbers");
        }
    }
}
