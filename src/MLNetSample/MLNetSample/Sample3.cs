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
        /// Featurization
        /// https://dotnet.microsoft.com/learn/ml-dotnet/what-is-mldotnet
        /// </summary>
        public static void Run()
        {
            MLContext ctx = new MLContext(42);

            IDataView originalDataView = ctx.Data.LoadFromTextFile<Row>("files/sample3.csv", separatorChar: ',', hasHeader: true);

            var concatPipeline = ctx.Transforms.Concatenate("AllFeaturesInOne", "Education", "MaritalStatus");

            var concatView = concatPipeline.Fit(originalDataView).Transform(originalDataView);

            var concatEnumData = ctx.Data.CreateEnumerable<RowWithAllFeatures>(concatView, reuseRowObject:false);

            foreach (var item in concatEnumData)
            {
                Console.WriteLine($"{String.Join(",", item.AllFeaturesInOne)}], {item.Education}, {item.MaritalStatus}");
            }


            IEstimator<ITransformer> featurizedPipeline = ctx.Transforms.Text.FeaturizeText("Features", "AllFeaturesInOne");

            var featurizedView = featurizedPipeline.Fit(concatView).Transform(concatView);

            var featurizedEnumData = ctx.Data.CreateEnumerable<FactorizedRow>(featurizedView, reuseRowObject: false);

            foreach (var item in featurizedEnumData)
            {
                Console.WriteLine($"{String.Join(",", item.AllFeaturesInOne)}], {item.Education}, {item.MaritalStatus}, {Program.StringifyDenseVector(item.Features)}");
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

        private class FactorizedRow : RowWithAllFeatures
        {
            public VBuffer<Single> Features { get; set; }
        }

    }
}
