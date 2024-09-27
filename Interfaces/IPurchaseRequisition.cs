using Warehouse_Management_System.DataTransferObjects.PurchaseRequisitionDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IPurchaseRequisition
    {
        Task<List<PurchaseRequisition>> GetAllAsync();
        Task<PurchaseRequisition?> GetByIdAsync(int id);
        Task<PurchaseRequisition> CreateAsync(PurchaseRequisition purchaseRequisitionModel);
        Task<PurchaseRequisition?> UpdateAsync(int id, UpdatePurchaseRequisionDTO purchaseRequisitionDTO);
        Task<PurchaseRequisition?> DeleteAsync(int id); 
    }
}