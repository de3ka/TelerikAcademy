using System;

namespace _03.Range_Exceptions
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private T minLimit;
        private T maxLimit;

        public InvalidRangeException(string message, T minLimit, T maxLimit)
            : base(message)
        {
            this.MinLimit = minLimit;
            this.MaxLimit = maxLimit;
        }

        public T MinLimit
        {
            get
            {
                return this.minLimit;
            }
            private set
            {
                this.minLimit = value;
            }
        }

        public T MaxLimit
        {
            get
            {
                return this.maxLimit;
            }
            private set
            {
                this.maxLimit = value;
            }
        }
    }
}
