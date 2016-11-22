using System;
using System.Collections.Generic;

namespace Mobile_Device
{
    public class Battery
    {
        private string batteryModel;
        private double? hoursIdle;
        private double? hoursTalk;
        private BatteryType batteryType;

        public Battery(string batteryModel, double? hoursIdle, double? hoursTalk, BatteryType batteryType)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public string BatteryModel
        {
            get
            {
                return this.batteryModel;
            }
            private set
            {
                if (value != string.Empty && value != null)
                {
                    this.batteryModel = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The model of the battery cannot be empty!");
                }
            }
        }

        public double? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            private set
            {
                if (value > 0)
                {
                    this.hoursIdle = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Idle hours of the Battery cannot be less or equal to 0.");
                }
            }
        }

        public double? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            private set
            {
                if (value > 0)
                {
                    this.hoursTalk = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Hours of talk of the Battery cannot be less or equal to 0.");
                }
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            private set
            {
                this.batteryType = value;
            }
        }

        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("Model - " + this.BatteryModel);
            info.Add("Hours Iddle - " + this.HoursIdle);
            info.Add("Hours Talk - " + this.HoursTalk);
            info.Add("Type Of Battery - " + this.BatteryType + "\n");

            return string.Join(Environment.NewLine, info);
        }
    }
}
