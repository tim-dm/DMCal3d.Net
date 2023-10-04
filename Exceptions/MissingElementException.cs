using System;

namespace DMCal3d.Net.Exceptions
{
    public class MissingElementException : Exception
    {
        public MissingElementException(string element) : base($"Missing {element} tag(s)")
        {
        }

        public MissingElementException(string parent, string element) : base($"{parent} is missing {element} tag(s)")
        {
        }
    }
}
