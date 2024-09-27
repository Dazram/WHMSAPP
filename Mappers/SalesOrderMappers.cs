using Warehouse_Management_System.DataTransferObjects.SalesOrderDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class SalesOrderMappers
    {
        public static SalesOrderDTO ToSalesOrderDTO(this SalesOrderDTO salesOrderDTOModel)
        {
            return new SalesOrderDTO
            {
                    Date = salesOrderDTOModel.Date,
                    OrderId = salesOrderDTOModel.OrderId,
                    CustomerName = salesOrderDTOModel.CustomerName,
                    Destination = salesOrderDTOModel.Destination,
                    TransactionType = salesOrderDTOModel.TransactionType,
                    TotalAmount = salesOrderDTOModel.TotalAmount,
                    SoldProducts = salesOrderDTOModel.SoldProducts,
                    SoldProduct1 = salesOrderDTOModel.SoldProduct1,
                    SoldProduct2 = salesOrderDTOModel.SoldProduct2,
                    SoldProduct3 = salesOrderDTOModel.SoldProduct3,
                    SoldProduct4 = salesOrderDTOModel.SoldProduct4,
                    SoldProduct5 = salesOrderDTOModel.SoldProduct5,
                    SoldProduct6 = salesOrderDTOModel.SoldProduct6
            };
        }

        public static SalesOrder ToSalesOrderFromSalesOrderDTO(this CreateSalesOrderDTO salesOrderDTOModel)
        {
            return new SalesOrder
            {
                    CustomerName = salesOrderDTOModel.CustomerName,
                    Destination = salesOrderDTOModel.Destination,
                    TransactionType = salesOrderDTOModel.TransactionType,
                    TotalAmount = salesOrderDTOModel.TotalAmount,
                    SoldProducts = salesOrderDTOModel.SoldProducts,
                    SoldProduct1 = salesOrderDTOModel.SoldProduct1,
                    SoldProduct2 = salesOrderDTOModel.SoldProduct2,
                    SoldProduct3 = salesOrderDTOModel.SoldProduct3,
                    SoldProduct4 = salesOrderDTOModel.SoldProduct4,
                    SoldProduct5 = salesOrderDTOModel.SoldProduct5,
                    SoldProduct6 = salesOrderDTOModel.SoldProduct6
            };
        }

    }
}