using MISA.Eshop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Interfaces.IRepository
{
    public interface IDistrictRepository: IBaseRepository<District>
    {
        /// <summary>
        /// lấy danh sách quận/huyện theo thành phố
        /// </summary>
        /// <param name="ProvinceId">khóa bảng thành phố</param>
        /// <returns>danh sách quận/huyện</returns>
        /// createdBy: ndtin(14/6/2021)
        IEnumerable<District> GetDistrictWithProvince(Guid ProvinceId);
    }
}
