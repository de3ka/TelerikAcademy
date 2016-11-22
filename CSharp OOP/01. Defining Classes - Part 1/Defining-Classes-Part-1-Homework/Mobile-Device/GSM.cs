using System;
using System.Collections.Generic;

namespace Mobile_Device
{
    public class GSM
    {
        private static readonly GSM iPhone4S = new GSM("IPhone 4S", "Apple", 500, "Iron Man", new Battery("G5", 50, 100, BatteryType.NiMH), new Display(10, 500000));
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price)
        {
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery baterry)
            : this(model, manufacturer, price, owner)
        {
            this.Battery = baterry;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery baterry, Display display)
            : this(model, manufacturer, price, owner, baterry)
        {
            this.Display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.model = value;
                }
                else
                {
                    throw new ArgumentException("The model of the GSM cannot be less than 1 symbol.");
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("The manufacturer of the GSM cannot be less than 1 symbol.");
                }
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("The price of the GSM cannot be 0 negative.");
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.owner = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The owner of the GSM cannot be less than 1 symbol.");
                }
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            private set
            {
                this.display = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public List<Call> CallHistory { get; private set; }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            var totalSeconds = 0;

            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                totalSeconds += this.CallHistory[i].Duration;
            }

            decimal price = totalSeconds * (pricePerMinute / 60.0m);

            return price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            List<string> info = new List<string>();
            info.Add("****GSM****\n");
            info.Add("GSM Model - " + this.Model);
            info.Add("GSM Manufacturer - " + this.Manufacturer);

            if (this.Owner != null)
            {
                info.Add("GSM Owner - " + this.Owner);
            }

            if (this.Price != 0)
            {
                info.Add("GSM Price - " + this.Price + " BGN." + "\n");
            }

            if (this.Display != null)
            {
                info.Add("---Display---\n" + this.Display);
            }
            if (this.Battery != null)
            {
                info.Add("---Battery---\n" + this.Battery);
            }
            return string.Join(Environment.NewLine, info);

        }
    }
}
