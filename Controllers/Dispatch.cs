using Microsoft.AspNetCore.Mvc;
using Warehouse_Management_System.DataTransferObjects.DispatchDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/dispatch/")]
    [ApiController]
    
    public class DispatchController : ControllerBase
    {   
        private readonly IDispatch _dispatchRepo;
        private readonly IWarehouseStocks _wareHouseRepo;
        public DispatchController(IDispatch dispatchRepo, IWarehouseStocks wareHouseRepo)
        {   
            _dispatchRepo = dispatchRepo;
            _wareHouseRepo = wareHouseRepo;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispatchs = await _dispatchRepo.GetAllAsync();
            var dispatchDTO = dispatchs.Select(s => s.ToDispatchDTO());

            return Ok(dispatchs);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var dispatchs = await _dispatchRepo.GetByIdAsync(Id);
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
            await _dispatchRepo.CreateAsync(dispatchModel);
            return CreatedAtAction(nameof(GetById), new { id = dispatchModel.DispatchId}, dispatchModel.ToDispatchDTO());

        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateDispatchDTO updateDispatchDTO)
        {
            var dispatchModel = await _dispatchRepo.UpdateAsync(Id , updateDispatchDTO);
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

            return Ok(dispatchModel.ToDispatchDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var dispatchModel = await _dispatchRepo.DeleteAsync(Id);

            if (dispatchModel == null)
            {
                return NotFound();
            }
            await _dispatchRepo.DeleteAsync(Id);
            return NoContent();
        }
        
    }
}