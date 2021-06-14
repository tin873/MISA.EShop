using System;

namespace MISA.Eshop.Core.Entities
{
    public class Country : BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// Tên Quốc gia
        /// </summary>
        public string CountryName { get; set; }
    }
}
