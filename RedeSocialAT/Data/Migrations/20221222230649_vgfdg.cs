using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class vgfdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PerfilNome",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PerfilNome",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id");
        }
    }
}
