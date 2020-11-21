using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepo = new Dictionary<string,List<Ride>>();

       public void  addUser(string userID, List<Ride> rides) {

            if (userID.Length==0)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.BLANK_USERID, "Provided user ID is empty");

            }

            rideRepo.Add(userID, rides);
        
        }

        public InvoiceSummary getInvoiceSummary(string userID,RideType rideType)
        {
            if (!rideRepo.ContainsKey(userID)) {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVAILD_USERID, "Provided user ID is empty");
            
            }

            Invoicegenerator invoicegenerator = new Invoicegenerator();
            InvoiceSummary  invoiceSummary=invoicegenerator.calculateFare(rideRepo[userID],rideType);
            
            return invoiceSummary;
           
            
           



        }
    }
}
