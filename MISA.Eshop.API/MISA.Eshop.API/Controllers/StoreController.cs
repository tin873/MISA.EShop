using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IService;

namespace MISA.Eshop.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class StoreController : EShopBaseController<Store>
    {
        #region Declare
        IStoreService _storeService;
        #endregion
        #region Contructor
        public StoreController(IBaseService<Store> baseService, IStoreService storeService) : base(baseService)
        {
            _storeService = storeService;
        }
        #endregion
        #region methods
        /// <summary>
        /// lấy dữ liệu phân trang
        /// </summary>
        /// <param name="pageIndex">chỉ mục trang</param>
        /// <param name="pageSize">kích cỡ bản ghi 1 trang</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageSize, int pageIndex)
        {
            var result = _storeService.GetPaging(pageSize, pageIndex);
            return Ok(result);
        }
        /// <summary>
        /// lọc dữ liệu theo các trường
        /// </summary>
        /// <param name="storeCode">mã cửa hàng</param>
        /// <param name="storeName">tên cửa hàng</param>
        /// <param name="address">địa chỉ</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="status">trạng thái</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("filter")]
        public IActionResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status)
        {
            var result = _storeService.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            return Ok(result);
        }
        /// <summary>
        /// lọc dữ liệu theo các trường
        /// </summary>
        /// <param name="storeCode">mã cửa hàng</param>
        /// <param name="storeName">tên cửa hàng</param>
        /// <param name="address">địa chỉ</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// <param name="status">trạng thái</param>
        /// <param name="pageIndex">chỉ mục trang</param>
        /// <param name="pageSize">kích cỡ bản ghi 1 trang</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("filterPaging")]
        public IActionResult GetStoreFilterPaging(string storeCode, string storeName, string address, string phoneNumber, int? status, int pageSize, int pageIndex)
        {
            var result = _storeService.GetStoreFilterPaging(storeCode, storeName, address, phoneNumber, status, pageSize, pageIndex);
            return Ok(result);
        }
        /// <summary>
        /// kiểm tra mã cửa hàng tồn tại chưa
        /// </summary>
        /// <param name="storeCode"> mã cửa hàng</param>
        /// <returns>serviceRessult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("check/{storeCode}")]
        public IActionResult CheckStoreCodeExits(string storeCode)
        {
            var resutl = _storeService.CheckStoreCodeExits(storeCode);
            return Ok(resutl);
        }
        #endregion
    }
}
