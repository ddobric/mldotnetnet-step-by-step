using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLNetSample
{
    public class Sample1
    {
        public static void Run()
        {
            MLContext ctx = new MLContext(42);
            IDataView view = ctx.Data.LoadFromTextFile<Input1>("files\\sample1.csv", separatorChar: ',', hasHeader: true);

            var previewData = view.Preview(10);

            Program.PrintPreviewData(previewData);
        }       
    }
}
