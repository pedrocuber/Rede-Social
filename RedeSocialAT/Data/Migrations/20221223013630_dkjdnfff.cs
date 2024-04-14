using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class dkjdnfff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComentarioCommentId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ComentarioCommentId",
                table: "Post",
                column: "ComentarioCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comentario_ComentarioCommentId",
                table: "Post",
                column: "ComentarioCommentId",
                principalTable: "Comentario",
                principalColumn: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comentario_ComentarioCommentId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ComentarioCommentId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ComentarioCommentId",
                table: "Post");
        }
    }
}
