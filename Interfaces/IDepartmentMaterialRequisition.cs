using Warehouse_Management_System.DataTransferObjects.DepartmentMaterialRequisitionDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Interfaces
{
    public interface IDepartmentMaterialRequisition
    {
        Task<List<DepartmentMaterialRequisition>> GetAllAsync();
        Task<DepartmentMaterialRequisition?> GetByIdAsync(int Id); 
        Task<DepartmentMaterialRequisition> CreateAsync(DepartmentMaterialRequisition departmentMaterialRequisitionModel);
        Task<DepartmentMaterialRequisition?> UpdateAsync(int Id, UpdateDepartmentMaterialRequisitionDTO departmentMaterialRequisition);
        Task<DepartmentMaterialRequisition?> DeleteAsync(int Id);
    }
}