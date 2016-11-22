namespace Mobile_Device
{
    public class GSMTest
    {
        private GSM[] phones = new GSM[]
             {
                new GSM("G5", "Samsung", 3000, "Dr. Doom",
                    new Battery("M2", 50, 5, BatteryType.LiIon), new Display(6, 500000)),
                new GSM("S7", "Samsung", 3000, "Proffessor Xavier",
                    new Battery("T5", 422, 134, BatteryType.NiMH), new Display(7, 523145151)),
                new GSM("IPhone 6S", "Apple", 3000, "Captain America",
                    new Battery("S8", 444, 155, BatteryType.NiCd), new Display(12, 31515561))
             };

        public void DisplayGSMInformation()
        {
            foreach (var gsm in phones)
            {
                gsm.DisplayInfo();
            }

            GSM.IPhone4S.DisplayInfo();
        }
    }
}
