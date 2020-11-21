using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public enum RideType
    {
        NORMAL_RIDE,
        PREMIUM_RIDE
    }

    public static class Fare {
        public static int NORMAL_COST_PER_KILOMETER = 10;
        const int NORMAL_COST_PER_MINUTE = 1;
        const int NORMAL_MINIMUM_FARE = 5;

        const int PREMIUM_COST_PER_KILOMETER = 15;
        const int PREMIUM_COST_PER_MINUTE = 2;
        const int PREMIUM_MINIMUM_FARE = 20;


        public static double CalculateFare(this RideType rideType, double distance, int time)
        {
            switch (rideType) {

                case RideType.NORMAL_RIDE:
                    return Math.Max(distance * NORMAL_COST_PER_KILOMETER + time * NORMAL_COST_PER_MINUTE, NORMAL_MINIMUM_FARE);
                   
                case RideType.PREMIUM_RIDE:
                    return Math.Max(distance * PREMIUM_COST_PER_KILOMETER + time * PREMIUM_COST_PER_MINUTE, PREMIUM_MINIMUM_FARE);
                default:
                     throw new  CabInvoiceException(CabInvoiceException.ExceptionType.INVAILD_RIDE_TYPE, "Invalid Ride Type");
        }

        }

    }
}
