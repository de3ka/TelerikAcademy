using System;
using System.Linq;

namespace Mobile_Device
{
    public class GSMCallHistoryTest
    {
        private GSM gsm = new GSM("Galaxy S5", "Sony");
        private const decimal PricePerMinute = 0.37m;

        public void CallTest()
        {
            gsm.AddCall(new Call("03/03/2016", "14:06", "089006587", 160));
            gsm.AddCall(new Call("23/03/2015", "12:42", "0923109109", 255));
            gsm.AddCall(new Call("28/02/2016", "11:12", "085666666", 361));

            for (int i = 0; i < gsm.CallHistory.Count; i++)
            {
                Console.WriteLine(gsm.CallHistory[i]);
            }

            Console.WriteLine("Total price: {0:f2} BGN", gsm.CalculateTotalCallPrice(PricePerMinute));

            Call longestCall = gsm.CallHistory.OrderByDescending(x => x.Duration).First();

            gsm.DeleteCall(longestCall);

            Console.WriteLine("Total price after removing longest call is {0:f2} BGN", gsm.CalculateTotalCallPrice(PricePerMinute));

            gsm.ClearCallHistory();


            if (gsm.CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
            }
        }
    }
}
