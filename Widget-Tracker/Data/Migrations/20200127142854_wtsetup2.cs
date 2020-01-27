using Microsoft.EntityFrameworkCore.Migrations;

namespace Widget_Tracker.Data.Migrations
{
    public partial class wtsetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Lines_AssociatedLineId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_AspNetUsers_UserId",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_AssociatedLineId",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_UserId",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "AssociatedLineId",
                table: "Lots");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Lots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "Lots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Lots",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Lines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "873166fd-2d0f-4742-971e-12f01d6f0100", "AQAAAAEAACcQAAAAENS9d3AV/X8ZHb/KgQ4B3JBQeI23y3giyWueoBeaG+GDDylTj/quO+oqKY/oSc/nww==" });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LineId",
                table: "Lots",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_UserId1",
                table: "Lots",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Lines_LineId",
                table: "Lots",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_AspNetUsers_UserId1",
                table: "Lots",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Lines_LineId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_AspNetUsers_UserId1",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_LineId",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_UserId1",
                table: "Lots");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Lots");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Lots",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LineId",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AssociatedLineId",
                table: "Lots",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Lines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "311b6c90-e480-41b9-83e4-31800cebeaf7", "AQAAAAEAACcQAAAAEExM2JZwiDnSjnEq5NmWcvrg8rLrTxLQN4WjB4IiuIxa+6PjYCPcM+tH/1C9fh5JPg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_AssociatedLineId",
                table: "Lots",
                column: "AssociatedLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_UserId",
                table: "Lots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Lines_AssociatedLineId",
                table: "Lots",
                column: "AssociatedLineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_AspNetUsers_UserId",
                table: "Lots",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
