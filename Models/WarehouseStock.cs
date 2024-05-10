using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models
{   
    public class WarehouseStock
    {   
        public DateTime Date { get; set; }   
        [Key]       
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int OpeningBalance { get; set; }
        public int Production { get; set; }
        public int SalesDispatch { get; set; }
        public int Samples { get; set; }
        public int Returns { get; set; }
        public int ClosingBalance { get; set; }

    }
    

}
