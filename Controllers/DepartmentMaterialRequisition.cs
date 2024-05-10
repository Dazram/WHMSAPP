using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.DepartmentMaterialRequisitionDTOs;
using Warehouse_Management_System.Mappers;
using Warehouse_Management_System.Repository;
using Warehouse_Management_System.Interfaces;

namespace Warehouse_Management_System.Controllers
{
    [Route("api/departmentmaterialrequesition/")]
    [ApiController]

    public class DepartmentMaterialRequisitionController : ControllerBase   
    {   
        private readonly IDepartmentMaterialRequisition _departmentMaterialRequisitionRepo;
        private readonly ApplicationDBContext _context;
        public DepartmentMaterialRequisitionController(ApplicationDBContext context, IDepartmentMaterialRequisition departmentMaterialRequisitionRepo)
        {
            _departmentMaterialRequisitionRepo = departmentMaterialRequisitionRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departmentMaterialRequisitions = await _context.DepartmentMaterialRequisitions.ToListAsync();
            var departmentMaterialRequisitionDTO = departmentMaterialRequisitions.Select(s => s.ToDepartmentMaterialRequisitionDTO());    
            return Ok(departmentMaterialRequisitions);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var departmentMaterialRequisitions = await _departmentMaterialRequisitionRepo.GetByIdAsync(Id);
            if (departmentMaterialRequisitions == null)
            {
                return NotFound();
            }
            return Ok(departmentMaterialRequisitions.ToDepartmentMaterialRequisitionDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentMaterialRequisitiontDTO departmentMaterialRequistionDTO)
        {
            var departmentMaterialRequisitionModel = departmentMaterialRequistionDTO.ToDepartmentMaterialRequisitionFromDepartmentMaterialRequisitionDTO();
            await _departmentMaterialRequisitionRepo.CreateAsync(departmentMaterialRequisitionModel);
            return CreatedAtAction(nameof(GetById), new{id = departmentMaterialRequisitionModel.DMRId}, departmentMaterialRequisitionModel.ToDepartmentMaterialRequisitionDTO());
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] UpdateDepartmentMaterialRequisitionDTO updateDepartmentMaterialRequisitionDTO)
        {
            var departmentMaterialRequisitionModel = await _departmentMaterialRequisitionRepo.UpdateAsync(Id, updateDepartmentMaterialRequisitionDTO);
            if(departmentMaterialRequisitionModel == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return Ok(departmentMaterialRequisitionModel.ToDepartmentMaterialRequisitionDTO());
        }

        [HttpDelete]
        [Route("{Id}")]

        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var departmentMaterialRequisitionModel = await _departmentMaterialRequisitionRepo.DeleteAsync(Id);
            if ( departmentMaterialRequisitionModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
    
}