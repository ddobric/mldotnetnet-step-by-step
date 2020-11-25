using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MLNetSample
{
    public class Sample3
    {
        /// <summary>
        /// Data transformations
        /// https://docs.microsoft.com/en-us/dotnet/machine-learning/resources/transforms
        /// </summary>
        public static void Run()
        {
            MLContext ctx = new MLContext(42);

            IDataView view = ctx.Data.LoadFromTextFile<Row>("files/sample3.csv", separatorChar: ',', hasHeader: true);

            var pipeline = ctx.Transforms.Concatenate("AllFeaturesInOne", "Education", "MaritalStatus");

            var concatView = pipeline.Fit(view).Transform(view);

            var originalData = ctx.Data.CreateEnumerable<RowWithAllFeatures>(concatView, reuseRowObject:false);

            foreach (var item in originalData)
            {
                Console.WriteLine($"{String.Join(",", item.AllFeaturesInOne)}], {item.Education}, {item.MaritalStatus}");
            }
        }


        private class Row
        {
            [LoadColumn(0)]
            public int Label { get; set; }

            [LoadColumn(1)]
            public string Education { get; set; }

            [LoadColumn(2)]
            public string MaritalStatus { get; set; }
        }

        private class RowWithAllFeatures : Row
        {
            public string[] AllFeaturesInOne { get; set; }
        }

    }
}
