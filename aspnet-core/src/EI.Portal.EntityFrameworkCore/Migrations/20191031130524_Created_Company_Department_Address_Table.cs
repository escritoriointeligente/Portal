using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EI.Portal.Migrations
{
    public partial class Created_Company_Department_Address_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Street = table.Column<string>(maxLength: 256, nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Complement = table.Column<string>(nullable: true),
                    District = table.Column<string>(maxLength: 256, nullable: false),
                    Cep = table.Column<string>(maxLength: 9, nullable: false),
                    City = table.Column<string>(nullable: false),
                    Uf = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    FantasyName = table.Column<string>(maxLength: 256, nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DepartmentId",
                table: "AbpUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_AddressId",
                table: "Company",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Department_DepartmentId",
                table: "AbpUsers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Department_DepartmentId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_DepartmentId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AbpUsers");
        }
    }
}
