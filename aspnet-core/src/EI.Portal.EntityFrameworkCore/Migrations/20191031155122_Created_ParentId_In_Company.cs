using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EI.Portal.Migrations
{
    public partial class Created_ParentId_In_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "Company",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Company",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_ParentId",
                table: "Company",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Company_ParentId",
                table: "Company",
                column: "ParentId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Company_ParentId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_ParentId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Company");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Company",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
