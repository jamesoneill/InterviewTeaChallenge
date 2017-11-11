using System;
using System.Collections.Generic;
using System.Text;

namespace JO.InterviewTeaChallenge.Core.SafeExceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException():base("Not found")
        {
        }

        public NotFoundException(string message)
        : base(message)
        {

        }

        public NotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
