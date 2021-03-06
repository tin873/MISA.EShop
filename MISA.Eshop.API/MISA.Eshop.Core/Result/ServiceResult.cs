using MISA.Eshop.Core.Enums;
using System.Collections.Generic;

namespace MISA.Eshop.Core.Result
{
    public class ServiceResult
    {
        /// <summary>
        /// trạng thái thao tác (true- thành công . false-thất bại)
        /// </summary>
        public bool IsSuccess { get; set; } = true;
        /// <summary>
        /// dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// danh sách thông báo lỗi cho người dùng
        /// </summary>
        public List<string> UserMsg { get; set; }
        /// <summary>
        /// thông báo lỗi cho dev
        /// </summary>
        public string DevMsg { get; set; }
        /// <summary>
        /// mã code lỗi
        /// </summary>
        public MISACode MISACode { get; set; }
        /// <summary>
        /// tổng số trang
        /// </summary>
        public  int TotalPage { get; set; }
        /// <summary>
        /// tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// constructor khởi tạo danh sách thông báo cho người dùng
        /// </summary>
        public ServiceResult()
        {
            this.UserMsg = new List<string>();
        }
    }
}
