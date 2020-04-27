using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Infra.Migrations
{
    public partial class CreateTablePlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(40)", nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Image = table.Column<string>(type: "varchar(400)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    VisibleOnApp = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
