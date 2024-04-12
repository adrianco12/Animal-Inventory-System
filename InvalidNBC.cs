using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cortez_Adrian_Lab2
{
    internal class InvalidNBC : Exception
    {
        public InvalidNBC(String errname) : base(errname)
        {

        }
    }
}
