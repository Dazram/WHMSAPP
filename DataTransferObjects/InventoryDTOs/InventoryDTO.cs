namespace Warehouse_Management_System.DataTransferObjects.InventoryDTOs
{
    public class InventoryDTO
    {    
        public DateTime Date { get; set; }
        public int ItemId { get; set; }
        public string? ProductName { get; set; }
        public string? Supplier { get; set; }
        public int Quantity { get; set; }
        public int PurchaseOrderId { get; set; }

    }
}