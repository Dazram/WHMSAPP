using Warehouse_Management_System.DataTransferObjects.InventoryDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IInventory

    {
        Task<List<Inventory>> GetAllAsync();
        Task<Inventory?> GetByIdAsync(int id);
        Task<Inventory> CreateAsync(Inventory inventoryModel);
        Task<Inventory?> UpdateAsync(int id, UpdateInventoryDTO inventoryDTO);
        Task<Inventory?> DeleteAsync(int id); 
    }
}