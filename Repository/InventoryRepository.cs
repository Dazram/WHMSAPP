using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.InventoryDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class InventoryRepository : IInventoryRepository
    {   
        private readonly ApplicationDBContext _context;
        public InventoryRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Inventory> CreateAsync(Inventory inventoryModel)
        {
            await _context.Inventories.AddAsync(inventoryModel);
            await _context.SaveChangesAsync();
            return inventoryModel;
        }

        public async Task<Inventory?> DeleteAsync(int id)
        {
            var inventoryModel = await _context.Inventories.FirstOrDefaultAsync(x => x.ItemId == id);

            if( inventoryModel == null )
            {
                return null;
            }

            _context.Inventories.Remove(inventoryModel);
            await _context.SaveChangesAsync();
            return inventoryModel;
        }

        public async Task<List<Inventory>> GetAllAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<Inventory?> UpdateAsync(int id, UpdateInventoryDTO inventoryDTO)
        {
            var inventoryModel = await _context.Inventories.FirstOrDefaultAsync(x => x.ItemId == id);
            
            if (inventoryModel == null)
            {
                return null;
            }

            inventoryModel.ProductName = inventoryDTO.ProductName;
            inventoryModel.Supplier = inventoryDTO.Supplier;
            inventoryModel.Quantity = inventoryDTO.Quantity;
            inventoryModel.PurchaseOrderId = inventoryDTO.PurchaseOrderId;

            await _context.SaveChangesAsync();
            return inventoryModel;
        }
    }
}