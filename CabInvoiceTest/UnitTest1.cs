using CabInvoiceGenerator;
using NUnit.Framework;

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
            double fare=invoiceGenerator.calculateFare(distance,time);
            Assert.AreEqual(25, fare);
        }
    }
}