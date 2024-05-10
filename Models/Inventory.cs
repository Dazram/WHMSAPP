using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models
{
    public class Inventory 
    {
        public DateTime Date { get; set; }
        [Key]
        public int ItemId { get; set; }
        public string? ProductName { get; set; }
        public string? Supplier { get; set; }
        public int Quantity { get; set; }  
        public int PurchaseOrderId { get; set; }

    }
}

