using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Data.Migrations
{
    public partial class wtsetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Processes",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f06f56c4-cbfb-4fa3-9a90-f539e57193ee", "AQAAAAEAACcQAAAAEOwy0sG7ebq+Amzzui6d8leINixdk06TIZ2jCFkvgLPW6OfKvdKyPTwRXODSKIKROQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Processes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "873166fd-2d0f-4742-971e-12f01d6f0100", "AQAAAAEAACcQAAAAENS9d3AV/X8ZHb/KgQ4B3JBQeI23y3giyWueoBeaG+GDDylTj/quO+oqKY/oSc/nww==" });
        }
    }
}
