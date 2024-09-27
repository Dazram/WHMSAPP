using Warehouse_Management_System.DataTransferObjects.PurchaseRequisitionDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class PurchaseRequisitionMappers
    {
        public static PurchaseRequisitionDTO ToPurchaseRequisitionDTO(this PurchaseRequisition purchaseRequisitionDTOModel)
        {
            return new PurchaseRequisitionDTO
            {
                Date = purchaseRequisitionDTOModel.Date,
                RequisitionId = purchaseRequisitionDTOModel.RequisitionId,
                EmployeeName = purchaseRequisitionDTOModel.EmployeeName,
                Department = purchaseRequisitionDTOModel.Department,
                PurposeOfPurchase = purchaseRequisitionDTOModel.PurposeOfPurchase,
                ProductName = purchaseRequisitionDTOModel.ProductName,
                ProductQuantity = purchaseRequisitionDTOModel.ProductQuantity1,
                ProductName1 = purchaseRequisitionDTOModel.ProductName1,
                ProductQuantity1 = purchaseRequisitionDTOModel.ProductQuantity1,
                ProductName2 = purchaseRequisitionDTOModel.ProductName2,
                ProductQuantity2 = purchaseRequisitionDTOModel.ProductQuantity2,
                ProductName3 = purchaseRequisitionDTOModel.ProductName3,
                ProductQuantity3 = purchaseRequisitionDTOModel.ProductQuantity3,
                ProductName4 = purchaseRequisitionDTOModel.ProductName4,
                ProductQuantity4 = purchaseRequisitionDTOModel.ProductQuantity4,
                ProductName5 = purchaseRequisitionDTOModel.ProductName5,
                ProductQuantity5 = purchaseRequisitionDTOModel.ProductQuantity5
            };
        }

        public static PurchaseRequisition ToPurchaseRequisitionFromPurchaseRequisitionDTO(this CreatePurchaseRequisitionDTO purchaseRequisitionDTOModel)
        {
            return new PurchaseRequisition
            {
                EmployeeName = purchaseRequisitionDTOModel.EmployeeName,
                Department = purchaseRequisitionDTOModel.Department,
                PurposeOfPurchase = purchaseRequisitionDTOModel.PurposeOfPurchase,
                ProductName = purchaseRequisitionDTOModel.ProductName,
                ProductQuantity = purchaseRequisitionDTOModel.ProductQuantity1,
                ProductName1 = purchaseRequisitionDTOModel.ProductName1,
                ProductQuantity1 = purchaseRequisitionDTOModel.ProductQuantity1,
                ProductName2 = purchaseRequisitionDTOModel.ProductName2,
                ProductQuantity2 = purchaseRequisitionDTOModel.ProductQuantity2,
                ProductName3 = purchaseRequisitionDTOModel.ProductName3,
                ProductQuantity3 = purchaseRequisitionDTOModel.ProductQuantity3,
                ProductName4 = purchaseRequisitionDTOModel.ProductName4,
                ProductQuantity4 = purchaseRequisitionDTOModel.ProductQuantity4,
                ProductName5 = purchaseRequisitionDTOModel.ProductName5,
                ProductQuantity5 = purchaseRequisitionDTOModel.ProductQuantity5
            };
        }
    }
}