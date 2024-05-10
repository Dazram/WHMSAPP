using Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class PurchaseOrderMappers
    {
        public static PurchaseOrderDTO ToPurchaseOrderDTO(this PurchaseOrder purchaseOrderDTOModel)
        {
            return new PurchaseOrderDTO
            {
                    SupplierName = purchaseOrderDTOModel.SupplierName,
                    SupplierAddress = purchaseOrderDTOModel.SupplierAddress,
                    ContactDetails = purchaseOrderDTOModel.ContactDetails,
                    TransactionType = purchaseOrderDTOModel.TransactionType,
                    Goods_service = purchaseOrderDTOModel.Goods_service,
                    Quantity = purchaseOrderDTOModel.Quantity,
                    Goods_service1 = purchaseOrderDTOModel.Goods_service1,
                    Quantity1 = purchaseOrderDTOModel.Quantity1,
                    Goods_service2 = purchaseOrderDTOModel.Goods_service2,
                    Quantity2 = purchaseOrderDTOModel.Quantity2,
                    Goods_service3 = purchaseOrderDTOModel.Goods_service3,
                    Quantity3 = purchaseOrderDTOModel.Quantity3,
                    Goods_service4 = purchaseOrderDTOModel.Goods_service4,
                    Quantity4 = purchaseOrderDTOModel.Quantity4,
                    Goods_service5 = purchaseOrderDTOModel.Goods_service5,
                    Quantity5 = purchaseOrderDTOModel.Quantity5,
                    Discount = purchaseOrderDTOModel.Discount,
                    Vat = purchaseOrderDTOModel.Vat,
                    TotalAmount = purchaseOrderDTOModel.TotalAmount
            };
        }

        public static PurchaseOrder ToPurchaseOrderFromPurchaseOrderDTO(this CreatePurchaseOrderDTO purchaseOrderDTOModel)
        {
            return new PurchaseOrder
            {
                    SupplierName = purchaseOrderDTOModel.SupplierName,
                    SupplierAddress = purchaseOrderDTOModel.SupplierAddress,
                    ContactDetails = purchaseOrderDTOModel.ContactDetails,
                    TransactionType = purchaseOrderDTOModel.TransactionType,
                    Goods_service = purchaseOrderDTOModel.Goods_service,
                    Quantity = purchaseOrderDTOModel.Quantity,
                    Goods_service1 = purchaseOrderDTOModel.Goods_service1,
                    Quantity1 = purchaseOrderDTOModel.Quantity1,
                    Goods_service2 = purchaseOrderDTOModel.Goods_service2,
                    Quantity2 = purchaseOrderDTOModel.Quantity2,
                    Goods_service3 = purchaseOrderDTOModel.Goods_service3,
                    Quantity3 = purchaseOrderDTOModel.Quantity3,
                    Goods_service4 = purchaseOrderDTOModel.Goods_service4,
                    Quantity4 = purchaseOrderDTOModel.Quantity4,
                    Goods_service5 = purchaseOrderDTOModel.Goods_service5,
                    Quantity5 = purchaseOrderDTOModel.Quantity5,
                    Discount = purchaseOrderDTOModel.Discount,
                    Vat = purchaseOrderDTOModel.Vat,
                    TotalAmount = purchaseOrderDTOModel.TotalAmount
            };
        }
    }
}