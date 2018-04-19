using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.Tests
{
    public class LabelStorageMock : ILabelStorage
    {
        private int _labelsNum;

        public LabelStorageMock(int LabelNum)
        {
            _labelsNum = LabelNum;
        }

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
            var labels = new List<Label>();
            for(int i = 0; i < _labelsNum; i++)
            {
                labels.Add(new Label(i.ToString()) { Id = new Identifier(i)});
            }
            return labels;
        }
    }
}
