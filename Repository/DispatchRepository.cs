using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.DispatchDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class DispatchRepository : IDispatch
    {   
        private readonly ApplicationDBContext _context;
        public DispatchRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> DispatchExist(int id)
        {
            return _context.Dispatchs.AnyAsync(s => s.DispatchId == id);
        }

        public async Task<Dispatch> CreateAsync(Dispatch dispatchModel)
        {
           await _context.Dispatchs.AddAsync(dispatchModel);
           await _context.SaveChangesAsync();
           return dispatchModel; 
        }

        public async Task<Dispatch?> DeleteAsync(int id)
        {
            var dispatchModel = await _context.Dispatchs.FirstOrDefaultAsync(x => x.DispatchId ==id);
            if( dispatchModel == null )
            {
                return null;
            }

            _context.Dispatchs.Remove(dispatchModel);
            await _context.SaveChangesAsync();
            return dispatchModel;
        }

        public async Task<List<Dispatch>> GetAllAsync()
        {
           return await _context.Dispatchs.ToListAsync();
        }

        public async Task<Dispatch?> GetByIdAsync(int id)
        {
            return await _context.Dispatchs.FindAsync(id);
        }

        public async Task<Dispatch?> UpdateAsync(int id, UpdateDispatchDTO dispatchDTO)
        {
            var dispatchModel = await _context.Dispatchs.FirstOrDefaultAsync(x => x.DispatchId ==id);
            if( dispatchModel == null )
            {
                return null;
            }

            dispatchModel.CustomerName = dispatchDTO.CustomerName;
            dispatchModel.ProductName = dispatchDTO.ProductName;
            dispatchModel.QuantityDispatched = dispatchDTO.QuantityDispatched;
            dispatchModel.ProductName1 = dispatchDTO.ProductName1;
            dispatchModel.QuantityDispatched1 = dispatchDTO.QuantityDispatched1;
            dispatchModel.ProductName2 = dispatchDTO.ProductName2;
            dispatchModel.QuantityDispatched2 = dispatchDTO.QuantityDispatched2;   
            dispatchModel.ProductName3 = dispatchDTO.ProductName3;
            dispatchModel.QuantityDispatched3 = dispatchDTO.QuantityDispatched3; 

            await _context.SaveChangesAsync();
            return dispatchModel;
        }
    }
}