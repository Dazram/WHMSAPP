using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.SalesOrderDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/salesorder")]
    [ApiController]

    public class SalesOrderController : ControllerBase  
    {
        private readonly ISalesOrder _salesOrderRepo;
        public SalesOrderController(ISalesOrder salesOrderRepo)
        {
            _salesOrderRepo = salesOrderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesorders = await _salesOrderRepo.GetAllAsync();
            var salesOrderDTO = salesorders.Select(s => s.ToSalesOrderDTO());
            return Ok(salesorders);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var salesorders = await _salesOrderRepo.GetByIdAsync(Id);
            if(salesorders == null)
            {
                return NotFound();
            }
            return Ok(salesorders.ToSalesOrderDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderDTO salesOrderDTO)
        {
            var salesOrderModel = salesOrderDTO.ToSalesOrderFromSalesOrderDTO();
            await _salesOrderRepo.CreateAsync(salesOrderModel);
            return CreatedAtAction(nameof(GetById), new{id = salesOrderModel.OrderId}, salesOrderModel.ToSalesOrderDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateSalesOrderDTO updateSalesOrderDTO)
        {
            var salesOrderModel = await _salesOrderRepo.UpdateAsync(Id, updateSalesOrderDTO);
            if( salesOrderModel == null)
            {
                return NotFound();
            }

            return Ok(salesOrderModel.ToSalesOrderDTO());   
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var salesOrderModel = await _salesOrderRepo.DeleteAsync(Id);
            if( salesOrderModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}