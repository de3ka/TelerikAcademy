using System;
using System.Collections.Generic;

namespace Mobile_Device
{
    public class Display
    {
        private double? size;
        private ulong? numberOfColors;

        public Display(double? size)
        {
            this.Size = size;
        }

        public Display(double? size, ulong? numberOfColors)
            : this(size)
        {
            this.NumberOfColors = numberOfColors;
        }

        public double? Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The size of the display cannot be negative number or 0");
                }
                else
                {
                    this.size = value;
                }
            }
        }

        public ulong? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The display must have at least one color");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }
        public override string ToString()
        {
            List<string> info = new List<string>();

            info.Add("Size - " + this.Size);
            info.Add("Number Of Colors - " + this.NumberOfColors + "\n");

            return String.Join(Environment.NewLine, info);
        }
    }
}
