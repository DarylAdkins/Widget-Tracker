using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Data.Migrations
{
    public partial class wtsetup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Lines_LineId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_LineId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Processes");

            migrationBuilder.AddColumn<int>(
                name: "AssociatedLineId",
                table: "Processes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "52972368-cb64-449a-b791-997fc2819589", "AQAAAAEAACcQAAAAEFPKSlQBvgr5Z/GaZWGkzlH7gxeGEYtpHEmdyBiZybmGvQieKgebNZawWHgU4OaMZg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_AssociatedLineId",
                table: "Processes",
                column: "AssociatedLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Lines_AssociatedLineId",
                table: "Processes",
                column: "AssociatedLineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Lines_AssociatedLineId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_AssociatedLineId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "AssociatedLineId",
                table: "Processes");

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f06f56c4-cbfb-4fa3-9a90-f539e57193ee", "AQAAAAEAACcQAAAAEOwy0sG7ebq+Amzzui6d8leINixdk06TIZ2jCFkvgLPW6OfKvdKyPTwRXODSKIKROQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_LineId",
                table: "Processes",
                column: "LineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Lines_LineId",
                table: "Processes",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
