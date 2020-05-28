using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorJob.Data.Migrations
{
    public partial class extfieldspost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "posts",
                newName: "tags");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "posts",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "posts",
                newName: "guid");

            migrationBuilder.RenameColumn(
                name: "Excerpt",
                table: "posts",
                newName: "excerpt");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "posts",
                newName: "category");

            migrationBuilder.AlterColumn<string>(
                name: "excerpt",
                table: "posts",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "category",
                table: "posts",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tags",
                table: "posts",
                newName: "Tags");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "posts",
                newName: "Slug");

            migrationBuilder.RenameColumn(
                name: "guid",
                table: "posts",
                newName: "Guid");

            migrationBuilder.RenameColumn(
                name: "excerpt",
                table: "posts",
                newName: "Excerpt");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "posts",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Excerpt",
                table: "posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "Category",
                table: "posts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldDefaultValue: 0L);
        }
    }
}
