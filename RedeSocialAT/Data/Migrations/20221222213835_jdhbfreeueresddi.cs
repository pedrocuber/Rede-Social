using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class jdhbfreeueresddi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_Post_PostId",
                table: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Perfil_PostId",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Perfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Perfil",
                type: "int",
                nullable: true);

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
        }
    }
}
