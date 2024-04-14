using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class dkjdnffffffkolil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comentario_ComentarioCommentId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ComentarioCommentId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "ComentarioCommentId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comentario",
                newName: "PerfilId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Perfil_PerfilId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PerfilId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "PerfilId",
                table: "Comentario",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ComentarioCommentId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comentario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ComentarioCommentId",
                table: "Post",
                column: "ComentarioCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PostId",
                table: "Comentario",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Post_PostId",
                table: "Comentario",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comentario_ComentarioCommentId",
                table: "Post",
                column: "ComentarioCommentId",
                principalTable: "Comentario",
                principalColumn: "CommentId");
        }
    }
}
