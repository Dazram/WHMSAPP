using Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IStoresGoodsReceivedVoucher
    {
        Task<List<StoresGoodsReceivedVoucher>> GetAllAsync();
        Task<StoresGoodsReceivedVoucher?> GetByIdAsync(int id);
        Task<StoresGoodsReceivedVoucher> CreateAsync(StoresGoodsReceivedVoucher storesGoodsReceivedVoucherModel);
        Task<StoresGoodsReceivedVoucher?> UpdateAsync(int id, UpdateStoresGoodsReceivedVoucherDTO storesGoodsReceivedVoucherDTO);
        Task<StoresGoodsReceivedVoucher?> DeleteAsync(int id); 
    }
}