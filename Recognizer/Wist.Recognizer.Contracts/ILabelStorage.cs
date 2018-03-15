using System.Collections.Generic;

namespace Wist.Recognizer.Contracts
{
    public interface ILabelStorage : IRepository<IIdentifier, ILabel>
    {
        int SizeOfDataBase { get; }

        void Add(ILabel addObj);

        void Delete(IIdentifier id);

        IEnumerable<ILabel> GetAll();

        ILabel Get(IIdentifier id);
    }
}
