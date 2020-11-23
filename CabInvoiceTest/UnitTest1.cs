using CabInvoiceGenerator;
using NUnit.Framework;
using System.Collections.Generic;

namespace CabInvoiceTest
{
    public class Tests
    {
        
        [Test]
        public void givenDistanceAndTime_ShouldReturnFare()
        {
            Invoicegenerator invoiceGenerator = new Invoicegenerator();
            double distance = 2.0;
            int time = 5;
            double fare=invoiceGenerator.CalculateFare(distance,time);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void givenless_DistanceAndTime_ShouldReturnMinimumFare() {
            Invoicegenerator invoiceGenerator = new Invoicegenerator();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5, fare);
        }     
       
        [Test]

        public void givenMultipleRide_shouldReturnInvoiceSummary()
        {
            List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
            InvoiceSummary Expectedsummary = new InvoiceSummary(2,50,25);
            Invoicegenerator invoiceGenerator = new Invoicegenerator();
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides,RideType.NORMAL_RIDE);
            Assert.AreEqual(Expectedsummary, summary);
        }

        

        [Test]
        public void GivenPremiumRide_WhenToCalculateFare_ShouldReturnPremiumFare() {
            string userID = "sangli";
            List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddUser(userID, rides);
            InvoiceSummary summary = rideRepository.GetInvoiceSummary("sangli",RideType.PREMIUM_RIDE);
            InvoiceSummary Expectedsummary = new InvoiceSummary(2,80 ,40 );
            Assert.AreEqual(Expectedsummary, summary);
        }
        

        [Test]
        public void GivenNormalRide_WhenToCalculateFare_ShouldReturnNormalFare() {

            string userID = "sangli";
            List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddUser(userID, rides);
            InvoiceSummary summary = rideRepository.GetInvoiceSummary("sangli",RideType.NORMAL_RIDE);
            InvoiceSummary Expectedsummary = new InvoiceSummary(2, 50, 25);
            Assert.AreEqual(Expectedsummary, summary);
        }

        [Test]
        public void givenUserId_WhenInCorrect_ShouldThrowInvalidUserException() {
            try {
                string userID = "pune";
                List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddUser(userID, rides);
                InvoiceSummary summary = rideRepository.GetInvoiceSummary("sangli", RideType.NORMAL_RIDE);
            }
            catch (CabInvoiceException e) {
                Assert.AreEqual(CabInvoiceException.ExceptionType.INVAILD_USERID, e.type);
            
            }  
        
        }



        [Test]
        public void givenUserId_WhenInblank_ShouldThrowblankUserException()
        {
            try
            {
                string userID = "";
                List<Ride> rides = new List<Ride> { new Ride(2.0, 5), new Ride(2.0, 5) };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddUser(userID, rides);
                
            }
            catch (CabInvoiceException e)
            {
                Assert.AreEqual(CabInvoiceException.ExceptionType.BLANK_USERID, e.type);

            }
        }
    }
}