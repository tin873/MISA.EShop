using MISA.Eshop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Interfaces.IRepository
{
    public interface IWardRepository: IBaseRepository<Ward>
    {
        /// <summary>
        /// lấy danh sách phường/ xã theo quận/huyện
        /// </summary>
        /// <param name="ProvinceId">khóa bảng quận/huyện</param>
        /// <returns>danh sách phường/xã</returns>
        /// createdBy: ndtin(14/6/2021)
        IEnumerable<Ward> GetWardWithDistrict(Guid DistrictId);
    }
}
