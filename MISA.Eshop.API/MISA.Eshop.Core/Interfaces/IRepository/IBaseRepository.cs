using System;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Interfaces.IRepository
{
    /// <summary>
    /// Interface BaseRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// CreatedBy:ndtin(14/6/2021)
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        /// CreatedBy:ndtin(14/6/2021)
        IEnumerable<T> GetEntities();
        /// <summary>
        /// lấy thông tin của entity theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>T</returns>
        /// CreatedBy:ndtin(14/6/2021)
        T GetById(Guid entityId);
        /// <summary>
        /// thêm mới entity vào bảng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>int or null</returns>
        /// CreatedBy:ndtin(14/6/2021)
        int? Insert(T entity);
        /// <summary>
        /// Sửa thông tin entity
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <param name="entityId">id thực thể</param>
        /// <returns>int or null</returns>
        /// CreatedBy:ndtin(14/6/2021)
        int? Update(T entity, Guid entityId);
        /// <summary>
        /// Xóa thực thể khỏi bảng
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>int or null</returns>
        /// CreatedBy:ndtin(14/6/2021)
        int? Delete(Guid entityId);
    }
}
