using System;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Label : ILabel
    {
        private IIdentifier _id;

        public string Name { get; set; }
        public IIdentifier Id
        {
            get
            {
                if (_id == null)
                    throw new Exception("Id is not initialized");
                else
                    return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Label(string Name)
        {
            this.Name = Name;
            _id = new Identifier(CreateId(Name));
        }

        public Label(string Name, IIdentifier Id)
        {
            this.Name = Name; 
            _id = Id;
        }

        private int CreateId(string name)
        {
            int hash = 0;
            int radix = 1;
            foreach (char c in name)
            {
                hash += radix * c;
                radix *= 10;
            }
            return hash;
        }
    }
}
