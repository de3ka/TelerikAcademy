namespace Mobile_Device
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            var test = new GSMTest();
            test.DisplayGSMInformation();

            var callTest = new GSMCallHistoryTest();
            callTest.CallTest();
        }
    }
}
