using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravatarWrapper.Exceptions
{
    class NoResponseFoundException : Exception
    {
        public NoResponseFoundException()
            : base("No response returned from server"){}
    }
}
