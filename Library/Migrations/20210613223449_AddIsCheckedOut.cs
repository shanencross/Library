﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AddIsCheckedOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "Copies",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "Copies");
        }
    }
}
