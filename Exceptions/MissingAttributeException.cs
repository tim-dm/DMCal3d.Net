using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMCal3d.Net.Exceptions
{
    public class MissingAttributeException : Exception
    {
        public MissingAttributeException(string element, string attributeName) : base($"{element} is missing a {attributeName} attribute")
        {
        }
    }
}
