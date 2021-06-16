using MISA.Eshop.Core.Result;

namespace MISA.Eshop.Core.Interfaces.IService
{
    public interface IStoreService
    {
        /// <summary>
        /// lấy danh sách nhân viên phân trang
        /// </summary>
        /// <param name="pageIndex">trang</param>
        /// <param name="pageSize">số bản ghi/1 trang</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(14/06/2021)
        ServiceResult GetPaging(int pageSize, int pageIndex);
        /// <summary>
        /// lọc danh sách cửa hàng theo mã, tên, địa chỉ, số điện thoại, trạng thái
        /// </summary>
        /// <param name="storeCode">mã cửa hàng</param>
        /// <param name="storeName">tên cửa hàng</param>
        /// <param name="address"> dịa chỉ</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="status">trạng thái</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(14/06/2021)
        ServiceResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int status);
        /// <summary>
        /// kiểm tra mã code đã tồn tại chưa
        /// </summary>
        /// <param name="storeCode">mã code</param>
        /// <returns>serviceResult</returns>
        /// createdBy: ndtin(14/06/2021)
        ServiceResult CheckStoreCodeExits(string storeCode);
    }
}
