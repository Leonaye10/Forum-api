using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum_api_back.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException() : base()
        {

        }
        public NotFoundException(string message) : base()
        {

        }
    }
}
