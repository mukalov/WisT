using System.Collections.Generic;

namespace WisT.Recognizer.Contracts
{
    public interface IRecognizer
    {
        IIdentifier GetIdentity(IFaceImage img);
    }
}
