using MISA.Eshop.Core.Entities;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Interfaces.IRepository
{
    public interface IStoreRepository: IBaseRepository<Store>
    {
        /// <summary>
        /// lấy danh sách nhân viên phân trang
        /// </summary>
        /// <param name="pageIndex">trang</param>
        /// <param name="pageSize">số bản ghi/1 trang</param>
        /// <returns>danh sách bản ghi theo trang</returns>
        /// createdBy: ndtin(14/06/2021)
        IEnumerable<Store> GetPaging(int pageSize, int pageIndex, 
            out int totalPage, out int totalRecord);
        /// <summary>
        /// kiểm tra mã code đã tồn tại chưa
        /// </summary>
        /// <param name="storeCode">mã code</param>
        /// <returns>bool</returns>
        /// createdBy: ndtin(14/06/2021)
        bool CheckStoreCodeExits(string storeCode);
        /// <summary>
        /// lọc danh sách cửa hàng theo mã, tên, địa chỉ, số điện thoại, trạng thái
        /// </summary>
        /// <param name="storeCode">mã cửa hàng</param>
        /// <param name="storeName">tên cửa hàng</param>
        /// <param name="address"> dịa chỉ</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="status">trạng thái</param>
        /// <returns>danh sách cửa hàng đã lọc</returns>
        /// createdBy: ndtin(14/06/2021)
        IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, 
            string address, string phoneNumber, int? status);
        /// <summary>
        /// lọc danh sách cửa hàng theo mã, tên, địa chỉ, số điện thoại, trạng thái
        /// </summary>
        /// <param name="storeCode">mã cửa hàng</param>
        /// <param name="storeName">tên cửa hàng</param>
        /// <param name="address"> dịa chỉ</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="status">trạng thái</param>
        /// <param name="pageIndex">trang</param>
        /// <param name="pageSize">số bản ghi/1 trang</param>
        /// <returns>danh sách cửa hàng đã lọc và theo phân trang</returns>
        /// createdBy: ndtin(14/06/2021)
        IEnumerable<Store> GetStoreFilterPaging(string storeCode, string storeName,
            string address, string phoneNumber, int? status,
            int pageSize, int pageIndex, out int totalPage,
            out int totalRecord);
    }
}
