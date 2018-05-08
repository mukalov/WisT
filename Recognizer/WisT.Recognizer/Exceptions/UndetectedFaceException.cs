using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisT.Recognizer.Identifier.Exceptions
{
    public class UndetectedFaceException : Exception
    {
        public string Message { get; }

        public UndetectedFaceException()
        {
             Message = "No face was detected on this image.";
        }
}
}
