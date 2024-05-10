using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/purchaseorder/")]
    [ApiController]

    public class PurchaseOrderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PurchaseOrderController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var purchaseorders = await _context.PurchaseOrders.ToListAsync();
            var purchaseOrderDTO = purchaseorders.Select(s => s.ToPurchaseOrderDTO());

            return Ok(purchaseorders);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var purchaseorders = await _context.PurchaseOrders.FindAsync(Id);
            if ( purchaseorders == null )
            {
                return NotFound();
            }

            return Ok(purchaseorders.ToPurchaseOrderDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseOrderDTO purchaseOrderDTO)
        {
            var purchaseorderModel = purchaseOrderDTO.ToPurchaseOrderFromPurchaseOrderDTO();
            await _context.AddAsync(purchaseorderModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new{id = purchaseorderModel.PurchaseOrderId}, purchaseorderModel.ToPurchaseOrderDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] UpdatePurchaseOrderDTO updatePurchaseOrderDTO)
        {
            var purchaseorderModel = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.PurchaseOrderId == Id);
            
            if( purchaseorderModel == null )
            {
                return NotFound();
            }
            purchaseorderModel.SupplierName = updatePurchaseOrderDTO.SupplierName;
            purchaseorderModel.SupplierAddress = updatePurchaseOrderDTO.SupplierAddress;
            purchaseorderModel.ContactDetails = updatePurchaseOrderDTO.ContactDetails;
            purchaseorderModel.TransactionType = updatePurchaseOrderDTO.TransactionType;
            purchaseorderModel.Goods_service = updatePurchaseOrderDTO.Goods_service;
            purchaseorderModel.Quantity = updatePurchaseOrderDTO.Quantity;
            purchaseorderModel.Goods_service1 = updatePurchaseOrderDTO.Goods_service1;
            purchaseorderModel.Quantity1 = updatePurchaseOrderDTO.Quantity1;
            purchaseorderModel.Goods_service2 = updatePurchaseOrderDTO.Goods_service2;
            purchaseorderModel.Quantity2 = updatePurchaseOrderDTO.Quantity2;
            purchaseorderModel.Goods_service3 = updatePurchaseOrderDTO.Goods_service3;
            purchaseorderModel.Quantity3 = updatePurchaseOrderDTO.Quantity3;
            purchaseorderModel.Goods_service4 = updatePurchaseOrderDTO.Goods_service4;
            purchaseorderModel.Quantity4 = updatePurchaseOrderDTO.Quantity4;
            purchaseorderModel.Goods_service5 = updatePurchaseOrderDTO.Goods_service5;
            purchaseorderModel.Quantity5 = updatePurchaseOrderDTO.Quantity5;
            purchaseorderModel.Discount = updatePurchaseOrderDTO.Discount;
            purchaseorderModel.Vat = updatePurchaseOrderDTO.Vat;
            purchaseorderModel.TotalAmount = updatePurchaseOrderDTO.TotalAmount;

           await _context.SaveChangesAsync();

            return Ok(purchaseorderModel.ToPurchaseOrderDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var purchaseorderModel = await _context.PurchaseOrders.FirstOrDefaultAsync(x => x.PurchaseOrderId == Id);
            if ( purchaseorderModel == null)
            {
                return NotFound();
            }

            _context.PurchaseOrders.Remove(purchaseorderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}