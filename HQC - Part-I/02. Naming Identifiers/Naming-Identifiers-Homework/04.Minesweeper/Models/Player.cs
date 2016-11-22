using System;

namespace Minesweeper.Models
{
    public class Player
    {
        private string userName;
        private int userPoints;

        public Player(string userName, int userPoints)
        {
            this.userName = userName;
            this.userPoints = userPoints;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be left empty!");
                }

                this.userName = value;
            }
        }

        public int UserPoints
        {
            get
            {
                return this.userPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot set points to a negative number!");
                }

                this.userPoints = value;
            }
        }
    }
}
