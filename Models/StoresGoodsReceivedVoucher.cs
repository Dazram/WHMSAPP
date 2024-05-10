using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models
{
    public class StoresGoodsReceivedVoucher
    {
        public DateTime Date { get; set; }
        [Key]
        public int GRVNumber { get; set; }
        public string? Supplier { get; set; }
        public string? ProductName { get; set; }
        public int InvoiceNumber { get; set; }  
        public int DeliveryNoteNumber { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int OffloadingAuthorisationNumber { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }

        internal object ToStoresGoodsReceivedVoucherDTO()
        {
            throw new NotImplementedException();
        }
    }
}
