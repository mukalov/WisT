using System.Collections.Generic;

namespace WisT.Recognizer.Contracts
{
    public interface IImageStorage 
    {
        void Add(IEnumerable<IFaceImage> addObj);

        void Delete(IIdentifier id);

        IEnumerable<IFaceImage> Get(IIdentifier id);
    }
}
