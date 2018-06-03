using System;

namespace WisT.DemoWeb.API.DTO
{
    public class WisTResponse : IEquatable<WisTResponse>
    {
        enum WisTStatus
        {
            AlreadyRegistered,
            NotDetectedFace,
            NotRegistered,
            Recognized,
            Registered
        }

        private WisTStatus _status;

        public string UserName;

        public static WisTResponse AlreadyRegistered { get { return new WisTResponse() { _status = WisTStatus.AlreadyRegistered }; } }
        public static WisTResponse NotDetectedFace { get { return new WisTResponse() { _status = WisTStatus.NotDetectedFace }; } }
        public static WisTResponse NotRegistered { get { return new WisTResponse() { _status = WisTStatus.NotRegistered }; } }
        public static WisTResponse Recognized { get {return new WisTResponse() { _status = WisTStatus.Recognized }; } }
        public static WisTResponse Registered { get { return new WisTResponse() { _status = WisTStatus.Registered }; } }

        public WisTResponse() { }

        public bool Equals(WisTResponse other)
        {
            if (other == null)
                return false;

            return (_status == other._status);
        }
    }
}
