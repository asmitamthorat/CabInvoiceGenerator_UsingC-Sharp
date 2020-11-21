using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Invoicegenerator
    {
        private static  int COST_PER_TIME = 1;
        private static  int COST_PER_KILOMETER = 10;
        private static int minimumFare = 5;
        public double calculateFare(double distance,double time) {

            double fare = distance * COST_PER_KILOMETER + time * COST_PER_TIME;
            return Math.Max(fare, minimumFare);
        
        }

        public InvoiceSummary calculateFare(Ride[] rides)
        {

            double totalFare = 0;
            foreach (Ride ride in rides) {
                double fare = calculateFare(ride.distance, ride.time);
                 totalFare = totalFare + fare;
            }
            return new InvoiceSummary(rides.Length,totalFare,totalFare/rides.Length);
        }

        internal InvoiceSummary calculateFare(List<Ride> rides,RideType rideType)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                double fare = Fare.CalculateFare(rideType,ride.distance, ride.time);
                totalFare = totalFare + fare;
            }
            return new InvoiceSummary(rides.Count, totalFare, totalFare / rides.Count);
        }
/*
        public void AddUserRides(string userID, Ride[] rides)
        {
            RideRepository rideRepository = new RideRepository();
            rideRepository.addUser(userID, rides);
        }
*/
       
    }
}
