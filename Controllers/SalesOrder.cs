using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.SalesOrderDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/salesorder")]
    [ApiController]

    public class SalesOrderController : ControllerBase  
    {
        private readonly ApplicationDBContext _context;
        public SalesOrderController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesorders = await _context.SalesOrders.ToListAsync();
            var salesOrderDTO = salesorders.Select(s => s.ToSalesOrderDTO());

            return Ok(salesorders);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var salesorders = await _context.SalesOrders.FindAsync(Id);
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
            await _context.AddAsync(salesOrderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new{id = salesOrderModel.OrderId}, salesOrderModel.ToSalesOrderDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateSalesOrderDTO updateSalesOrderDTO)
        {
            var salesOrderModel = await _context.SalesOrders.FirstOrDefaultAsync(x => x.OrderId == Id);
            
            if( salesOrderModel == null)
            {
                return NotFound();
            }

            salesOrderModel.CustomerName = updateSalesOrderDTO.CustomerName;
            salesOrderModel.Destination = updateSalesOrderDTO.Destination;
            salesOrderModel.TransactionType = updateSalesOrderDTO.TransactionType;
            salesOrderModel.TotalAmount = updateSalesOrderDTO.TotalAmount;
            salesOrderModel.SoldProducts = updateSalesOrderDTO.SoldProducts;
            salesOrderModel.SoldProduct1 = updateSalesOrderDTO.SoldProduct1;
            salesOrderModel.SoldProduct2 = updateSalesOrderDTO.SoldProduct2;
            salesOrderModel.SoldProduct3 = updateSalesOrderDTO.SoldProduct3;
            salesOrderModel.SoldProduct4 = updateSalesOrderDTO.SoldProduct4;
            salesOrderModel.SoldProduct5 = updateSalesOrderDTO.SoldProduct5;
            salesOrderModel.SoldProduct6 = updateSalesOrderDTO.SoldProduct6;

            await _context.SaveChangesAsync();

            return Ok(salesOrderModel.ToSalesOrderDTO());   
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var salesOrderModel = _context.SalesOrders.FirstOrDefault( x => x.OrderId == Id );
            if( salesOrderModel == null)
            {
                return NotFound();
            }

            _context.SalesOrders.Remove(salesOrderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}