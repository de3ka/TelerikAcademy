using System;

namespace RefactorIfStatements
{
    public class IfStatementsRefractored
    {
        public void Cook(Potato potato)
        {
            if (this.CheckPotato(potato))
            {
                // some potato cooking logic goes here
                potato.IsCooked = true;
            }
            else
            {
                throw new ArgumentException("No potato to cook. Order yourself a pizza!");
            }
        }

        /// <exception cref="ArgumentOutOfRangeException">The number of characters in the next line of characters is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="ArgumentException">Invalid number</exception>
        public void Move()
        {
            double x;
            double y;

            bool isValidNumberX = double.TryParse(Console.ReadLine(), out x);

            bool isValidNumberY = double.TryParse(Console.ReadLine(), out y);

            if (!(isValidNumberX && isValidNumberY))
            {
                throw new ArgumentException("Invalid number");
            }

            if (this.CheckIfInRange(x) && this.CheckIfInRange(y))
            {
                bool canVisitCell = this.CheckCell();
                if (canVisitCell)
                {
                    this.VisitCell();
                }
            }
        }

        private bool CheckIfInRange(double number)
        {
            const double MinNumber = -100;
            const double MaxNumber = 100;

            if (MinNumber <= number && number <= MaxNumber)
            {
                return true;
            }

            return false;
        }

        private bool CheckPotato(Potato potato)
        {
            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }

        private bool CheckCell()
        {
            throw new NotImplementedException();
        }
    }
}
