using System;

namespace MISA.Eshop.Core.CustomExceptions
{
    public class CustomException: Exception
    {
        public string UserMsg = string.Empty;

        public CustomException(string msg, object data = null) : base(msg, new Exception())
        {
            this.UserMsg = msg;
        }
    }
}
