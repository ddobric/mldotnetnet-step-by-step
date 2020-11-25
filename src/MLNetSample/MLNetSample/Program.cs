using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;

namespace MLNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ML.NET. Step by step.");

            Sample1.Run();

            Sample2.Run();

        }


        public static void PrintPreviewData(DataDebuggerPreview previewData)
        {
            foreach (var row in previewData.RowView)
            {
                var ColumnCollection = row.Values;
                string lineToPrint = "Row--> ";
                foreach (KeyValuePair<string, object> column in ColumnCollection)
                {
                    if (column.Value is VBuffer<Single>)
                    {
                        lineToPrint += $"| {column.Key}:{column.Value}";

                        lineToPrint += "|";
                        foreach (var val in ((VBuffer<Single>)column.Value).GetValues())
                        {
                            lineToPrint += $"{val}, ";
                        }
                        lineToPrint += "|";
                    }
                    else
                        lineToPrint += $"| {column.Key}:{column.Value}";

                }


                Console.WriteLine(lineToPrint + "\n");
            }
        }
    }
}
