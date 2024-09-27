using Microsoft.AspNetCore.Mvc;
using Warehouse_Management_System.DataTransferObjects.WarehouseStockDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/warehouseStock")]
    [ApiController]

    public class WarehouseStockController : ControllerBase
    {
        private readonly IWarehouseStocks _warehouseStocksRepo;

        public WarehouseStockController(IWarehouseStocks warehouseStocksRepo)
        {
            _warehouseStocksRepo = warehouseStocksRepo;
        }

        [HttpGet]
        public async Task <IActionResult> GETALL()
        {
            var warehouseStocks =  await _warehouseStocksRepo.GetAllAsync();
            var warehouseStockDTO = warehouseStocks.Select(s => s.ToWarehouseStockDTO());
            return Ok(warehouseStocks);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var warehouseStocks = await _warehouseStocksRepo.GetByIdAsync(Id);
            if(warehouseStocks == null)
            {
                return NotFound();
            }
            return Ok(warehouseStocks.ToWarehouseStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseStockDTO warehouseStockDTO)
        {
            var warehouseStockModel = warehouseStockDTO.ToWarehousestockFromWarehousestockDTO();
            await _warehouseStocksRepo.CreateAsync(warehouseStockModel);
            return CreatedAtAction(nameof(GetById), new{id = warehouseStockModel.ProductId}, warehouseStockModel.ToWarehouseStockDTO());
        }
        
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateWarehouseStockDTO updateWarehouseStockDTO)
        {
            var warehouseStockModel = await _warehouseStocksRepo.UpdateAsync(Id, updateWarehouseStockDTO);
            if( warehouseStockModel == null)
            {
                return NotFound();
            }

            return Ok(warehouseStockModel.ToWarehouseStockDTO());     

        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var warehouseModel = await _warehouseStocksRepo.DeleteAsync(Id);
            if(warehouseModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}