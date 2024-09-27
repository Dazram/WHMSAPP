using Warehouse_Management_System.DataTransferObjects.DepartmentMaterialRequisitionDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class DepartmentMaterialRequisitionMappers 
    {
        public static DepartmentMaterialRequisitionDTO ToDepartmentMaterialRequisitionDTO(this DepartmentMaterialRequisition DepartmentMaterialRequisitionDTOModel)
        {
            return new DepartmentMaterialRequisitionDTO    
            {
                Date = DepartmentMaterialRequisitionDTOModel.Date,
                DMRId = DepartmentMaterialRequisitionDTOModel.DMRId,
                DepartmentName = DepartmentMaterialRequisitionDTOModel.DepartmentName,
                RequestorFirstName = DepartmentMaterialRequisitionDTOModel.RequestorFirstName,
                RequestorLastName = DepartmentMaterialRequisitionDTOModel.RequestorLastName,
                RequestedItem = DepartmentMaterialRequisitionDTOModel.RequestedItem,
                RequestedItem1 = DepartmentMaterialRequisitionDTOModel.RequestedItem1,
                RequestedItem2 = DepartmentMaterialRequisitionDTOModel.RequestedItem2,
                RequestedItem3 = DepartmentMaterialRequisitionDTOModel.RequestedItem3, 
                RequestedItem4 = DepartmentMaterialRequisitionDTOModel.RequestedItem4,
                RequestedItem5 = DepartmentMaterialRequisitionDTOModel.RequestedItem5
            };
        } 

        public static DepartmentMaterialRequisition ToDepartmentMaterialRequisitionFromDepartmentMaterialRequisitionDTO(this CreateDepartmentMaterialRequisitiontDTO departmentMaterialRequisitionDTO)
        {
            return new DepartmentMaterialRequisition
            {
                DepartmentName = departmentMaterialRequisitionDTO.DepartmentName,
                RequestorFirstName = departmentMaterialRequisitionDTO.RequestorFirstName,
                RequestorLastName = departmentMaterialRequisitionDTO.RequestorLastName,
                RequestedItem = departmentMaterialRequisitionDTO.RequestedItem,
                RequestedItem1 = departmentMaterialRequisitionDTO.RequestedItem1,
                RequestedItem2 = departmentMaterialRequisitionDTO.RequestedItem2,
                RequestedItem3 = departmentMaterialRequisitionDTO.RequestedItem3,
                RequestedItem4 = departmentMaterialRequisitionDTO.RequestedItem4,
                RequestedItem5 = departmentMaterialRequisitionDTO.RequestedItem5
            };
        } 
    }
}

         
        