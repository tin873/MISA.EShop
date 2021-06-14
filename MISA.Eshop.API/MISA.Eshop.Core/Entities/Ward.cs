using System;

namespace MISA.Eshop.Core.Entities
{
    public class Ward: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid WardId { get; set; }
        /// <summary>
        /// Tên Xã/Phường
        /// </summary>
        public string WardName { get; set; }
        /// <summary>
        /// khóa ngoại
        /// </summary>
        public Guid? DistrictId { get; set; }
    }
}
