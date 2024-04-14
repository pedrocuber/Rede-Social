using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class dkjdnff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Perfil_PerfilId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PerfilId",
                table: "Comentario");

            migrationBuilder.AddColumn<int>(
                name: "PostsPostId",
                table: "Comentario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostsPostId",
                table: "Comentario",
                column: "PostsPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Post_PostsPostId",
                table: "Comentario",
                column: "PostsPostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Post_PostsPostId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PostsPostId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "PostsPostId",
                table: "Comentario");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PerfilId",
                table: "Comentario",
                column: "PerfilId");

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
