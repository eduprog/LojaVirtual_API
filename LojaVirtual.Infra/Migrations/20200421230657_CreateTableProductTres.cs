using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Migrations
{
    public partial class CreateTableProductTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_User_IdUserCreate",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_IdProduct",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_IdUserCreate",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_IdProduct",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_User_IdUserCreate",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_IdProduct",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_IdUserCreate",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdUserCreate",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_IdProduct",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Banners_IdUserCreate",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "IdUserCreate",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdUserCreate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IdUserCreate",
                table: "Banners");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductSizes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductSizes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "ProductSizes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCreateId",
                table: "Banners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId1",
                table: "ProductSizes",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_UserCreateId",
                table: "ProductSizes",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserCreateId",
                table: "Products",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_UserCreateId",
                table: "Banners",
                column: "UserCreateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_User_UserCreateId",
                table: "Banners",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
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
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_UserCreateId",
                table: "Products",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes",
                column: "ProductId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_User_UserCreateId",
                table: "ProductSizes",
                column: "UserCreateId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_User_UserCreateId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_UserCreateId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Products_ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_User_UserCreateId",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductSizes_UserCreateId",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserCreateId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Banners_UserCreateId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UserCreateId",
                table: "Banners");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserCreate",
                table: "ProductSizes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategory",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserCreate",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "ProductImages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUserCreate",
                table: "Banners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_IdProduct",
                table: "ProductSizes",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_IdUserCreate",
                table: "ProductSizes",
                column: "IdUserCreate");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCategory",
                table: "Products",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdUserCreate",
                table: "Products",
                column: "IdUserCreate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_IdProduct",
                table: "ProductImages",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_IdUserCreate",
                table: "Banners",
                column: "IdUserCreate");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_User_IdUserCreate",
                table: "Banners",
                column: "IdUserCreate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_IdProduct",
                table: "ProductImages",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCategory",
                table: "Products",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_IdUserCreate",
                table: "Products",
                column: "IdUserCreate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Products_IdProduct",
                table: "ProductSizes",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_User_IdUserCreate",
                table: "ProductSizes",
                column: "IdUserCreate",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
