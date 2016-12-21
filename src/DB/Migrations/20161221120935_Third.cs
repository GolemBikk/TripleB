using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Messages",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Messages",
                newName: "type");
        }
    }
}
