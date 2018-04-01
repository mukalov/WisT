using System.Collections.Generic;

namespace WisT.Recognizer.Contracts
{
    public interface ILabelStorage : IRepository<IIdentifier, ILabel>
    {
        void Add(ILabel addObj);

        void Delete(IIdentifier id);

        IEnumerable<ILabel> GetAll();

        ILabel Get(IIdentifier id);
    }
}
