using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.WarehouseStockDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class WarehouseStockRepository : IWarehouseStocks
    {   
        private readonly ApplicationDBContext _context;
        public WarehouseStockRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<WarehouseStock> CreateAsync(WarehouseStock warehouseStockModel)
        {
           await _context.WarehouseStocks.AddAsync(warehouseStockModel);
           await _context.SaveChangesAsync();
           return warehouseStockModel; 
        }

        public async Task<WarehouseStock?> DeleteAsync(int id)
        {
            var warehouseStockModel = await _context.WarehouseStocks.FirstOrDefaultAsync(x => x.ProductId ==id);
            if( warehouseStockModel == null )
            {
                return null;
            }

            _context.WarehouseStocks.Remove(warehouseStockModel);
            await _context.SaveChangesAsync();
            return warehouseStockModel;
        }

        public async Task<List<WarehouseStock>> GetAllAsync()
        {
           return await _context.WarehouseStocks.ToListAsync();
        }

        public async Task<WarehouseStock?> GetByIdAsync(int id)
        {
            return await _context.WarehouseStocks.FindAsync(id);
        }

        public async Task<WarehouseStock?> UpdateAsync(int id, UpdateWarehouseStockDTO warehouseStockDTO)
        {
            var warehouseStockModel = await _context.WarehouseStocks.FirstOrDefaultAsync(x => x.ProductId ==id);
            if( warehouseStockModel == null )
            {
                return null;
            }

            warehouseStockModel.ProductName = warehouseStockDTO.ProductName;
            warehouseStockModel.OpeningBalance = warehouseStockDTO.OpeningBalance;
            warehouseStockModel.Production = warehouseStockDTO.Production;
            warehouseStockModel.SalesDispatch = warehouseStockDTO.SalesDispatch;
            warehouseStockModel.Samples = warehouseStockDTO.Samples;
            warehouseStockModel.Returns = warehouseStockDTO.Returns;

            await _context.SaveChangesAsync();
            return warehouseStockModel;
        }

        public Task<bool> WareHouseStockExist(int Id)
        {
            return _context.WarehouseStocks.AnyAsync(s => s.ProductId == Id);
        }
    }
}