using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonHub.Migrations
{
    /// <inheritdoc />
    public partial class Update_Info_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Infos",
                keyColumn: "Id",
                keyValue: new Guid("103dfd14-502c-49b9-84c2-888b99e1f2f4"),
                column: "Description",
                value: "Badminton Hub is your ultimate destination for badminton enthusiasts! We offer easy online court booking so you can secure your playtime hassle-free. Whether you're a beginner or a pro, you can also hire professional coaches to improve your skills and enjoy personalized training sessions. Experience top-quality facilities and expert guidance all in one place at Badminton Hub!");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Infos");
        }
    }
}
