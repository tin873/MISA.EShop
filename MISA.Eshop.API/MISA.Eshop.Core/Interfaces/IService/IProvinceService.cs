using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Interfaces.IService
{
    public interface IProvinceService
    {
        /// <summary>
        /// lấy danh sách thành phố theo quốc gia
        /// </summary>
        /// <param name="ProvinceId">khóa bảng quốc gia</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(14/6/2021)
        ServiceResult GetProvincetWithCountry(Guid CountryId);
    }
}
