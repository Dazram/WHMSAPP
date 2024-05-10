namespace Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs
{
    public class StoresIssueSlipDTO
    {
        public DateTime Date { get; set; }
        public int IssueNumber { get; set; }
        public string? RequestorFirstName { get; set; }
        public string? RequestorLastName { get; set; }
        public string? Department { get; set; }
        public string? Item { get; set; }
        public string? Quantity { get; set; }
        public string? Purpose { get; set; }
    }
}