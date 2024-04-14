using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedeSocialAT.Data.Migrations
{
    public partial class mkdsjs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Post",
                newName: "Id");
        }
    }
}
