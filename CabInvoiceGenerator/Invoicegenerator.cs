﻿using System;
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
    }
}
