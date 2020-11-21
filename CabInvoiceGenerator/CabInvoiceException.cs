using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException:Exception
    {
        public enum ExceptionType
        {

            INVAILD_USERID,INVAILD_RIDE_TYPE,BLANK_USERID
        }
        public readonly ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
