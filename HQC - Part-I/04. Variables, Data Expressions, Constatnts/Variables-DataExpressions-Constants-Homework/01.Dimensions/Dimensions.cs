using System;

namespace Dimensions
{
    public class Dimensions
    {
        private double width;
        private double height;

        public Dimensions(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be a positive number");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be a positive number");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Returns the dimensions width and height of a figure after rotation with given angle in degrees.
        /// </summary>
        /// <param name="dimensions">The current dimensions</param>
        /// <param name="angleOfRotation">The rotation angle in degrees</param>
        /// <returns>The dimensions after rotation.</returns>
        public static Dimensions GetRotatedDimensions(Dimensions dimensions, double angleOfRotation)
        {
            double angleOfRotationSinus = Math.Abs(Math.Sin(angleOfRotation));
            double angleOfRotationCosinus = Math.Abs(Math.Cos(angleOfRotation));

            double widthAfterRotation = angleOfRotationCosinus * dimensions.Width + angleOfRotationSinus * dimensions.Height;
            double heightAfterRotation = angleOfRotationSinus * dimensions.Width + angleOfRotationCosinus * dimensions.Height;

            Dimensions dimensionsAfterRotate = new Dimensions(widthAfterRotation, heightAfterRotation);
            return dimensionsAfterRotate;
        }
    }
}
