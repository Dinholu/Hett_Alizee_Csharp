using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hett_Alizée_Tp1
{
    internal class ArmoryException : Exception
    {
        public ArmoryException(string message) : base(message) { }
    }
}
