using Microsoft.EntityFrameworkCore;
using Warehouse_Management_System.Data;
using Warehouse_Management_System.DataTransferObjects.DepartmentMaterialRequisitionDTOs;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Repository
{
    public class DepartmentMaterialRequisitionRepository : IDepartmentMaterialRequisition
    {   
        private readonly ApplicationDBContext _context;
        public DepartmentMaterialRequisitionRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<DepartmentMaterialRequisition> CreateAsync(DepartmentMaterialRequisition departmentMaterialRequisitionModel)
        {
            await _context.DepartmentMaterialRequisitions.AddAsync(departmentMaterialRequisitionModel);
            await _context.SaveChangesAsync();
            return departmentMaterialRequisitionModel;
        }

        public async Task<DepartmentMaterialRequisition?> DeleteAsync(int Id)
        {
            var departmentMaterialRequisitionModel = await _context.DepartmentMaterialRequisitions.FirstOrDefaultAsync(x => x.DMRId == Id);
            if( departmentMaterialRequisitionModel == null)
            {
                return null;
            }

            _context.DepartmentMaterialRequisitions.Remove(departmentMaterialRequisitionModel);
            await _context.SaveChangesAsync();
            return departmentMaterialRequisitionModel;
        }

        public async Task<List<DepartmentMaterialRequisition>> GetAllAsync()
        {
            return await _context.DepartmentMaterialRequisitions.ToListAsync();
        }

        public async Task<DepartmentMaterialRequisition?> GetByIdAsync(int Id)
        {
            return await _context.DepartmentMaterialRequisitions.FindAsync(Id);
        }

        public async Task<DepartmentMaterialRequisition?> UpdateAsync(int Id, UpdateDepartmentMaterialRequisitionDTO departmentMaterialRequisition)
        {
            var departmentMaterialRequisitionModel = await _context.DepartmentMaterialRequisitions.FirstOrDefaultAsync(x => x.DMRId == Id);

            if(departmentMaterialRequisitionModel == null)
            {
                return null;
            }

            departmentMaterialRequisitionModel.DepartmentName = departmentMaterialRequisition.DepartmentName;
            departmentMaterialRequisitionModel.RequestorFirstName = departmentMaterialRequisition.RequestorFirstName;
            departmentMaterialRequisitionModel.RequestorLastName = departmentMaterialRequisition.RequestorLastName;
            departmentMaterialRequisitionModel.RequestedItem = departmentMaterialRequisition.RequestedItem;
            departmentMaterialRequisitionModel.RequestedItem1 = departmentMaterialRequisition.RequestedItem1;
            departmentMaterialRequisitionModel.RequestedItem2 = departmentMaterialRequisition.RequestedItem2;
            departmentMaterialRequisitionModel.RequestedItem3 = departmentMaterialRequisition.RequestedItem3;
            departmentMaterialRequisitionModel.RequestedItem4 = departmentMaterialRequisition.RequestedItem4;
            departmentMaterialRequisitionModel.RequestedItem5 = departmentMaterialRequisition.RequestedItem5;

            await _context.SaveChangesAsync();
            return departmentMaterialRequisitionModel;
        }
    }
}