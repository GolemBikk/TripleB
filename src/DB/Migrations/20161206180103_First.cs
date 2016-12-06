using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_BoatModels_ModelId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Boats_Accounts_OwnerId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Recalls_Boats_BoatId",
                table: "Recalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Recalls_Accounts_ClientId",
                table: "Recalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Boats_BoatId",
                table: "Rent");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Accounts_ClientId",
                table: "Rent");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_BoatModels_ModelId",
                table: "Boats",
                column: "ModelId",
                principalTable: "BoatModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_Accounts_OwnerId",
                table: "Boats",
                column: "OwnerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recalls_Boats_BoatId",
                table: "Recalls",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recalls_Accounts_ClientId",
                table: "Recalls",
                column: "ClientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Boats_BoatId",
                table: "Rent",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Accounts_ClientId",
                table: "Rent",
                column: "ClientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_BoatModels_ModelId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Boats_Accounts_OwnerId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Recalls_Boats_BoatId",
                table: "Recalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Recalls_Accounts_ClientId",
                table: "Recalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Boats_BoatId",
                table: "Rent");

            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Accounts_ClientId",
                table: "Rent");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_BoatModels_ModelId",
                table: "Boats",
                column: "ModelId",
                principalTable: "BoatModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_Accounts_OwnerId",
                table: "Boats",
                column: "OwnerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recalls_Boats_BoatId",
                table: "Recalls",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recalls_Accounts_ClientId",
                table: "Recalls",
                column: "ClientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Boats_BoatId",
                table: "Rent",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Accounts_ClientId",
                table: "Rent",
                column: "ClientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
