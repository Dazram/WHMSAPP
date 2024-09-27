using Warehouse_Management_System.DataTransferObjects.DispatchDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IDispatch
    {
        Task<List<Dispatch>> GetAllAsync();
        Task<Dispatch?> GetByIdAsync(int id);
        Task<Dispatch> CreateAsync(Dispatch dispatchModel);
        Task<Dispatch?> UpdateAsync(int id, UpdateDispatchDTO dispatchDTO);
        Task<Dispatch?> DeleteAsync(int id); 
        Task<bool> DispatchExist(int id);
    }
}