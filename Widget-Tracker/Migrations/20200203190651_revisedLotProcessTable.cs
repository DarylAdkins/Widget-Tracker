using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Migrations
{
    public partial class revisedLotProcessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "LotProcesses",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeIn",
                table: "LotProcesses",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9cbebb9e-fdb2-49c1-a215-d1111bb84149", "AQAAAAEAACcQAAAAEDXlwaIuAhsXALQhDpGqaoIL8o+N6dUvhmP8ILjqfy8TuXqg7zlRmbLiAsEyxwUtIA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOut",
                table: "LotProcesses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeIn",
                table: "LotProcesses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f343eda7-5c64-4303-b508-57f9cafbc19f", "AQAAAAEAACcQAAAAELof3yN7xdOPip80FXUMkNhGceYOPQpEQX6QNU5qduE5CpY+CED+M1BKxkt6wQFpOg==" });
        }
    }
}
