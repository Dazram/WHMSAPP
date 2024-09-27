using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/storesGoodsReceivedVoucher")]
    [ApiController]
    public class StoresGoodsReceivedVoucherController : ControllerBase
    {
        private readonly IStoresGoodsReceivedVoucher _storesGoodsReceivedVoucherRepo;
        public StoresGoodsReceivedVoucherController(IStoresGoodsReceivedVoucher storesGoodsReceivedVoucherVoucherRepo)
        {
            _storesGoodsReceivedVoucherRepo = storesGoodsReceivedVoucherVoucherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var storesgoodsreceivedvouchers = await _storesGoodsReceivedVoucherRepo.GetAllAsync();
            var StotesGoodsReceivedVoucherDTO = storesgoodsreceivedvouchers.Select(s => s.ToStoresGoodsReceivedVoucherDTO());

            return Ok(storesgoodsreceivedvouchers);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var storesGoodsReceivedVoucher = await _storesGoodsReceivedVoucherRepo.GetByIdAsync(Id);
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
            await _storesGoodsReceivedVoucherRepo.CreateAsync(storesGoodsReceivedVoucherModel);
            return CreatedAtAction(nameof(GetById), new {id = storesGoodsReceivedVoucherModel.GRVNumber}, storesGoodsReceivedVoucherModel.ToStoresGoodsReceivedVoucherDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStoresGoodsReceivedVoucherDTO updateStoresGoodsReceivedVoucherDTO)
        {
            var storesGoodsReceivedVoucherModel = await _storesGoodsReceivedVoucherRepo.UpdateAsync(Id, updateStoresGoodsReceivedVoucherDTO);   
            if( storesGoodsReceivedVoucherModel == null)
            {
                return NotFound();
            }

            return Ok(storesGoodsReceivedVoucherModel.ToStoresGoodsReceivedVoucherDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var storesGoodsReceivedVoucherModel = await _storesGoodsReceivedVoucherRepo.DeleteAsync(Id);
            if( storesGoodsReceivedVoucherModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}