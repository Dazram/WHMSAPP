using Warehouse_Management_System.DataTransferObjects.WarehouseStockDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class WarehouseStockMappers
    {
        public static WarehouseStockDTO ToWarehouseStockDTO(this WarehouseStock warehouseStockDTOModel)
        {
            return new WarehouseStockDTO
            {
                Date = warehouseStockDTOModel.Date,
                ProductId = warehouseStockDTOModel.ProductId,
                ProductName = warehouseStockDTOModel.ProductName,
                OpeningBalance = warehouseStockDTOModel.OpeningBalance,
                Production = warehouseStockDTOModel.Production,
                SalesDispatch = warehouseStockDTOModel.SalesDispatch,
                Samples = warehouseStockDTOModel.Samples,
                Returns = warehouseStockDTOModel.Returns,
                ClosingBalance  = warehouseStockDTOModel.ClosingBalance
            };
        }

        public static WarehouseStock ToWarehousestockFromWarehousestockDTO(this CreateWarehouseStockDTO warehouseStockDTOModel)
        {
            return new WarehouseStock
            {
                ProductName = warehouseStockDTOModel.ProductName,
                OpeningBalance = warehouseStockDTOModel.OpeningBalance,
                Production = warehouseStockDTOModel.Production,
                SalesDispatch = warehouseStockDTOModel.SalesDispatch,
                Samples = warehouseStockDTOModel.Samples,
                Returns = warehouseStockDTOModel.Returns,
                ClosingBalance  = warehouseStockDTOModel.ClosingBalance
            };
        }
    }
}