using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IService;
using System;

namespace MISA.Eshop.API.Controllers
{
    public class DistrictController : EShopBaseController<District>
    {
        #region Declare
        IDistrictService _districtService;
        #endregion
        #region Contructor
        public DistrictController(IBaseService<District> baseService, IDistrictService districtService) : base(baseService)
        {
            _districtService = districtService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// lấy danh sách Quận/ Huyện theo thành phố
        /// </summary>
        /// <param name="id">khóa Thành phố</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("GetDistrictWithProvince/{id}")]
        public IActionResult GetDistrictWithProvince(Guid id)
        {
            var result = _districtService.GetDistrictWithProvince(id);
            return Ok(result);
        }
        #endregion
    }
}
