using Warehouse_Management_System.DataTransferObjects.SalesOrderDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface ISalesOrder
    {
        Task<List<SalesOrder>> GetAllAsync();
        Task<SalesOrder?> GetByIdAsync(int id);
        Task<SalesOrder> CreateAsync(SalesOrder salesOrderModel);
        Task<SalesOrder?> UpdateAsync(int id, UpdateSalesOrderDTO salesOrderDTO);
        Task<SalesOrder?> DeleteAsync(int id); 
    }
}