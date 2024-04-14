using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class dkjdnffffffkolilggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Perfil_PerfilId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "PerfilId",
                table: "Comentario",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_PerfilId",
                table: "Comentario",
                newName: "IX_Comentario_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comentario",
                newName: "PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario",
                newName: "IX_Comentario_PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Perfil_PerfilId",
                table: "Comentario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
