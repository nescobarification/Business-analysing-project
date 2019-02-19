using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PFE.Migrations
{
    public partial class NewPdfRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PdfAcquisition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PdfId = table.Column<int>(nullable: false),
                    UserId = table.Column<String>(nullable: false, maxLength: 450),
                    AcquisitionDate = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfAcquisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfAcquisition_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

                migrationBuilder.CreateIndex(
                    name: "IX_PdfAcquisition_UserId",
                    table: "PdfAcquisition",
                    column: "UserId")
                ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_PdfAcquisition_AspNetUsers_Id", "PdfAcquisition");
            migrationBuilder.DropIndex("IX_PdfAcquisition_UserId", "PdfAcquisition");
            migrationBuilder.DropTable("PdfAcquisition");
        }
    }
}
