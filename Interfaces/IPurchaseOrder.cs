using Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IPurchaseOrder
    {
        Task<List<PurchaseOrder>> GetAllAsync();
        Task<PurchaseOrder?> GetByIdAsync(int id);
        Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrderModel);
        Task<PurchaseOrder?> UpdateAsync(int id, UpdatePurchaseOrderDTO purchaseOrderDTO);
        Task<PurchaseOrder?> DeleteAsync(int id); 
    }
}