using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MLNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ML.NET. Step by step.");

            Sample1.Run();

            Sample2.Run();

            Sample3.Run();

            Sample4.Run();
        }


        public static void PrintPreviewData(DataDebuggerPreview previewData)
        {
            foreach (var row in previewData.RowView)
            {
                var ColumnCollection = row.Values;
                string lineToPrint = ">";
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

        public static string StringifyDenseVector(VBuffer<Single> vector)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var val in vector.GetValues())
            {
                sb.Append(val);
            }

            return sb.ToString();
        }
    }
}
