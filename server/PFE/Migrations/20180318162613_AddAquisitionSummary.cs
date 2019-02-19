using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PFE.Migrations
{
    public partial class AddAquisitionSummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateTable(
                name: "SummaryAcquisition",
                columns: table => new
                {
                    SummaryAcquisitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstPurchaseDate = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    FrequencyPurchase = table.Column<float>(nullable: false),
                    LastPurchaseDate = table.Column<DateTime>(nullable: false),
                    MoneterySpend = table.Column<float>(nullable: false),
                    MoneteryValue = table.Column<int>(nullable: false),
                    Recency = table.Column<int>(nullable: false),
                    SumAquisition = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryAcquisition", x => x.SummaryAcquisitionId);
                    table.ForeignKey(
                        name: "FK_SummaryAcquisition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAcquisition_UserId",
                table: "SummaryAcquisition",
                column: "UserId");

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryAcquisition");


        }
    }
}
