using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepo = new Dictionary<string,List<Ride>>();

       public void  addUser(string userID, List<Ride> rides) {

            rideRepo.Add(userID, rides);
        
        }

        public InvoiceSummary getInvoiceSummary(string userID)
        {
           // List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
           // rideRepo.Add("sangli", rides);

            Invoicegenerator invoicegenerator = new Invoicegenerator();
            InvoiceSummary  invoiceSummary=invoicegenerator.calculateFare(rideRepo[userID]);
           // Console.WriteLine(rideRepo["sangli"]);
            return invoiceSummary;
           
            
           



        }
    }
}
