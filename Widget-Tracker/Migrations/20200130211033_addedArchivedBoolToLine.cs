using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Migrations
{
    public partial class addedArchivedBoolToLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Lines",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f343eda7-5c64-4303-b508-57f9cafbc19f", "AQAAAAEAACcQAAAAELof3yN7xdOPip80FXUMkNhGceYOPQpEQX6QNU5qduE5CpY+CED+M1BKxkt6wQFpOg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Lines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b67f84ab-c9ca-4935-a715-956745f8e362", "AQAAAAEAACcQAAAAEF6o1SY5gkSJpZ2arzwfUcYDVWG0e7GBQLKTeNJWCEk1ZmV4Nw5h7x/av3m3UwhZww==" });
        }
    }
}
