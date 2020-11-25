using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLNetSample
{
    public class Input1
    {
        [LoadColumn(0)]
        public float Size { get; set; }

        [LoadColumn(1, 3)]
        [VectorType(3)]
        public float[] HistoricalPrices { get; set; }

        [LoadColumn(4)]
        [ColumnName("Label")]
        public float CurrentPrice { get; set; }

    }
}
