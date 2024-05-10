using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.PurchaseRequisitionDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/purchaserequisition")]
    [ApiController]

    public class PurchaseRequisitionController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PurchaseRequisitionController( ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var purchaserequisitions = await _context.PurchaseRequisitions.ToListAsync();
            var purchaseRequisitionDTO = purchaserequisitions.Select(s => s.ToPurchaseRequisitionDTO());

            return Ok(purchaserequisitions);
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var purchaseRequisitions = await _context.PurchaseRequisitions.FindAsync(Id);

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
            await _context.AddAsync(purchaseRequisitionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new{id = purchaseRequisitionModel.RequisitionId}, purchaseRequisitionModel.ToPurchaseRequisitionDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdatePurchaseRequisionDTO updatePurchaseRequisionDTO)
        {
            var purchaseRequisitionModel = await _context.PurchaseRequisitions.FirstOrDefaultAsync(x => x.RequisitionId == Id);
            
            if( purchaseRequisitionModel == null )
            {
                return NotFound();
            }

            purchaseRequisitionModel.EmployeeName = updatePurchaseRequisionDTO.EmployeeName;
            purchaseRequisitionModel.Department = updatePurchaseRequisionDTO.Department;
            purchaseRequisitionModel.PurposeOfPurchase = updatePurchaseRequisionDTO.PurposeOfPurchase;
            purchaseRequisitionModel.ProductName = updatePurchaseRequisionDTO.ProductName;
            purchaseRequisitionModel.ProductQuantity = updatePurchaseRequisionDTO.ProductQuantity1;
            purchaseRequisitionModel.ProductName1 = updatePurchaseRequisionDTO.ProductName1;
            purchaseRequisitionModel.ProductQuantity1 = updatePurchaseRequisionDTO.ProductQuantity1;
            purchaseRequisitionModel.ProductName2 = updatePurchaseRequisionDTO.ProductName2;
            purchaseRequisitionModel.ProductQuantity2 = updatePurchaseRequisionDTO.ProductQuantity2;
            purchaseRequisitionModel.ProductName3 = updatePurchaseRequisionDTO.ProductName3;
            purchaseRequisitionModel.ProductQuantity3 = updatePurchaseRequisionDTO.ProductQuantity3;
            purchaseRequisitionModel.ProductName4 = updatePurchaseRequisionDTO.ProductName4;
            purchaseRequisitionModel.ProductQuantity4 = updatePurchaseRequisionDTO.ProductQuantity4;
            purchaseRequisitionModel.ProductName5 = updatePurchaseRequisionDTO.ProductName5;
            purchaseRequisitionModel.ProductQuantity5 = updatePurchaseRequisionDTO.ProductQuantity5;

            await _context.SaveChangesAsync();

            return Ok(purchaseRequisitionModel.ToPurchaseRequisitionDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var purchaseRequisitionModel = await _context.PurchaseRequisitions.FirstOrDefaultAsync( x => x.RequisitionId == Id);
            if( purchaseRequisitionModel == null)
            {
                return NotFound();
            }

            _context.PurchaseRequisitions.Remove(purchaseRequisitionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}