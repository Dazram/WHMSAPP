using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class StoresIssueSlipRepository : IStoresIssuesSlip
    {   
        private readonly ApplicationDBContext _context;
        public StoresIssueSlipRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<StoresIssueSlip> CreateAsync(StoresIssueSlip storesIssueSlip)
        {
           await _context.StoresIssueSlips.AddAsync(storesIssueSlip);
           await _context.SaveChangesAsync();
           return storesIssueSlip; 
        }

        public async Task<StoresIssueSlip?> DeleteAsync(int id)
        {
            var storesIssueSlipModel = await _context.StoresIssueSlips.FirstOrDefaultAsync(x => x.IssueNumber ==id);
            if( storesIssueSlipModel == null )
            {
                return null;
            }

            _context.StoresIssueSlips.Remove(storesIssueSlipModel);
            await _context.SaveChangesAsync();
            return storesIssueSlipModel;
        }

        public async Task<List<StoresIssueSlip>> GetAllAsync()
        {
           return await _context.StoresIssueSlips.ToListAsync();
        }

        public async Task<StoresIssueSlip?> GetByIdAsync(int id)
        {
            return await _context.StoresIssueSlips.FindAsync(id);
        }

        public async Task<StoresIssueSlip?> UpdateAsync(int id, UpdateStoresIssueSlipDTO storesIssueSlipDTO)
        {
            var storesIssueSlipModel = await _context.StoresIssueSlips.FirstOrDefaultAsync(x => x.IssueNumber ==id);
            if( storesIssueSlipModel == null )
            {
                return null;
            }

            storesIssueSlipModel.RequestorFirstName = storesIssueSlipDTO.RequestorFirstName;
            storesIssueSlipModel.RequestorLastName = storesIssueSlipDTO.RequestorLastName;
            storesIssueSlipModel.Department = storesIssueSlipDTO.Department;
            storesIssueSlipModel.Item = storesIssueSlipDTO.Item;
            storesIssueSlipModel.Quantity = storesIssueSlipDTO.Quantity;
            storesIssueSlipModel.Purpose = storesIssueSlipDTO.Purpose;

            await _context.SaveChangesAsync();
            return storesIssueSlipModel;
        }
    }
}