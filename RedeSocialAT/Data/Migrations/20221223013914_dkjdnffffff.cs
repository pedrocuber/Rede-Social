using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class dkjdnffffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Post_PostsPostId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "PostsPostId",
                table: "Comentario",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_PostsPostId",
                table: "Comentario",
                newName: "IX_Comentario_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Comentario",
                newName: "PostsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario",
                newName: "IX_Comentario_PostsPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Post_PostsPostId",
                table: "Comentario",
                column: "PostsPostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }
    }
}
