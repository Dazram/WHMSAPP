using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs;
using Warehouse_Management_System.Mappers;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/storesissueslip")]
    [ApiController]

    public class StoresIssueSlipController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StoresIssueSlipController(ApplicationDBContext context)
        {
            _context = context;
        }   

        [HttpGet]
        public IActionResult GETALL()
        {
            var storesissueslips = _context.StoresIssueSlips.ToList()
                .Select(s => s.ToStoresIssueSlipDTO());

            return Ok(storesissueslips);
        }
        
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            var storesIssueSlipModel = _context.StoresIssueSlips.Find(Id);
            if(storesIssueSlipModel == null)
            {
                return NotFound();
            }

            return Ok(storesIssueSlipModel.ToStoresIssueSlipDTO());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStoresIssueSlipDTO storesIssueSlipDTO)
        {
            var storesIssueSlipModel = storesIssueSlipDTO.ToStoresIssueSlipFromStoresIssueSlipDTO();
            _context.Add(storesIssueSlipModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new{id = storesIssueSlipModel.IssueNumber}, storesIssueSlipModel.ToStoresIssueSlipDTO());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateStoresIssueSlipDTO updateStoresIssueSlipDTO)
        {
            var storesIssueSlipModel = await _context.StoresIssueSlips.FirstOrDefaultAsync(x => x.IssueNumber ==Id);
            
            if(storesIssueSlipModel == null)
            {
                return NotFound();
            }

            storesIssueSlipModel.RequestorFirstName = updateStoresIssueSlipDTO.RequestorFirstName;
            storesIssueSlipModel.RequestorLastName = updateStoresIssueSlipDTO.RequestorLastName;
            storesIssueSlipModel.Department = updateStoresIssueSlipDTO.Department;
            storesIssueSlipModel.Item = updateStoresIssueSlipDTO.Item;
            storesIssueSlipModel.Quantity = updateStoresIssueSlipDTO.Quantity;
            storesIssueSlipModel.Purpose = updateStoresIssueSlipDTO.Purpose;

            await _context.SaveChangesAsync();

            return Ok(storesIssueSlipModel.ToStoresIssueSlipDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var storesIssueSlipModel = await _context.StoresIssueSlips.FirstOrDefaultAsync(x => x.IssueNumber == Id);

            if(storesIssueSlipModel == null)
            {
                return NotFound();
            }

            _context.StoresIssueSlips.Remove(storesIssueSlipModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}