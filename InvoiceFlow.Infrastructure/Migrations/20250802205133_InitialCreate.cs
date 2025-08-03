using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cashiers_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeaders",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoicedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashierID = table.Column<long>(type: "bigint", nullable: true),
                    BranchID = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeaders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceHeaders_Cashiers_CashierID",
                        column: x => x.CashierID,
                        principalTable: "Cashiers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceHeaderID = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCount = table.Column<double>(type: "float", nullable: false),
                    ItemPrice = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderID",
                        column: x => x.InvoiceHeaderID,
                        principalTable: "InvoiceHeaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName", "IsDeleted" },
                values: new object[,]
                {
                    { 1L, "القاهرة - مدينة نصر", false },
                    { 2L, "القاهرة - القاهرة الجديدة ", false },
                    { 3L, "القاهرة - الشروق ", false },
                    { 4L, "القاهرة - العبور ", false },
                    { 5L, "الاسكندرية - سموحة", false }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "BranchName", "CityID", "IsDeleted" },
                values: new object[,]
                {
                    { 1L, "فرع العبور", 4L, false },
                    { 2L, "فرع الحي السابع", 1L, false },
                    { 3L, "فرع عباس العقاد", 1L, false },
                    { 4L, "فرع التجمع الاول", 2L, false },
                    { 5L, "فرع سموحه", 5L, false },
                    { 6L, "فرع الشروق", 3L, false }
                });

            migrationBuilder.InsertData(
                table: "Cashiers",
                columns: new[] { "ID", "BranchID", "CashierName", "IsDeleted" },
                values: new object[,]
                {
                    { 1L, 2L, "محمد احمد", false },
                    { 2L, 3L, "محمود احمد ", false },
                    { 3L, 2L, "مصطفي عبد السميع", false },
                    { 4L, 6L, "احمد عبد الرحمن", false },
                    { 5L, 4L, "ساره عبد الله", false },
                    { 6L, 1L, "ساره محمد ", false }
                });

            migrationBuilder.InsertData(
                table: "InvoiceHeaders",
                columns: new[] { "ID", "BranchID", "CashierID", "CustomerName", "Invoicedate", "IsDeleted" },
                values: new object[,]
                {
                    { 2L, 2L, 1L, "محمد عبد الله", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3L, 3L, 2L, "محمود احمد", new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "ID", "InvoiceHeaderID", "IsDeleted", "ItemCount", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 2L, 2L, false, 2.0, "بيبسي 1 لتر", 20.0 },
                    { 3L, 2L, false, 2.0, "ساندوتش برجر", 50.0 },
                    { 4L, 2L, false, 1.0, "ايس كريم", 10.0 },
                    { 6L, 3L, false, 1.0, "سفن اب كانز", 5.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityID",
                table: "Branches",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_BranchID",
                table: "Cashiers",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderID",
                table: "InvoiceDetails",
                column: "InvoiceHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_BranchID",
                table: "InvoiceHeaders",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaders_CashierID",
                table: "InvoiceHeaders",
                column: "CashierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceHeaders");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
