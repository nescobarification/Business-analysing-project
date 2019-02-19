using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PFE.Migrations
{
    public partial class changeRFM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SummaryAcquisitionId",
                table: "SummaryFeature",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SummaryFeature_SummaryAcquisitionId",
                table: "SummaryFeature",
                column: "SummaryAcquisitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryFeature_SummaryAcquisition_SummaryAcquisitionId",
                table: "SummaryFeature",
                column: "SummaryAcquisitionId",
                principalTable: "SummaryAcquisition",
                principalColumn: "SummaryAcquisitionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryFeature_SummaryAcquisition_SummaryAcquisitionId",
                table: "SummaryFeature");

            migrationBuilder.DropIndex(
                name: "IX_SummaryFeature_SummaryAcquisitionId",
                table: "SummaryFeature");

            migrationBuilder.DropColumn(
                name: "SummaryAcquisitionId",
                table: "SummaryFeature");
        }
    }
}
