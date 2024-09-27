using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.SalesOrderDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class SalesOrderRepository : ISalesOrder
    {   
        private readonly ApplicationDBContext _context;
        public SalesOrderRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<SalesOrder> CreateAsync(SalesOrder salesOrderModel)
        {
           await _context.SalesOrders.AddAsync(salesOrderModel);
           await _context.SaveChangesAsync();
           return salesOrderModel; 
        }

        public async Task<SalesOrder?> DeleteAsync(int id)
        {
            var salesOrderModel = await _context.SalesOrders.FirstOrDefaultAsync(x => x.OrderId ==id);
            if( salesOrderModel == null )
            {
                return null;
            }

            _context.SalesOrders.Remove(salesOrderModel);
            await _context.SaveChangesAsync();
            return salesOrderModel;
        }

        public async Task<List<SalesOrder>> GetAllAsync()
        {
           return await _context.SalesOrders.ToListAsync();
        }

        public async Task<SalesOrder?> GetByIdAsync(int id)
        {
            return await _context.SalesOrders.FindAsync(id);
        }

        public async Task<SalesOrder?> UpdateAsync(int id, UpdateSalesOrderDTO salesOrderDTO)
        {
            var salesOrderModel = await _context.SalesOrders.FirstOrDefaultAsync(x => x.OrderId ==id);
            if( salesOrderModel == null )
            {
                return null;
            }

            salesOrderModel.CustomerName = salesOrderDTO.CustomerName;
            salesOrderModel.Destination = salesOrderDTO.Destination;
            salesOrderModel.TransactionType = salesOrderDTO.TransactionType;
            salesOrderModel.TotalAmount = salesOrderDTO.TotalAmount;
            salesOrderModel.SoldProducts = salesOrderDTO.SoldProducts;
            salesOrderModel.SoldProduct1 = salesOrderDTO.SoldProduct1;
            salesOrderModel.SoldProduct2 = salesOrderDTO.SoldProduct2;
            salesOrderModel.SoldProduct3 = salesOrderDTO.SoldProduct3;
            salesOrderModel.SoldProduct4 = salesOrderDTO.SoldProduct4;
            salesOrderModel.SoldProduct5 = salesOrderDTO.SoldProduct5;
            salesOrderModel.SoldProduct6 = salesOrderDTO.SoldProduct6;
            await _context.SaveChangesAsync();
            return salesOrderModel;
        }
    }
}