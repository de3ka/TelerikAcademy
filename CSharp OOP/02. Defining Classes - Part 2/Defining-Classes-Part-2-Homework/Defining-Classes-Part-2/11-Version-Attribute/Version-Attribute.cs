using System;

namespace Defining_Classes_Part_2._11_Version_Attribute
{
    [AttributeUsage(AttributeTargets.Struct |
                    AttributeTargets.Class |
                    AttributeTargets.Interface,
                    AllowMultiple = true)]
    public class Version_Attribute : System.Attribute
    {
        public int Major { get; private set; }

        public int Minor { get; set; }

        public Version_Attribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public override string ToString()
        {
            return string.Format("Version {0}.{1}", this.Major, this.Minor);
        }
    }
}
