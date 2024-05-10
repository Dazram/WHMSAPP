using Warehouse_Management_System.DataTransferObjects.StoresGoodsReceivedVoucherDTOs;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Mappers
{
    public static class StoresGoodsReceivedVoucherappers
    {
        public static StoresGoodsReceivedVoucherDTO ToStoresGoodsReceivedVoucherDTO(this StoresGoodsReceivedVoucherDTO storesGoodsReceivedVoucherModel)
        {
            return new StoresGoodsReceivedVoucherDTO
            {
                Date = storesGoodsReceivedVoucherModel.Date,
                GRVNumber = storesGoodsReceivedVoucherModel.GRVNumber,
                Supplier = storesGoodsReceivedVoucherModel.Supplier,
                ProductName = storesGoodsReceivedVoucherModel.ProductName,
                DeliveryNoteNumber = storesGoodsReceivedVoucherModel.DeliveryNoteNumber,
                Quantity = storesGoodsReceivedVoucherModel.Quantity,
                Description = storesGoodsReceivedVoucherModel.Description,
                OffloadingAuthorisationNumber = storesGoodsReceivedVoucherModel.OffloadingAuthorisationNumber,
                DriverFirstName = storesGoodsReceivedVoucherModel.DriverFirstName,
                DriverLastName = storesGoodsReceivedVoucherModel.DriverLastName
            };
        }

        public static StoresGoodsReceivedVoucher ToStoresGoodsReceivedVoucherFromStoresGoodsReceivedVoucherDTO(this CreateStoresReceivedVoucherDTO storesGoodsReceivedVoucherModel)
        {
            return new StoresGoodsReceivedVoucher
            {
                Supplier = storesGoodsReceivedVoucherModel.Supplier,
                ProductName = storesGoodsReceivedVoucherModel.ProductName,
                DeliveryNoteNumber = storesGoodsReceivedVoucherModel.DeliveryNoteNumber,
                Quantity = storesGoodsReceivedVoucherModel.Quantity,
                Description = storesGoodsReceivedVoucherModel.Description,
                OffloadingAuthorisationNumber = storesGoodsReceivedVoucherModel.OffloadingAuthorisationNumber,
                DriverFirstName = storesGoodsReceivedVoucherModel.DriverFirstName,
                DriverLastName = storesGoodsReceivedVoucherModel.DriverLastName
            };
        }
    }
}