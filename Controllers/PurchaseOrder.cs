using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.PurchaseOrderDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/purchaseorder/")]
    [ApiController]

    public class PurchaseOrderController : ControllerBase
    {   
        private readonly IPurchaseOrder _purchaseOrderRepo;
        public PurchaseOrderController( IPurchaseOrder purchaseOrderRepo)
        {   
            _purchaseOrderRepo = purchaseOrderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var purchaseorders = await _purchaseOrderRepo.GetAllAsync();
            var purchaseOrderDTO = purchaseorders.Select(s => s.ToPurchaseOrderDTO());
            return Ok(purchaseorders);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var purchaseorders = await _purchaseOrderRepo.GetByIdAsync(Id);
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
            await _purchaseOrderRepo.CreateAsync(purchaseorderModel);
            return CreatedAtAction(nameof(GetById), new{id = purchaseorderModel.PurchaseOrderId}, purchaseorderModel.ToPurchaseOrderDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id,[FromBody] UpdatePurchaseOrderDTO updatePurchaseOrderDTO)
        {
            var purchaseorderModel = await _purchaseOrderRepo.UpdateAsync(Id, updatePurchaseOrderDTO);
            if( purchaseorderModel == null )
            {
                return NotFound();
            }
           await _purchaseOrderRepo.UpdateAsync(Id, updatePurchaseOrderDTO);
           return Ok(purchaseorderModel.ToPurchaseOrderDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var purchaseorderModel = await _purchaseOrderRepo.DeleteAsync(Id);
            if ( purchaseorderModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}