using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models
{
    public class Dispatch
    {   
        public DateTime DispatchDate { get; set; }
        [Key]
        public int DispatchId { get; set; }
        public int SalesOrderNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }
        public int QuantityDispatched { get; set; }
        public string? ProductName1 { get; set; }
        public int QuantityDispatched1 { get; set; }
        public string? ProductName2 { get; set; }
        public int QuantityDispatched2 { get; set; }
        public string? ProductName3 { get; set; }
        public int QuantityDispatched3 { get; set; }
    }
}