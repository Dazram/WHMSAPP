using Warehouse_Management_System.DataTransferObjects.StoresIssueSlipDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class StoresIssueSlipMappers
    {
        public static StoresIssueSlipDTO ToStoresIssueSlipDTO(this StoresIssueSlip storesIssueSlipDTOModel)
        {
            return new StoresIssueSlipDTO
            {
                Date = storesIssueSlipDTOModel.Date,
                IssueNumber = storesIssueSlipDTOModel.IssueNumber,
                RequestorFirstName = storesIssueSlipDTOModel.RequestorFirstName,
                RequestorLastName = storesIssueSlipDTOModel.RequestorLastName,
                Department = storesIssueSlipDTOModel.Department,
                Item = storesIssueSlipDTOModel.Item,
                Quantity = storesIssueSlipDTOModel.Quantity,
                Purpose = storesIssueSlipDTOModel.Purpose
            };
        }

        public static StoresIssueSlip ToStoresIssueSlipFromStoresIssueSlipDTO(this CreateStoresIssueSlipDTO storesIssueSlipDTOModel)
        {
            return new StoresIssueSlip
            {
                RequestorFirstName = storesIssueSlipDTOModel.RequestorFirstName,
                RequestorLastName = storesIssueSlipDTOModel.RequestorLastName,
                Department = storesIssueSlipDTOModel.Department,
                Item = storesIssueSlipDTOModel.Item,
                Quantity = storesIssueSlipDTOModel.Quantity,
                Purpose = storesIssueSlipDTOModel.Purpose
            };
        }
    }
}