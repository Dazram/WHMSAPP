using Microsoft.AspNetCore.Mvc;
using Warehouse_Management_System.DataTransferObjects.PurchaseRequisitionDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/purchaserequisition")]
    [ApiController]

    public class PurchaseRequisitionController : ControllerBase
    {
        private readonly IPurchaseRequisition _purchaseRequisitionRepo;

        public PurchaseRequisitionController( IPurchaseRequisition purchaseRequisitionRepo)
        {
            _purchaseRequisitionRepo = purchaseRequisitionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var purchaserequisitions = await _purchaseRequisitionRepo.GetAllAsync();
            var purchaseRequisitionDTO = purchaserequisitions.Select(s => s.ToPurchaseRequisitionDTO());
            return Ok(purchaserequisitions);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var purchaseRequisitions = await _purchaseRequisitionRepo.GetByIdAsync(Id);
            if(purchaseRequisitions == null)
            {
                return NotFound();
            }
            return Ok(purchaseRequisitions.ToPurchaseRequisitionDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseRequisitionDTO purchaseRequisitionDTO)
        {
            var purchaseRequisitionModel = purchaseRequisitionDTO.ToPurchaseRequisitionFromPurchaseRequisitionDTO();
            await _purchaseRequisitionRepo.CreateAsync(purchaseRequisitionModel);
            return CreatedAtAction(nameof(GetById), new{id = purchaseRequisitionModel.RequisitionId}, purchaseRequisitionModel.ToPurchaseRequisitionDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdatePurchaseRequisionDTO updatePurchaseRequisionDTO)
        {
            var purchaseRequisitionModel = await _purchaseRequisitionRepo.UpdateAsync(Id, updatePurchaseRequisionDTO);
            if(purchaseRequisitionModel == null)
            {
                return NotFound();
            }

            return Ok(purchaseRequisitionModel.ToPurchaseRequisitionDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var purchaseRequisitionModel = await _purchaseRequisitionRepo.DeleteAsync(Id);
            if( purchaseRequisitionModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}