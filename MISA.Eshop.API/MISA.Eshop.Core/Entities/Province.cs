using System;

namespace MISA.Eshop.Core.Entities
{
    public class Province: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid ProvinceId { get; set; }
        /// <summary>
        /// Tên tỉnh/Thành phố
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// khóa ngoại
        /// </summary>
        public Guid? CountryId { get; set; }
    }
}
