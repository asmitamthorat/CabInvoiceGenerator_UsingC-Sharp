using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepo = new Dictionary<string,List<Ride>>();



        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceGenerator.CabInvoiceException">Provided user ID is empty</exception>
        public void  AddUser(string userID, List<Ride> rides) {

            if (userID.Length==0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.BLANK_USERID, "Provided user ID is empty");

            }

            rideRepo.Add(userID, rides);
        
        }

        /// <summary>
        /// Gets the invoice summary.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rideType">Type of the ride.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceGenerator.CabInvoiceException">Provided user ID is empty</exception>
        public InvoiceSummary GetInvoiceSummary(string userID,RideType rideType)
        {
            if (!rideRepo.ContainsKey(userID)) {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVAILD_USERID, "Provided user ID is empty");
            
            }

            Invoicegenerator invoicegenerator = new Invoicegenerator();
            InvoiceSummary  invoiceSummary=invoicegenerator.CalculateFare(rideRepo[userID],rideType);
            
            return invoiceSummary;
        }
    }
}
