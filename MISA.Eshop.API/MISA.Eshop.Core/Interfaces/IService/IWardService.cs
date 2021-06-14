using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Interfaces.IService
{
    public interface IWardService
    {
        /// <summary>
        /// lấy danh sách phường/ xã theo quận/huyện
        /// </summary>
        /// <param name="ProvinceId">khóa bảng quận/huyện</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(14/6/2021)
        ServiceResult GetWardWithDistrict(Guid DistrictId);
    }
}
