using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Entities;
using MISA.Eshop.Core.Interfaces.IService;
using System;

namespace MISA.Eshop.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ProvinceController : EShopBaseController<Province>
    {
        #region Declare
        IProvinceService _provinceService;
        #endregion
        #region Contructor
        public ProvinceController(IBaseService<Province> baseService, IProvinceService provinceService) : base(baseService)
        {
            _provinceService = provinceService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// lấy danh sách Thành phố theo quốc gia
        /// </summary>
        /// <param name="id">khóa Quốc gia</param>
        /// <returns>ServiceResult</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("GetProvincetWithCountry/{id}")]
        public IActionResult GetProvincetWithCountry(Guid id)
        {
            var result = _provinceService.GetProvincetWithCountry(id);
            return Ok(result);
        }
        #endregion
    }
}
