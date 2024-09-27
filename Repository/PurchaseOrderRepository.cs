using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrder
    {   
        private readonly ApplicationDBContext _context;
        public PurchaseOrderRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<PurchaseOrder> CreateAsync(PurchaseOrder purchaseOrderModel)
        {
           await _context.PurchaseOrders.AddAsync(purchaseOrderModel);
           await _context.SaveChangesAsync();
           return purchaseOrderModel; 
        }

        public async Task<PurchaseOrder?> DeleteAsync(int id)
        {
            var purchaseOrderModel = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.PurchaseOrderId ==id);
            if( purchaseOrderModel == null )
            {
                return null;
            }

            _context.PurchaseOrders.Remove(purchaseOrderModel);
            await _context.SaveChangesAsync();
            return purchaseOrderModel;
        }

        public async Task<List<PurchaseOrder>> GetAllAsync()
        {
           return await _context.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _context.PurchaseOrders.FindAsync(id);
        }

        public async Task<PurchaseOrder?> UpdateAsync(int id, UpdatePurchaseOrderDTO purchaseOrderDTO)
        {
            var purchaseOrderModel = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.PurchaseOrderId ==id);
            if( purchaseOrderModel == null )
            {
                return null;
            }

            purchaseOrderModel.SupplierName = purchaseOrderDTO.SupplierName;
            purchaseOrderModel.SupplierAddress = purchaseOrderDTO.SupplierAddress;
            purchaseOrderModel.ContactDetails = purchaseOrderDTO.ContactDetails;
            purchaseOrderModel.TransactionType = purchaseOrderDTO.TransactionType;
            purchaseOrderModel.Goods_service = purchaseOrderDTO.Goods_service;
            purchaseOrderModel.Quantity = purchaseOrderDTO.Quantity;
            purchaseOrderModel.Goods_service1 = purchaseOrderDTO.Goods_service1;
            purchaseOrderModel.Quantity1 = purchaseOrderDTO.Quantity1;
            purchaseOrderModel.Goods_service2 = purchaseOrderDTO.Goods_service2;
            purchaseOrderModel.Quantity2 = purchaseOrderDTO.Quantity2;
            purchaseOrderModel.Goods_service3 = purchaseOrderDTO.Goods_service3;
            purchaseOrderModel.Quantity3 = purchaseOrderDTO.Quantity3;
            purchaseOrderModel.Goods_service4 = purchaseOrderDTO.Goods_service4;
            purchaseOrderModel.Quantity4 = purchaseOrderDTO.Quantity4;
            purchaseOrderModel.Goods_service5 = purchaseOrderDTO.Goods_service5;
            purchaseOrderModel.Quantity5 = purchaseOrderDTO.Quantity5;
            purchaseOrderModel.Discount = purchaseOrderDTO.Discount;
            purchaseOrderModel.Vat = purchaseOrderDTO.Vat;
            purchaseOrderModel.TotalAmount = purchaseOrderDTO.TotalAmount;


            await _context.SaveChangesAsync();
            return purchaseOrderModel;
        }
    }
}