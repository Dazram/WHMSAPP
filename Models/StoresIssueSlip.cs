using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Warehouse_Management_System.Models
{
    public class StoresIssueSlip 
    {

        public DateTime Date { get; set; }
        [Key]
        public int IssueNumber { get; set; }
        public string? RequestorFirstName { get; set; }
        public string? RequestorLastName { get; set; }
        public string? Department { get; set; }
        public string? Item { get; set; }
        public string? Quantity { get; set; }
        public string? Purpose { get; set; }
        
    }
}

