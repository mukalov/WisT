using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisT.DemoWeb.API.DTO
{
    public class WisTResponse 
    {
        public bool NotDetectedFace;
        public bool NotRegistered;
        public bool Recognized;
        public bool Registered;
        public string UserName;

        public WisTResponse()
        {
            NotDetectedFace = false;
            NotRegistered = false;
            Recognized = false;
            Registered = false;
        }
    }
}
