using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;

namespace WisT.Tests
{
    class ImageStorageMock : IImageStorage
    {
        public void Add(IEnumerable<IFaceImage> addObj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            throw new NotImplementedException();
        }
    }
}
