using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.DispatchDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/dispatch/")]
    [ApiController]
    
    public class DispatchController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public DispatchController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispatchs = await _context.Dispatchs.ToListAsync();
            var dispatchDTO = dispatchs.Select(s => s.ToDispatchDTO());

            return Ok(dispatchs);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var dispatchs = await _context.Dispatchs.FindAsync(Id);
            if (dispatchs == null)
            {
                return NotFound();
            }

            return Ok(dispatchs.ToDispatchDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDispatchDTO dispatchDTO)
        {
            var dispatchModel = dispatchDTO.ToDispatchFromDispatchDTO();
            await _context.AddAsync(dispatchModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new{id = dispatchModel.DispatchId}, dispatchModel.ToDispatchDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateDispatchDTO updateDispatchDTO)
        {
            var dispatchModel = await _context.Dispatchs.FirstOrDefaultAsync(x => x.DispatchId == Id);
            
            if (dispatchModel == null)
            {
                return NotFound();
            }

            dispatchModel.CustomerName = updateDispatchDTO.CustomerName;
            dispatchModel.ProductName = updateDispatchDTO.ProductName;
            dispatchModel.QuantityDispatched = updateDispatchDTO.QuantityDispatched;
            dispatchModel.ProductName1 = updateDispatchDTO.ProductName1;
            dispatchModel.QuantityDispatched1 = updateDispatchDTO.QuantityDispatched1;
            dispatchModel.ProductName2 = updateDispatchDTO.ProductName2;
            dispatchModel.QuantityDispatched2 = updateDispatchDTO.QuantityDispatched2;   
            dispatchModel.ProductName3 = updateDispatchDTO.ProductName3;
            dispatchModel.QuantityDispatched3 = updateDispatchDTO.QuantityDispatched3; 

            await _context.SaveChangesAsync();

            return Ok(dispatchModel.ToDispatchDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var dispatchModel = await _context.Dispatchs.FirstOrDefaultAsync(x =>x.DispatchId == Id);

            if (dispatchModel == null)
            {
                return NotFound();
            }

            _context.Dispatchs.Remove(dispatchModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}