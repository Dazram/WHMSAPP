using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class StoresGoodsReceivedVoucherRepository  : IStoresGoodsReceivedVoucher
    {   
        private readonly ApplicationDBContext _context;
        public StoresGoodsReceivedVoucherRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<StoresGoodsReceivedVoucher> CreateAsync(StoresGoodsReceivedVoucher storesGoodsReceivedVoucherModel)
        {
           await _context.StoresGoodsReceivedVouchers.AddAsync(storesGoodsReceivedVoucherModel);
           await _context.SaveChangesAsync();
           return storesGoodsReceivedVoucherModel; 
        }

        public async Task<StoresGoodsReceivedVoucher?> DeleteAsync(int id)
        {
            var storesGoodsReceivedVoucherModel = await _context.StoresGoodsReceivedVouchers.FirstOrDefaultAsync(x => x.GRVNumber ==id);
            if( storesGoodsReceivedVoucherModel == null )
            {
                return null;
            }

            _context.StoresGoodsReceivedVouchers.Remove(storesGoodsReceivedVoucherModel);
            await _context.SaveChangesAsync();
            return storesGoodsReceivedVoucherModel;
        }

        public async Task<List<StoresGoodsReceivedVoucher>> GetAllAsync()
        {
           return await _context.StoresGoodsReceivedVouchers.ToListAsync();
        }

        public async Task<StoresGoodsReceivedVoucher?> GetByIdAsync(int id)
        {
            return await _context.StoresGoodsReceivedVouchers.FindAsync(id);
        }

        public async Task<StoresGoodsReceivedVoucher?> UpdateAsync(int id, UpdateStoresGoodsReceivedVoucherDTO storesGoodsReceivedVoucherDTO)
        {
            var storesGoodsReceivedVoucherModel = await _context.StoresGoodsReceivedVouchers.FirstOrDefaultAsync(x => x.GRVNumber ==id);
            if( storesGoodsReceivedVoucherModel == null )
            {
                return null;
            }
            
            storesGoodsReceivedVoucherModel.Supplier = storesGoodsReceivedVoucherDTO.Supplier;
            storesGoodsReceivedVoucherModel.ProductName = storesGoodsReceivedVoucherDTO.ProductName;
            storesGoodsReceivedVoucherModel.DeliveryNoteNumber = storesGoodsReceivedVoucherDTO.DeliveryNoteNumber;
            storesGoodsReceivedVoucherModel.Quantity = storesGoodsReceivedVoucherDTO.Quantity;
            storesGoodsReceivedVoucherModel.Description = storesGoodsReceivedVoucherDTO.Description;
            storesGoodsReceivedVoucherModel.OffloadingAuthorisationNumber = storesGoodsReceivedVoucherDTO.OffloadingAuthorisationNumber;
            storesGoodsReceivedVoucherModel.DriverFirstName = storesGoodsReceivedVoucherDTO.DriverFirstName;  
            storesGoodsReceivedVoucherModel.DriverLastName = storesGoodsReceivedVoucherDTO.DriverLastName;
            
            await _context.SaveChangesAsync();
            return storesGoodsReceivedVoucherModel;
        }
    }
}
