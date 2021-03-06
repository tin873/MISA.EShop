using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MISA.Eshop.Core.Interfaces.IService;
using System;

namespace MISA.Eshop.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EShopBaseController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion
        #region Contructor
        public EShopBaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// lấy tất cả thông tin trong bảng
        /// </summary>
        /// <returns>Serviceresult bao gồm (data và thông báo)</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet]
        public virtual IActionResult Get()
        {
            var result = _baseService.GetEntities();
            return Ok(result);
        }
        /// <summary>
        /// lấy bản ghi theo mã
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>Serviceresult bao gồm (data và thông báo)</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id)
        {
            var result = _baseService.GetById(id);
            return Ok(result);
        }
        /// <summary>
        /// Thêm mới 1 bản ghi vào bảng
        /// </summary>
        /// <param name="entity"> thực thể</param>
        /// <returns>ServiceReuslt bao gồm (data và thông báo)</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpPost]
        public virtual IActionResult Post([FromBody] T entity)
        {
            var result = _baseService.Insert(entity);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        /// <summary>
        /// Sửa đổi 1 bản ghi trong bảng
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <param name="entity"> thực thể</param>
        /// <returns>ServiceResult bao gồm (data và thông báo)</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] T entity ,Guid id)
        {
            var result = _baseService.Update(entity, id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        /// <summary>
        /// Xóa 1 bản ghi trong bảng
        /// </summary>
        /// <param name="id"></param>
        /// <returns>serviceResult bao gồm (data và thông báo)</returns>
        /// createdBy: ndtin(15/6/2021)
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            var result = _baseService.Delete(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }
        #endregion
    }
}
