using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Migrations
{
    public partial class Dateformatchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b76efd9a-fa8e-4f3d-9835-745fe426ce22", "AQAAAAEAACcQAAAAEMEk3O9vTwZ3vNsyr+k78/59ts1wRNCmRyxWS/MGReX3f4k8iJR+yy5J5mRsk5dgbw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9cbebb9e-fdb2-49c1-a215-d1111bb84149", "AQAAAAEAACcQAAAAEDXlwaIuAhsXALQhDpGqaoIL8o+N6dUvhmP8ILjqfy8TuXqg7zlRmbLiAsEyxwUtIA==" });
        }
    }
}
