using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class jdhb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Perfil",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PerfilId",
                table: "Post",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_PostId",
                table: "Perfil",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_Post_PostId",
                table: "Perfil",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");

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
                name: "FK_Perfil_Post_PostId",
                table: "Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Perfil_PerfilId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PerfilId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Perfil_PostId",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Perfil");
        }
    }
}
