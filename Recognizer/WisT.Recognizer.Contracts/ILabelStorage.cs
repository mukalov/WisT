using System.Collections.Generic;

namespace WisT.Recognizer.Contracts
{
    public interface ILabelStorage
    {
        void Add(ILabel addObj);

        void Delete(IIdentifier id);

        IEnumerable<ILabel> GetAll();

        ILabel Get(IIdentifier id);
    }
}
