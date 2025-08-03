using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "InvoiceHeaders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "ItemID",
                table: "InvoiceDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 2L,
                column: "ItemID",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 3L,
                column: "ItemID",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 4L,
                column: "ItemID",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 6L,
                column: "ItemID",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "InvoiceHeaders",
                keyColumn: "ID",
                keyValue: 2L,
                column: "TotalPrice",
                value: 150.0);

            migrationBuilder.UpdateData(
                table: "InvoiceHeaders",
                keyColumn: "ID",
                keyValue: 3L,
                column: "TotalPrice",
                value: 5.0);

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ID", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, false, "بيبسي 1 لتر", 20.0 },
                    { 2L, false, "ساندوتش برجر", 50.0 },
                    { 3L, false, "ايس كريم", 10.0 },
                    { 4L, false, "سفن اب كانز", 5.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ItemID",
                table: "InvoiceDetails",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Item_ItemID",
                table: "InvoiceDetails",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Item_ItemID",
                table: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ItemID",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ItemPrice",
                table: "InvoiceDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "ItemName", "ItemPrice" },
                values: new object[] { "بيبسي 1 لتر", 20.0 });

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "ItemName", "ItemPrice" },
                values: new object[] { "ساندوتش برجر", 50.0 });

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 4L,
                columns: new[] { "ItemName", "ItemPrice" },
                values: new object[] { "ايس كريم", 10.0 });

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "ID",
                keyValue: 6L,
                columns: new[] { "ItemName", "ItemPrice" },
                values: new object[] { "سفن اب كانز", 5.0 });
        }
    }
}
