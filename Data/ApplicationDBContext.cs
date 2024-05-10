using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Models;


namespace Warehouse_Management_System.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbcontextoptions) : base(dbcontextoptions)
        {
            
        }
        public DbSet <DepartmentMaterialRequisition> DepartmentMaterialRequisitions { get; set; }
        public DbSet <Dispatch> Dispatchs { get; set; }
        public DbSet <Inventory> Inventories { get; set; }
        public DbSet <PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet <PurchaseRequisition> PurchaseRequisitions { get; set; }
        public DbSet <SalesOrder> SalesOrders { get; set; }
        public DbSet <WarehouseStock> WarehouseStocks { get; set; }
        public DbSet <StoresGoodsReceivedVoucher> StoresGoodsReceivedVouchers { get; set; }
        public DbSet <StoresIssueSlip> StoresIssueSlips { get; set; }

    }

}

