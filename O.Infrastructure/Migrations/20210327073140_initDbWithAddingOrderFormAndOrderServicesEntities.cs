using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace O.Infrastructure.Migrations
{
    public partial class initDbWithAddingOrderFormAndOrderServicesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCarryOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderFormId = table.Column<int>(type: "int", nullable: false),
                    ServicesEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderServices_Orders_OrderFormId",
                        column: x => x.OrderFormId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_OrderFormId",
                table: "OrderServices",
                column: "OrderFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServices");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
