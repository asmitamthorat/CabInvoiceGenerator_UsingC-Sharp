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
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

    }
}
