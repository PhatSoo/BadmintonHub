using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BadmintonHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bookings",
                newName: "GuestName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuestName",
                table: "Bookings",
                newName: "Name");
        }
    }
}
