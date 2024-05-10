using Warehouse_Management_System.DataTransferObjects.DispatchDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class DispatchMappers
    {
        public static DispatchDTO ToDispatchDTO(this Dispatch dispatchDTOModel)
        {   
            return new DispatchDTO
            {
                DispatchDate = dispatchDTOModel.DispatchDate,
                DispatchId = dispatchDTOModel.DispatchId,
                SalesOrderNumber = dispatchDTOModel.SalesOrderNumber,
                CustomerName = dispatchDTOModel.CustomerName,
                ProductName = dispatchDTOModel.ProductName,
                QuantityDispatched = dispatchDTOModel.QuantityDispatched,
                ProductName1 = dispatchDTOModel.ProductName1,
                QuantityDispatched1 = dispatchDTOModel.QuantityDispatched1,
                ProductName2 = dispatchDTOModel.ProductName2,
                QuantityDispatched2 = dispatchDTOModel.QuantityDispatched2,
                ProductName3 = dispatchDTOModel.ProductName3,
                QuantityDispatched3 = dispatchDTOModel.QuantityDispatched3
            };

        }

        public static Dispatch ToDispatchFromDispatchDTO(this CreateDispatchDTO dispatchDTOModel)
        {
            return new Dispatch
            {
                SalesOrderNumber = dispatchDTOModel.SalesOrderNumber,
                CustomerName = dispatchDTOModel.CustomerName,
                ProductName = dispatchDTOModel.ProductName,
                QuantityDispatched = dispatchDTOModel.QuantityDispatched,
                ProductName1 = dispatchDTOModel.ProductName1,
                QuantityDispatched1 = dispatchDTOModel.QuantityDispatched1,
                ProductName2 = dispatchDTOModel.ProductName2,
                QuantityDispatched2 = dispatchDTOModel.QuantityDispatched2,
                ProductName3 = dispatchDTOModel.ProductName3,
                QuantityDispatched3 = dispatchDTOModel.QuantityDispatched3       
            };
        }

    }
}