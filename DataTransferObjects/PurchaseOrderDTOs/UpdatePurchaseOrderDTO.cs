namespace Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs
{
    public class UpdatePurchaseOrderDTO
    {
        public string? SupplierName { get; set; }
        public string? SupplierAddress { get; set; }
        public string? ContactDetails { get; set; }
        public string? TransactionType { get; set; }
        public string? Goods_service { get; set; }
        public int Quantity { get; set; }
        public string? Goods_service1 { get; set; }
        public int Quantity1 { get; set; }
        public string? Goods_service2 { get; set; }
        public int Quantity2 { get; set; }
        public string? Goods_service3 { get; set; }
        public int Quantity3 { get; set; }
        public string? Goods_service4 { get; set; }
        public int Quantity4 { get; set; }
        public string? Goods_service5 { get; set; }
        public int Quantity5 { get; set; }
        public float Discount { get; set; }
        public float Vat { get; set; }
        public float TotalAmount { get; set; }
    }
}