using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/storesGoodsReceivedVoucher")]
    [ApiController]
    public class StoresGoodsReceivedVoucherController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StoresGoodsReceivedVoucherController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var storesgoodsreceivedvouchers = await _context.StoresGoodsReceivedVouchers.ToListAsync();
            var StotesGoodsReceivedVoucherDTO = storesgoodsreceivedvouchers.Select(s => s.ToStoresGoodsReceivedVoucherDTO());

            return Ok(storesgoodsreceivedvouchers);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var storesGoodsReceivedVoucher = await _context.StoresGoodsReceivedVouchers.FindAsync(Id);
            if(storesGoodsReceivedVoucher == null)
            {
                return NotFound();
            }

            return Ok(storesGoodsReceivedVoucher.ToStoresGoodsReceivedVoucherDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStoresReceivedVoucherDTO storesGoodsReceivedVoucherDTO )
        {
            var storesGoodsReceivedVoucherModel = storesGoodsReceivedVoucherDTO.ToStoresGoodsReceivedVoucherFromStoresGoodsReceivedVoucherDTO();
                await _context.AddAsync(storesGoodsReceivedVoucherModel);
                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = storesGoodsReceivedVoucherModel.GRVNumber}, storesGoodsReceivedVoucherModel.ToStoresGoodsReceivedVoucherDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStoresGoodsReceivedVoucherDTO updateStoresGoodsReceivedVoucherDTO)
        {
            var storesGoodsReceivedVoucherModel = await _context.StoresGoodsReceivedVouchers.FirstOrDefaultAsync(x => x.GRVNumber ==Id);
            
            if( storesGoodsReceivedVoucherModel == null)
            {
                return NotFound();
            }

            storesGoodsReceivedVoucherModel.Supplier = updateStoresGoodsReceivedVoucherDTO.Supplier;
            storesGoodsReceivedVoucherModel.ProductName = updateStoresGoodsReceivedVoucherDTO.ProductName;
            storesGoodsReceivedVoucherModel.DeliveryNoteNumber = updateStoresGoodsReceivedVoucherDTO.DeliveryNoteNumber;
            storesGoodsReceivedVoucherModel.Quantity = updateStoresGoodsReceivedVoucherDTO.Quantity;
            storesGoodsReceivedVoucherModel.Description = updateStoresGoodsReceivedVoucherDTO.Description;
            storesGoodsReceivedVoucherModel.OffloadingAuthorisationNumber = updateStoresGoodsReceivedVoucherDTO.OffloadingAuthorisationNumber;
            storesGoodsReceivedVoucherModel.DriverFirstName = updateStoresGoodsReceivedVoucherDTO.DriverFirstName;  
            storesGoodsReceivedVoucherModel.DriverLastName = updateStoresGoodsReceivedVoucherDTO.DriverLastName;

            await _context.SaveChangesAsync();

            return Ok(storesGoodsReceivedVoucherModel.ToStoresGoodsReceivedVoucherDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var storesGoodsReceivedVoucherModel = await _context.StoresGoodsReceivedVouchers.FirstOrDefaultAsync(x => x.GRVNumber == Id);

            if( storesGoodsReceivedVoucherModel == null)
            {
                return NotFound();
            }

            _context.StoresGoodsReceivedVouchers.Remove(storesGoodsReceivedVoucherModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}