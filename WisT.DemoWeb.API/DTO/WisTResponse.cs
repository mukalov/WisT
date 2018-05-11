using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisT.DemoWeb.API.DTO
{
    public class WisTResponse 
    {
        enum WisTStatus
        {
            NotDetectedFace,
            NotRegistered,
            Recognized,
            Registered
        }

        private WisTStatus _status;

        public string UserName;

        public static WisTResponse NotDetectedFace { get { return new WisTResponse() { _status = WisTStatus.NotDetectedFace }; } }
        public static WisTResponse NotRegistered { get { return new WisTResponse() { _status = WisTStatus.NotRegistered }; } }
        public static WisTResponse Recognized { get {return new WisTResponse() { _status = WisTStatus.Recognized }; } }
        public static WisTResponse Registered { get { return new WisTResponse() { _status = WisTStatus.Registered }; } }

        public WisTResponse() { }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var value = obj as WisTResponse;
            return (_status == value._status);
        }
    }
}
