using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLNetSample
{
    public class Sample2
    {
        public static void Run()
        {
            MLContext ctx = new MLContext(42);

            // Reading from files.
            IDataView view = ctx.Data.LoadFromTextFile<Input>("files/taxi-fare-train.csv", separatorChar: ',', hasHeader: true);

            List<Input> list = new List<Input>()
            {
                new Input(){ Amount = 7.1, PassangerCount = 2, RateCode = 1, TripDistance = 19, TripTime = 16, VendorId = 1,  },
                new Input(){ Amount = 7.1, PassangerCount = 2, RateCode = 1, TripDistance = 19, TripTime = 16, VendorId = 1,  },
                new Input(){ Amount = 7.1, PassangerCount = 2, RateCode = 1, TripDistance = 19, TripTime = 16, VendorId = 1,  },
                new Input(){ Amount = 7.1, PassangerCount = 2, RateCode = 1, TripDistance = 19, TripTime = 16, VendorId = 1,  },
                new Input(){ Amount = 7.1, PassangerCount = 2, RateCode = 1, TripDistance = 19, TripTime = 16, VendorId = 1,  },
            };

            IDataView view2 = ctx.Data.LoadFromEnumerable<Input>(list);
        }
    }
}
