using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.PurchaseRequisitionDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class PurchaseRequisitionRepository : IPurchaseRequisition
    {   
        private readonly ApplicationDBContext _context;
        public PurchaseRequisitionRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PurchaseRequisition> CreateAsync(PurchaseRequisition purchaseRequisitionModel)
        {
           await _context.PurchaseRequisitions.AddAsync(purchaseRequisitionModel);
           await _context.SaveChangesAsync();
           return purchaseRequisitionModel; 
        }

        public async Task<PurchaseRequisition?> DeleteAsync(int id)
        {
            var purchaseRequisitionModel = await _context.PurchaseRequisitions.FirstOrDefaultAsync(x => x.RequisitionId ==id);
            if( purchaseRequisitionModel == null )
            {
                return null;
            }

            _context.PurchaseRequisitions.Remove(purchaseRequisitionModel);
            await _context.SaveChangesAsync();
            return purchaseRequisitionModel;
        }

        public async Task<List<PurchaseRequisition>> GetAllAsync()
        {
           return await _context.PurchaseRequisitions.ToListAsync();
        }

        public async Task<PurchaseRequisition?> GetByIdAsync(int id)
        {
            return await _context.PurchaseRequisitions.FindAsync(id);
        }

        public async Task<PurchaseRequisition?> UpdateAsync(int id, UpdatePurchaseRequisionDTO purchaseRequisitionDTO)
        {
            var purchaseRequisitionModel = await _context.PurchaseRequisitions.FirstOrDefaultAsync(x => x.RequisitionId ==id);
            if( purchaseRequisitionModel == null )
            {
                return null;
            }

            purchaseRequisitionModel.EmployeeName = purchaseRequisitionDTO.EmployeeName;
            purchaseRequisitionModel.Department = purchaseRequisitionDTO.Department;
            purchaseRequisitionModel.PurposeOfPurchase = purchaseRequisitionDTO.PurposeOfPurchase;
            purchaseRequisitionModel.ProductName = purchaseRequisitionDTO.ProductName;
            purchaseRequisitionModel.ProductQuantity = purchaseRequisitionDTO.ProductQuantity1;
            purchaseRequisitionModel.ProductName1 = purchaseRequisitionDTO.ProductName1;
            purchaseRequisitionModel.ProductQuantity1 = purchaseRequisitionDTO.ProductQuantity1;
            purchaseRequisitionModel.ProductName2 = purchaseRequisitionDTO.ProductName2;
            purchaseRequisitionModel.ProductQuantity2 = purchaseRequisitionDTO.ProductQuantity2;
            purchaseRequisitionModel.ProductName3 = purchaseRequisitionDTO.ProductName3;
            purchaseRequisitionModel.ProductQuantity3 = purchaseRequisitionDTO.ProductQuantity3;
            purchaseRequisitionModel.ProductName4 = purchaseRequisitionDTO.ProductName4;
            purchaseRequisitionModel.ProductQuantity4 = purchaseRequisitionDTO.ProductQuantity4;
            purchaseRequisitionModel.ProductName5 = purchaseRequisitionDTO.ProductName5;
            purchaseRequisitionModel.ProductQuantity5 = purchaseRequisitionDTO.ProductQuantity5;
            
            await _context.SaveChangesAsync();
            return purchaseRequisitionModel;
        }
    }
}