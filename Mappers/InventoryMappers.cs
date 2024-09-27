using Warehouse_Management_System.DataTransferObjects.InventoryDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class InventoryMappers
    {
        public static InventoryDTO ToInventoryDTO(this Inventory InventoryDTOModel)
        {
            return new InventoryDTO
            {
                Date = InventoryDTOModel.Date,
                ItemId = InventoryDTOModel.ItemId,
                ProductName = InventoryDTOModel.ProductName,
                Supplier = InventoryDTOModel.Supplier,
                Quantity = InventoryDTOModel.Quantity,
                PurchaseOrderId = InventoryDTOModel.PurchaseOrderId
            };
        }
        public static Inventory ToInventoryFromInventoryDTO(this CreateInventoryDTO inventoryDTOModel)
        {
            return new Inventory
            {
                ProductName = inventoryDTOModel.ProductName,
                Supplier = inventoryDTOModel.Supplier,
                Quantity = inventoryDTOModel.Quantity,
                PurchaseOrderId = inventoryDTOModel.PurchaseOrderId
            };
        }
    } 
}