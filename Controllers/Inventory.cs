using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.InventoryDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{   
    [Route("api/inventory/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {   
        private readonly IInventory _inventoryRepo;
        private readonly ApplicationDBContext _context;
        public InventoryController(ApplicationDBContext context, IInventory inventoryRepo)
        {   
            _inventoryRepo = inventoryRepo;
            _context = context;
        } 

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var inventories = await _inventoryRepo.GetAllAsync();
            var inventoryDTO = inventories.Select(s => s.ToInventoryDTO());
            return Ok(inventories);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var inventories = await _inventoryRepo.GetByIdAsync(Id);
            if (inventories == null)
            {
                return NotFound();
            }

            return Ok(inventories.ToInventoryDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInventoryDTO inventoryDTO )
        {
            var inventoryModel = inventoryDTO.ToInventoryFromInventoryDTO();
            await _inventoryRepo.CreateAsync(inventoryModel);
            return CreatedAtAction(nameof(GetById), new { id = inventoryModel.ItemId}, inventoryModel.ToInventoryDTO());
        }

        [HttpPut]
        [Route("{Id}")]

        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateInventoryDTO updateInvetoryDTO)
        {
            var inventoryModel = await _inventoryRepo.UpdateAsync(Id, updateInvetoryDTO);
            if (inventoryModel == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return Ok(inventoryModel.ToInventoryDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var inventoryModel = await _inventoryRepo.DeleteAsync(Id);
            if ( inventoryModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    
    }
}