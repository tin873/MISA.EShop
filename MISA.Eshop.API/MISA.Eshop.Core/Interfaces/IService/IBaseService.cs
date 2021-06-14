using MISA.Eshop.Core.Result;
using System;

namespace MISA.Eshop.Core.Interfaces.IService
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>serviceResult</returns>
        /// CreatedBy:ndtin(14/6/2021)
        ServiceResult GetEntities();
        /// <summary>
        /// lấy thông tin của entity theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>serviceResult</returns>
        /// CreatedBy:ndtin(14/6/2021)
        ServiceResult GetById(Guid entityId);
        /// <summary>
        /// thêm mới entity vào bảng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>serviceResult</returns>
        /// CreatedBy:ndtin(14/6/2021)
        ServiceResult Insert(T entity);
        /// <summary>
        /// Sửa thông tin entity
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <param name="entityId">id thực thể</param>
        /// <returns>serviceResult</returns>
        /// CreatedBy:ndtin(14/6/2021)
        ServiceResult Update(T entity, Guid entityId);
        /// <summary>
        /// Xóa thực thể khỏi bảng
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>serviceResult</returns>
        /// CreatedBy:ndtin(14/6/2021)
        ServiceResult Delete(Guid entityId);
    }
}
