using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.WarehouseStockDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/warehouseStock")]
    [ApiController]

    public class WarehouseStockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public WarehouseStockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GETALL()
        {
            var warehouseStocks =  await _context.WarehouseStocks.ToListAsync();
            var warehouseStockDTO = warehouseStocks.Select(s => s.ToWarehouseStockDTO());
            return Ok(warehouseStocks);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var warehouseStocks = await _context.WarehouseStocks.FindAsync(Id);
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
            await _context.AddAsync(warehouseStockModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new{id = warehouseStockModel.ProductId}, warehouseStockModel.ToWarehouseStockDTO());
        }
        
        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateWarehouseStockDTO updateWarehouseStockDTO)
        {
            var warehouseStockModel = await _context.WarehouseStocks.FirstOrDefaultAsync(x => x.ProductId == Id);
            
            if( warehouseStockModel == null)
            {
                return NotFound();
            }

            warehouseStockModel.ProductName = updateWarehouseStockDTO.ProductName;
            warehouseStockModel.OpeningBalance = updateWarehouseStockDTO.OpeningBalance;
            warehouseStockModel.Production = updateWarehouseStockDTO.Production;
            warehouseStockModel.SalesDispatch = updateWarehouseStockDTO.SalesDispatch;
            warehouseStockModel.Samples = updateWarehouseStockDTO.Samples;
            warehouseStockModel.Returns = updateWarehouseStockDTO.Returns;

            await _context.SaveChangesAsync();

            return Ok(warehouseStockModel.ToWarehouseStockDTO());     

        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var warehouseModel = await _context.WarehouseStocks.FirstOrDefaultAsync(x => x.ProductId == Id);
            if(warehouseModel == null)
            {
                return NotFound();
            }

            _context.WarehouseStocks.Remove(warehouseModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}