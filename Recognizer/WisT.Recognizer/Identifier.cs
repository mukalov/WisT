using System;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Identifier : IIdentifier
    {
        public int IdentifingCode { get; }

        public Identifier(int identifier)
        {
            IdentifingCode = identifier;
        }
        public Identifier(string identifier)
        {
            IdentifingCode = identifier.GetHashCode();
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Identifier id = obj as Identifier;

            if (id == null)
                return false;

            return (id.IdentifingCode == IdentifingCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
