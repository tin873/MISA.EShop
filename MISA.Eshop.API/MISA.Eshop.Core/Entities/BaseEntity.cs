using System;

namespace MISA.Eshop.Core.Entities
{
    //bắt buộc nhập dữ liệu
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public string CustomMsg = string.Empty;

        public Required(string customMsg = "")
        {
            CustomMsg = customMsg;
        }
    }

    // Lấy độ dài Property
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Length = 0;
        public string CustomMsg = string.Empty;

        public MaxLength(int maxLength = 0, string customrMsg = "")
        {
            Length = maxLength;
            CustomMsg = customrMsg;
        }
        /// <summary>
        /// lấy ra thông báo lỗi nếu vượt quá độ dài cho phép
        /// </summary>
        public string ErrorMaxLength
        {
            get
            {
                if (Length != 0)
                {
                    return CustomMsg;
                }
                return null;
            }
        }
    }
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa cuối
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
