using Warehouse_Management_System.DataTransferObjects.WarehouseStockDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IWarehouseStocks
    {
        Task<List<WarehouseStock>> GetAllAsync();
        Task<WarehouseStock?> GetByIdAsync(int id);
        Task<WarehouseStock> CreateAsync(WarehouseStock warehouseStockModel);
        Task<WarehouseStock?> UpdateAsync(int id, UpdateWarehouseStockDTO warehouseStockDTO);
        Task<WarehouseStock?> DeleteAsync(int id); 
        Task<bool> WareHouseStockExist(int Id);
    }
}