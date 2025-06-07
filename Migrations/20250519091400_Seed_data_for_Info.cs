using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonHub.Migrations
{
    /// <inheritdoc />
    public partial class Seed_data_for_Info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Infos",
                columns: new[] { "Id", "Address", "Email", "Name", "Phone", "WorkingTime" },
                values: new object[] { new Guid("103dfd14-502c-49b9-84c2-888b99e1f2f4"), "Đại lộ Bình Dương, Thủ Dầu Một, Bình Dương", "abc@gmail.com", "Badminton Hub", "0123456789", "8:00 - 22:00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Infos",
                keyColumn: "Id",
                keyValue: new Guid("103dfd14-502c-49b9-84c2-888b99e1f2f4"));
        }
    }
}
