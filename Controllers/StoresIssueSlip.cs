using Microsoft.AspNetCore.Mvc;
using Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/storesissueslip")]
    [ApiController]

    public class StoresIssueSlipController : ControllerBase
    {
        private readonly IStoresIssuesSlip _storesIssueRepo;
        public StoresIssueSlipController(IStoresIssuesSlip storesIssuesSlipRepo)
        {
            _storesIssueRepo = storesIssuesSlipRepo;
        }   

        [HttpGet]
        public async Task<IActionResult> GETALL()
        {
            var storesissueslips = await _storesIssueRepo.GetAllAsync();
            var storesIssueSlipDTO = storesissueslips.Select(s => s.ToStoresIssueSlipDTO());
            return Ok(storesissueslips);
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var storesIssueSlips =  await _storesIssueRepo.GetByIdAsync(Id);
            if(storesIssueSlips == null)
            {
                return NotFound();
            }
            return Ok(storesIssueSlips.ToStoresIssueSlipDTO());
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody] CreateStoresIssueSlipDTO storesIssueSlipDTO)
        {
            var storesIssueSlipModel = storesIssueSlipDTO.ToStoresIssueSlipFromStoresIssueSlipDTO();
            await _storesIssueRepo.CreateAsync(storesIssueSlipModel);
            return CreatedAtAction(nameof(GetById), new{id = storesIssueSlipModel.IssueNumber}, storesIssueSlipModel.ToStoresIssueSlipDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStoresIssueSlipDTO updateStoresIssueSlipDTO)
        {
            var storesIssueSlipModel = await _storesIssueRepo.UpdateAsync(Id, updateStoresIssueSlipDTO);
            if(storesIssueSlipModel == null)
            {
                return NotFound();
            }

            return Ok(storesIssueSlipModel.ToStoresIssueSlipDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var storesIssueSlipModel = await _storesIssueRepo.DeleteAsync(Id);
            if(storesIssueSlipModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}