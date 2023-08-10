using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nots_Yazar_YazarId",
                table: "Nots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazar",
                table: "Yazar");

            migrationBuilder.RenameTable(
                name: "Yazar",
                newName: "Yazars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazars",
                table: "Yazars",
                column: "YazarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nots_Yazars_YazarId",
                table: "Nots",
                column: "YazarId",
                principalTable: "Yazars",
                principalColumn: "YazarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nots_Yazars_YazarId",
                table: "Nots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Yazars",
                table: "Yazars");

            migrationBuilder.RenameTable(
                name: "Yazars",
                newName: "Yazar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Yazar",
                table: "Yazar",
                column: "YazarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nots_Yazar_YazarId",
                table: "Nots",
                column: "YazarId",
                principalTable: "Yazar",
                principalColumn: "YazarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
