// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CabInvoiceGenerator.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Asmita Thorat"/>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class Invoicegenerator
    {

        Fare fare = new Fare();

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public double CalculateFare(double distance,double time) {

            double fareAmount = distance * fare.NORMAL_COST_PER_KILOMETER + time * fare.NORMAL_COST_PER_MINUTE;
            return Math.Max(fareAmount, fare.NORMAL_MINIMUM_FARE);
        
        }


        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <param name="rideType">Type of the ride.</param>
        /// <returns></returns>
        /// 
        public InvoiceSummary CalculateFare(List<Ride> rides,RideType rideType)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                double fareAmount = CalculateFare(rideType,ride.distance, ride.time);
                totalFare = totalFare + fareAmount;
            }
            return new InvoiceSummary(rides.Count, totalFare, totalFare / rides.Count);
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">Invalid Ride Type</exception>

        public double CalculateFare(RideType rideType, double distance, int time)
        {
            switch (rideType)
            {

                case RideType.NORMAL_RIDE:
                    return Math.Max(distance * fare.NORMAL_COST_PER_KILOMETER + time * fare.NORMAL_COST_PER_MINUTE, fare.NORMAL_MINIMUM_FARE);

                case RideType.PREMIUM_RIDE:
                    return Math.Max(distance * fare.PREMIUM_COST_PER_KILOMETER + time * fare.PREMIUM_COST_PER_MINUTE, fare.PREMIUM_MINIMUM_FARE);
                default:
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVAILD_RIDE_TYPE, "Invalid Ride Type");
            }

        }




    }
}
