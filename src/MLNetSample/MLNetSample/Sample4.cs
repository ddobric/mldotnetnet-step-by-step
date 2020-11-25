using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MLNetSample
{
    class Sample4
    {
        public static void Run()
        {

            MLContext ctx = new MLContext(42);

            IDataView originalDataView = ctx.Data.LoadFromTextFile<Row>("files/sample3.csv", separatorChar: ',', hasHeader: true);

            var concatPipeline = ctx.Transforms.Concatenate("AllFeaturesInOne", "Education", "MaritalStatus");

            IEstimator<ITransformer> featurizedPipeline = ctx.Transforms.Text.FeaturizeText("Features", "AllFeaturesInOne");

            IEstimator<ITransformer> pipeline = concatPipeline.Append(featurizedPipeline);

            IEstimator<ITransformer> trainer = ctx.BinaryClassification.Trainers.AveragedPerceptron(labelColumnName: "Label", featureColumnName: "Features");

            IEstimator<ITransformer> trainingPipeline = pipeline.Append(trainer);

            // THIS EXAMPLE DOES NOT WORK. TH ELABEL COMUMNMUST BE 
            ITransformer model = trainingPipeline.Fit(originalDataView);

            IDataView predictions = model.Transform(originalDataView);

            // Evaluate model and return metrics
            var metrics = ctx.BinaryClassification.Evaluate(predictions, labelColumnName: "Label");

            // Print out accuracy metric
            Console.WriteLine("Accuracy" + metrics.Accuracy);
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
