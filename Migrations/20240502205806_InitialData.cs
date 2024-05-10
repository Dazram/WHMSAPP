using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentMaterialRequisitions",
                columns: table => new
                {
                    DMRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestorLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedItem5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMaterialRequisitions", x => x.DMRId);
                });

            migrationBuilder.CreateTable(
                name: "Dispatchs",
                columns: table => new
                {
                    DispatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDispatched = table.Column<int>(type: "int", nullable: false),
                    ProductName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDispatched1 = table.Column<int>(type: "int", nullable: false),
                    ProductName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDispatched2 = table.Column<int>(type: "int", nullable: false),
                    ProductName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityDispatched3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatchs", x => x.DispatchId);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseRequisitionId = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goods_service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Goods_service1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity1 = table.Column<int>(type: "int", nullable: false),
                    Goods_service2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity2 = table.Column<int>(type: "int", nullable: false),
                    Goods_service3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity3 = table.Column<int>(type: "int", nullable: false),
                    Goods_service4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity4 = table.Column<int>(type: "int", nullable: false),
                    Goods_service5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity5 = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    Vat = table.Column<float>(type: "real", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitions",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurposeOfPurchase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity1 = table.Column<int>(type: "int", nullable: false),
                    ProductName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity2 = table.Column<int>(type: "int", nullable: false),
                    ProductName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity3 = table.Column<int>(type: "int", nullable: false),
                    ProductName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity4 = table.Column<int>(type: "int", nullable: false),
                    ProductName5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitions", x => x.RequisitionId);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<float>(type: "real", nullable: false),
                    SoldProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoldProduct6 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "StoresGoodsReceivedVouchers",
                columns: table => new
                {
                    GRVNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    DeliveryNoteNumber = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffloadingAuthorisationNumber = table.Column<int>(type: "int", nullable: false),
                    DriverFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoresGoodsReceivedVouchers", x => x.GRVNumber);
                });

            migrationBuilder.CreateTable(
                name: "StoresIssueSlips",
                columns: table => new
                {
                    IssueNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestorLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoresIssueSlips", x => x.IssueNumber);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseStocks",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningBalance = table.Column<int>(type: "int", nullable: false),
                    Production = table.Column<int>(type: "int", nullable: false),
                    SalesDispatch = table.Column<int>(type: "int", nullable: false),
                    Samples = table.Column<int>(type: "int", nullable: false),
                    Returns = table.Column<int>(type: "int", nullable: false),
                    ClosingBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseStocks", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentMaterialRequisitions");

            migrationBuilder.DropTable(
                name: "Dispatchs");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitions");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "StoresGoodsReceivedVouchers");

            migrationBuilder.DropTable(
                name: "StoresIssueSlips");

            migrationBuilder.DropTable(
                name: "WarehouseStocks");
        }
    }
}
