using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationLLD;

namespace WisTRecogniazer
{
    public class Identifier : IIdentifier
    {
        public int IdentifingCode { get; }

        public Identifier(int IdentifingCode)
        {
            this.IdentifingCode = IdentifingCode;
        }
        
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Identifier id = obj as Identifier;

            if ((Object)id == null)
                return false;

            return (id.IdentifingCode == this.IdentifingCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
