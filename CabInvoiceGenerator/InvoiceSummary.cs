using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int numberOfRide;
        public double totalFare;
        public double avgFarePerRide;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="numberOfRide">The number of ride.</param>
        /// <param name="totalFare">The total fare.</param>
        /// <param name="avgFarePerRide">The average fare per ride.</param>

        public InvoiceSummary(int numberOfRide, double totalFare, double avgFarePerRide)
        {
            this.numberOfRide = numberOfRide;
            this.totalFare = totalFare;
            this.avgFarePerRide = avgFarePerRide;
        }

        public override bool Equals(object that)
        {
            if (this == that)
                return true;
            if (this == null)
                return false;
            InvoiceSummary obj = (InvoiceSummary)that;
            return this.numberOfRide == obj.numberOfRide
                && this.totalFare == obj.totalFare
                && this.avgFarePerRide == obj.avgFarePerRide;
        }
    }
}
