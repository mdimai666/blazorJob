using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorJob.Data.Migrations
{
    public partial class updpostsaswp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "text",
                table: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<int>(
                name: "author",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "posts",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "parent",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "posts",
                nullable: true,
                defaultValue: "draft");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "posts",
                nullable: true,
                defaultValue: "post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "author",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "content",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "parent",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "type",
                table: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "posts",
                type: "text",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "posts",
                type: "text",
                nullable: true,
                defaultValueSql: "0");
        }
    }
}
