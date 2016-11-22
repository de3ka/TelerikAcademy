using System;

namespace Defining_Classes_Part_2._05_07_Generic_Class
{
    public class GenericList<T> where T : IComparable
    {
        private const int DefaultCapacity = 10;
        private T[] array;
        private int capacity;
        private int count;

        public GenericList()
        {
            this.Capacity = DefaultCapacity;
            this.Count = 0;
            array = new T[Capacity];
        }

        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            array = new T[Capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value >= 0)
                {
                    this.capacity = value;
                }
                else
                {
                    throw new ArgumentException("Capacity of the list cannot be less than 0.");
                }
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Length of the list cannot be less than 0.");
                }
                else
                {
                    this.count = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < this.Count && index >= 0)
                {
                    return this.array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (index < this.Count && index >= 0)
                {
                    this.array[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }
            }
        }

        public void AddElement(T item)
        {

            this.Count++;

            if (this.Count >= this.Capacity)
            {
                DoubleSizeOfArray();
            }

            this.array[this.Count - 1] = item;
        }

        public void RemoveElementByIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            var oldElements = this.array;
            this.array = new T[Capacity];
            int arrIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (i != index)
                {
                    array[arrIndex] = oldElements[i];
                    arrIndex++;
                }
            }
            this.Count--;
        }

        public void InsertElementAtPosition(int position, T item)
        {
            Console.WriteLine("---INSERTING ELEMENT TO THE LIST---");
            if (position > this.Count || position < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range!");
            }

            this.Count++;
            if (Count >= this.Capacity)
            {
                DoubleSizeOfArray();
            }

            var oldElements = this.array;
            this.array = new T[Capacity];
            int arrIndex = 0;
            int copyIndex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (i != position)
                {
                    array[arrIndex] = oldElements[copyIndex];
                    arrIndex++;
                    copyIndex++;
                }
                else
                {
                    array[arrIndex] = item;
                    arrIndex++;
                }
            }
        }

        public void ClearAllElements()
        {
            Console.WriteLine("-----CLEARING ALL ELEMENTS FROM THE LIST------");
            this.Capacity = DefaultCapacity;
            this.array = new T[this.Capacity];
            this.Count = 0;
            Console.WriteLine("List is now empty!");
        }

        public int FindElementByItsValue(T item)
        {
            Console.WriteLine("-----FIND ELEMENT BY IT'S VALUE-----");
            for (int i = 0; i < this.Count; i++)
            {
                if (array[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private void DoubleSizeOfArray()
        {
            var oldElements = this.array;
            this.Capacity *= 2;
            this.array = new T[Capacity];
            Array.Copy(oldElements, this.array, this.Count);
        }

        public T Min()
        {
            Console.WriteLine("-----MIN ELEMENT FROM THE LIST-----");
            T minElement = array[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (minElement.CompareTo(array[i]) > 0)
                {
                    minElement = array[i];
                }
            }
            return minElement;
        }

        public T Max()
        {
            Console.WriteLine("-----MAX ELEMENT FROM THE LIST-----");
            T maxElement = array[0];
            for (int i = 0; i < this.Count; i++)
            {
                if (maxElement.CompareTo(array[i]) < 0)
                {
                    maxElement = array[i];
                }
            }
            return maxElement;
        }

        public override string ToString()
        {
            string message = "Current List Members: ";
            string resultString = String.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                resultString += array[i];
                if (i < this.Count - 1)
                {
                    resultString += " ";
                }
            }
            return message + resultString + "\n";
        }
    }
}
