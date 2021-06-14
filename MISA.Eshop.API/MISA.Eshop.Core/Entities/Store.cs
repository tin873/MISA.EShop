using System;

namespace MISA.Eshop.Core.Entities
{
    public class Store: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid StoreId { get; set; }
        /// <summary>
        /// mã cửa hàng
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string StoreCode { get; set; }
        /// <summary>
        /// tên cửa hàng
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string StoreName { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// mã tax cửa hàng
        /// </summary>
        public string StoreTaxCode { get; set; }
        /// <summary>
        /// khóa ngoại Quốc gia
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// tên quốc gia
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// khóa ngoại thành phố
        /// </summary>
        public Guid? ProvinceId { get; set; }
        /// <summary>
        /// tên thành phố
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// khóa ngoại quận/huyện
        /// </summary>
        public Guid DistrictId { get; set; }
        /// <summary>
        /// tên quận huyện
        /// </summary>
        public string DistrictName { get; set; }
        /// <summary>
        /// khóa ngoại xã/phường
        /// </summary>
        public Guid? WardId { get; set; }
        /// <summary>
        /// tên xã phường
        /// </summary>
        public string WardName { get; set; }
        /// <summary>
        /// tên đường phố
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// trạng thái cửa hàng (0- đang hoạt động. 1- đóng cửa)
        /// </summary>
        public bool? Status { get; set; }

    }
}
