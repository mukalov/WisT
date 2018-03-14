using System.Collections;
using System.Runtime.CompilerServices;

namespace WistRecognizerContracts
{
    public interface IImageStorage : IRepository<IIdentifier, IFaceImage>
    {
        int SizeOfDataBase { get; }

        void Add(IFaceImage addObj);

        void Delete(IIdentifier id);

        IEnumerable Get(IIdentifier id);
    }
}
