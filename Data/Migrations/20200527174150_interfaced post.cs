using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorJob.Data.Migrations
{
    public partial class interfacedpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "parent",
                table: "posts",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "author",
                table: "posts",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<long>(
                name: "Category",
                table: "posts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "posts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "posts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "posts",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Tags",
                table: "posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "posts");

            migrationBuilder.AlterColumn<int>(
                name: "parent",
                table: "posts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "author",
                table: "posts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "posts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
