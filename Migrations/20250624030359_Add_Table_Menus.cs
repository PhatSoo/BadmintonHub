using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadmintonHub.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_Menus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Duration",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8bca8fe0-b0d0-40b9-a5d3-5d956fa79c8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A standard badminton court designed for casual play, with basic flooring, standard lighting, and regular net setup.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgIAFwTaBOi189iF7NSxzRx7U1oI90_QsS6A&s", "Normal Court", 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70819b1-a866-41fe-8025-7776b0fd4464"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A professional-grade badminton court with premium flooring, enhanced lighting, and precise markings for competitive play.", "https://cdn.iconscout.com/icon/premium/png-256-thumb/badminton-coach-1653707-1400021.png", "Advanced Court", 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
