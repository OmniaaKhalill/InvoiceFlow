using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class itemCountFromDoubleToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ItemCount",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 2L,
                column: "ItemCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 3L,
                column: "ItemCount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 4L,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 6L,
                column: "ItemCount",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ItemCount",
                table: "InvoiceDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 2L,
                column: "ItemCount",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 3L,
                column: "ItemCount",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 4L,
                column: "ItemCount",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 6L,
                column: "ItemCount",
                value: 1.0);
        }
    }
}
