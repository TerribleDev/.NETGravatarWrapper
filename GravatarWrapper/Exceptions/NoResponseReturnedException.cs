using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravatarWrapper.Exceptions
{
    class NoResponseReturnedException : Exception
    {
        public NoResponseReturnedException()
            : base("No response returned from server"){}
    }
}
