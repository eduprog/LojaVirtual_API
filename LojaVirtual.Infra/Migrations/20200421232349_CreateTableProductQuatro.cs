using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Migrations
{
    public partial class CreateTableProductQuatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_User_IdUserCreate",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_User_IdUserCreate",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_IdUserCreate",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IdUserCreate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "IdUserCreate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IdUserCreate",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_UserCreateId",
                table: "ProductImages",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserCreateId",
                table: "Categories",
                column: "UserCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_User_UserCreateId",
                table: "Categories",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_User_UserCreateId",
                table: "ProductImages",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_User_UserCreateId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_User_UserCreateId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_UserCreateId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UserCreateId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserCreate",
                table: "ProductImages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductImages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserCreate",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId1",
                table: "ProductSizes",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_IdUserCreate",
                table: "ProductImages",
                column: "IdUserCreate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdUserCreate",
                table: "Categories",
                column: "IdUserCreate");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_User_IdUserCreate",
                table: "Categories",
                column: "IdUserCreate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_User_IdUserCreate",
                table: "ProductImages",
                column: "IdUserCreate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId1",
                table: "ProductImages",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId1",
                table: "ProductSizes",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
