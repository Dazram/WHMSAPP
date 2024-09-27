namespace Warehouse_Management_System.DataTransferObjects.InventoryDTOs
{
    public class CreateInventoryDTO
    {
        public string? ProductName { get; set; }
        public string? Supplier { get; set; }
        public int Quantity { get; set; }
        public int PurchaseOrderId { get; set; }
    }
}