using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Messages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Messages");
        }
    }
}
