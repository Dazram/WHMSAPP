using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models

{
    public class SalesOrder
    {
        public DateTime Date { get; set; }  
        [Key]
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string? Destination { get; set; }
        public string? TransactionType { get; set; }
        public float TotalAmount { get; set; }          
        public string? SoldProducts { get; set; }
        public string? SoldProduct1 { get; set; }
        public string? SoldProduct2 { get; set; }
        public string? SoldProduct3 { get; set; }
        public string? SoldProduct4 { get; set; }
        public string? SoldProduct5 { get; set; }
        public string? SoldProduct6 { get; set; }

        internal object ToSalesOrderDTO()
        {
            throw new NotImplementedException();
        }
    }
}