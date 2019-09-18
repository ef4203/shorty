﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shorty.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shorthands",
                columns: table => new
                {
                    URL = table.Column<string>(nullable: false),
                    Destination = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shorthands", x => x.URL);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shorthands");
        }
    }
}
