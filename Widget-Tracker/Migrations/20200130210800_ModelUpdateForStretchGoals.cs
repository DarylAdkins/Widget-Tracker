using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Migrations
{
    public partial class ModelUpdateForStretchGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Lots",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b67f84ab-c9ca-4935-a715-956745f8e362", "AQAAAAEAACcQAAAAEF6o1SY5gkSJpZ2arzwfUcYDVWG0e7GBQLKTeNJWCEk1ZmV4Nw5h7x/av3m3UwhZww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Lots",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "003fb69b-a137-4d45-a457-c0fddb524ead", "AQAAAAEAACcQAAAAEIDmUnk64+yKUIuySKp1IvuGU64lfDrC8RJy82sKUTs1pDZANGcN+4HB7GmceMZtlQ==" });
        }
    }
}
