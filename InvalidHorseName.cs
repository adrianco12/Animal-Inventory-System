using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class InvalidHorseName : Exception
    {
        public InvalidHorseName(String errHorseName) : base(errHorseName)
        {

        }
    }
}
