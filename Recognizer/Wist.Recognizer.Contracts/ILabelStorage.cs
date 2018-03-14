using System.Collections;

namespace WistRecognizerContracts
{
    public interface ILabelStorage : IRepository<IIdentifier, ILabel>
    {
        int SizeOfDataBase { get; }

        void Add(ILabel addObj);

        void Delete(IIdentifier id);

        IEnumerable GetAll();

        ILabel Get(IIdentifier id);
    }
}
