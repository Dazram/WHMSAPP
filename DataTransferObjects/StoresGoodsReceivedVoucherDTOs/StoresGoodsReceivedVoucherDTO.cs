namespace Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs
{
    public class StoresGoodsReceivedVoucherDTO
    {
        public DateTime Date { get; set; }
        public int GRVNumber { get; set; }
        public string? Supplier { get; set; }
        public string? ProductName { get; set; }
        public int DeliveryNoteNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int OffloadingAuthorisationNumber { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }
    }
}