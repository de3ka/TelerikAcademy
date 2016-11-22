namespace BoolAsString
{
    internal class Startup
    {
        internal static void Main()
        {
            VariableParser parser = new VariableParser();

            parser.ParseBoolToString(true);
        }
    }
}
