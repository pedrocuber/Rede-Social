using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class tird : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PerfilId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemPost",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagemPost",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PerfilId",
                table: "Post",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
