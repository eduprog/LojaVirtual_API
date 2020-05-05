using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Migrations
{
    public partial class RemoveCategoryInCartAndAddStatusOfCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Categories_CategoryId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_CategoryId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Carts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CategoryId",
                table: "Carts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Categories_CategoryId",
                table: "Carts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
