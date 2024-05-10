using System.ComponentModel.DataAnnotations;

namespace Warehouse_Management_System.Models
{
    public class DepartmentMaterialRequisition
    {
        public DateTime Date { get; set; }
        [Key]
        public int DMRId { get; set; }
        public string? DepartmentName { get; set; }
        public string? RequestorFirstName { get; set; }
        public string? RequestorLastName { get; set; }
        public string? RequestedItem { get; set; }
        public string? RequestedItem1 { get; set; }
        public string? RequestedItem2 { get; set; }
        public string? RequestedItem3 { get; set; }
        public string? RequestedItem4 { get; set; }
        public string? RequestedItem5 { get; set; }

    }
}
