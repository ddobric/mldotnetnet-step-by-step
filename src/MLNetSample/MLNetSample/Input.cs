using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLNetSample
{
    /// <summary>
    /// vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
    /// </summary>
    public class Input
    {
        [LoadColumn(0)]
        public int VendorId { get; set; }

        [LoadColumn(1)]
        public int RateCode { get; set; }

        [LoadColumn(2)]
        public int PassangerCount { get; set; }

        [LoadColumn(3)]
        public int TripTime { get; set; }

        [LoadColumn(4)]
        public double TripDistance{ get; set; }

        [LoadColumn(5)]
        public int PaymentType { get; set; }

        [LoadColumn(6)]
        public double Amount{ get; set; }


    }
}
