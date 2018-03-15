using System.Collections.Generic;

namespace Wist.Recognizer.Contracts
{
    public interface IImageStorage : IRepository<IIdentifier, IFaceImage>
    {
        int SizeOfDataBase { get; }

        void Add(IFaceImage addObj);

        void Delete(IIdentifier id);

        IEnumerable<IFaceImage> Get(IIdentifier id);
    }
}
