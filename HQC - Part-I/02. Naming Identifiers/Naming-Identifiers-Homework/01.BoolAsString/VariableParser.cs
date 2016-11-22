using System;

namespace BoolAsString
{
    internal class VariableParser
    {
        private const int ParseBoolToStringMaxExecutionCount = 6;

        public void ParseBoolToString(bool variable)
        {
            string stringVariable = variable.ToString();
            Console.WriteLine("\"{0}\"", stringVariable);
        }
    }
}
