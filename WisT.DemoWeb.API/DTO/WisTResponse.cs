using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisT.DemoWeb.API.DTO
{
    public class WisTResponse 
    {
        private bool _notDetectedFace;
        private bool _notRegistered;
        private bool _recognized;
        private bool _registered;

        public string UserName;

        public static WisTResponse NotDetectedFace { get { return new WisTResponse() { _notDetectedFace = true }; } }
        public static WisTResponse NotRegistered { get { return new WisTResponse() { _notRegistered = true }; } }
        public static WisTResponse Recognized { get {return new WisTResponse() { _recognized = true }; } }
        public static WisTResponse Registered { get { return new WisTResponse() { _registered = true }; } }

        public WisTResponse()
        {
            _notDetectedFace = false;
            _notRegistered = false;
            _recognized = false;
            _registered = false;
        }
    }
}
