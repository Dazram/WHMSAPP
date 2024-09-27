using Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IStoresIssuesSlip
    {
        Task<List<StoresIssueSlip>> GetAllAsync();
        Task<StoresIssueSlip?> GetByIdAsync(int id);
        Task<StoresIssueSlip> CreateAsync(StoresIssueSlip storesIssueSlipModel);
        Task<StoresIssueSlip?> UpdateAsync(int id, UpdateStoresIssueSlipDTO storesIssueSlipDTO);
        Task<StoresIssueSlip?> DeleteAsync(int id); 
    }
}