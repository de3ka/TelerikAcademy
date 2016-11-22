using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Common.IOProvider
{
    public interface IIOProvider
    {
        string Readline();
        void Write(string message);
        void WriteLine(string message);
    }
}
