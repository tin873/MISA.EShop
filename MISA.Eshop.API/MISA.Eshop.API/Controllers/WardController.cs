using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IService;
using System;

namespace MISA.Eshop.API.Controllers
{
    public class WardController : EShopBaseController<Ward>
    {
        #region Declare
        IWardService _wardService;
        #endregion
        #region Contructor
        public WardController(IBaseService<Ward> baseService, IWardService wardService) : base(baseService)
        {
            _wardService = wardService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// lấy danh sách Xã/ Phường theo Quận Huyên
        /// </summary>
        /// <param name="id">khóa Quận huyện</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("GetWardWithDistrict/{id}")]
        public IActionResult GetWardWithDistrict(Guid id)
        {
            var result = _wardService.GetWardWithDistrict(id);
            return Ok(result);
        }
        #endregion
    }
}
