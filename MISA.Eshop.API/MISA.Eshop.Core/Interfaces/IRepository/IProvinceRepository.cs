using MISA.Eshop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Interfaces.IRepository
{
    public interface IProvinceRepository: IBaseRepository<Province>
    {
        /// <summary>
        /// lấy danh sách thành phố theo quốc gia
        /// </summary>
        /// <param name="ProvinceId">khóa bảng quốc gia</param>
        /// <returns>danh sách thành phố</returns>
        /// createdBy: ndtin(14/6/2021)
        IEnumerable<Province> GetProvincetWithCountry(Guid CountryId);
    }
}
