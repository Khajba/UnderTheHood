using System;
using System.Collections.Generic;
using System.Text;

namespace Uth.core 
{
    public class UthException : Exception
    {
        public UthException(string message)
            :base(message)
        {

        }
    }
}
