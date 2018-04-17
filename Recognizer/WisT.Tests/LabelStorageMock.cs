using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;

namespace WisT.Tests
{
    class LabelStorageMock : ILabelStorage
    {
        public void Add(ILabel addObj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public ILabel Get(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILabel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
