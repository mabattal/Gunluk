using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    YazarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.YazarId);
                });

            migrationBuilder.CreateTable(
                name: "Nots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konu = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Metin = table.Column<string>(type: "Varchar(2000)", maxLength: 2000, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotSil = table.Column<bool>(type: "bit", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nots_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "YazarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nots_YazarId",
                table: "Nots",
                column: "YazarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nots");

            migrationBuilder.DropTable(
                name: "Yazar");
        }
    }
}
