using System;
using System.Collections.Generic;

namespace Mobile_Device
{
    public class Call
    {
        private string date;
        private string time;
        private string dialledNumber;
        private int duration;

        public Call(string date, string time, string dialledPhoneNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialledNumber = dialledPhoneNumber;
            this.Duration = duration;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.date = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The date of the call cannot be empty!");
                }
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.time = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The time of the call cannot be empty!");
                }
            }
        }

        public string DialledNumber
        {
            get
            {
                return this.dialledNumber;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.dialledNumber = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The dialled phone number of the call cannot be empty!");
                }
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value >= 0)
                {
                    this.duration = value;
                }
                else
                {
                    throw new ArgumentException("The duration of the call cannot be less than 0 seconds");
                }
            }
        }
        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("*****CALL INFO*****");
            info.Add("Call Date - " + this.Date);
            info.Add("Call Time - " + this.Time);
            info.Add("Number Called - " + this.DialledNumber);
            info.Add("Call Duration - " + this.Duration + " sec.\n");

            return String.Join(Environment.NewLine, info);
        }
    }
}
