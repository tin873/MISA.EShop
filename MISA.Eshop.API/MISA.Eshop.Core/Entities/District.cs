using System;

namespace MISA.Eshop.Core.Entities
{
    public class District : BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid DistrictId { get; set; }
        /// <summary>
        /// Tên Quận/Huyện
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// khóa ngoại
        /// </summary>
        public Guid? ProvinceId { get; set; }
    }
}
