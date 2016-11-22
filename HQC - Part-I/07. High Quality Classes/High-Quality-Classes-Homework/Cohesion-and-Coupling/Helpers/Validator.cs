using System;

namespace Cohesion_and_Coupling.Helpers
{
    public static class Validator
    {
        public static void ValidateDimension(double dimension, string name)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The {0} must be a positive number!", name));
            }
        }
    }
}