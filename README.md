# mldotnetnet-step-by-step

### Sample1
  Demonstrates loading of vectorized columns, when multiple columns are bounded together to the vector.
  See sampl1.csv.
  https://dotnet.microsoft.com/learn/ml-dotnet/what-is-mldotnet
  https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/load-data-ml-net
  
  ~~~csharp
        public static void Run()
        {
            MLContext ctx = new MLContext(42);
            IDataView view = ctx.Data.LoadFromTextFile<Input1>("files\\sample1.csv", separatorChar: ',', hasHeader: true);

            var previewData = view.Preview(10);

            Program.PrintPreviewData(previewData);
        }   
~~~
