using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Common.IOProvider
{
    public class GenericIOProvider : IIOProvider
    {
        private readonly Action<string> write;
        private readonly Func<string> readline;

        public GenericIOProvider(Action<string> write, Func<string> readline)
        {
            this.write = write;
            this.readline = readline;
        }
        public string Readline()
        {
            var input = this.readline();
            return input;
        }

        public void Write(string message)
        {
            this.write(message);
        }

        public void WriteLine(string message)
        {
            this.write(message);
            this.write(Environment.NewLine);
        }
    }
}
