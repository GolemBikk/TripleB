using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DB.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "BoatModels");

            migrationBuilder.DropTable(
                name: "Recalls");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoatId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FromId = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(nullable: false),
                    RecallId = table.Column<int>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                });

            migrationBuilder.AddColumn<int>(
                name: "Displacement",
                table: "BoatModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Kind",
                table: "Boats",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "BoatModels",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "BoatModels",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Displacement",
                table: "BoatModels");

            migrationBuilder.DropColumn(
                name: "Kind",
                table: "Boats");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.CreateTable(
                name: "Recalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoatId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recalls", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "BoatModels",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Width",
                table: "BoatModels",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "BoatModels",
                nullable: true);
        }
    }
}
