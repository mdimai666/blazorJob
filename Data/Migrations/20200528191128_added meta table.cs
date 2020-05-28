using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazorJob.Data.Migrations
{
    public partial class addedmetatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meta",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    created_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    author = table.Column<long>(nullable: false),
                    status = table.Column<string>(nullable: true, defaultValue: ""),
                    type = table.Column<string>(nullable: true, defaultValue: ""),
                    value = table.Column<string>(nullable: false),
                    key = table.Column<string>(nullable: false),
                    updated_date = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    post_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meta", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meta");
        }
    }
}
