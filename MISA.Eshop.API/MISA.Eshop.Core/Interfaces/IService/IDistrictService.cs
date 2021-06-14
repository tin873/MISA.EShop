using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Interfaces.IService
{
    public interface IDistrictService
    {
        /// <summary>
        /// lấy danh sách quận/huyện theo thành phố
        /// </summary>
        /// <param name="ProvinceId">khóa bảng thành phố</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(14/6/2021)
        ServiceResult GetDistrictWithProvince(Guid ProvinceId);
    }
}
