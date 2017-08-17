using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tender.Storage.Context.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenderOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CurrentBid = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FinalBid = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    Requirements = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderTasks_TenderOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "TenderOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bidders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Credentials = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TenderTaskId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bidders_TenderTasks_TenderTaskId",
                        column: x => x.TenderTaskId,
                        principalTable: "TenderTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bidders_TenderTaskId",
                table: "Bidders",
                column: "TenderTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderTasks_OwnerId",
                table: "TenderTasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bidders");

            migrationBuilder.DropTable(
                name: "TenderTasks");

            migrationBuilder.DropTable(
                name: "TenderOwners");
        }
    }
}
