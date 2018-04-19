using System;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Label : ILabel
    {
        private IIdentifier _id;

        public string Name { get; set; }
        public IIdentifier Id {
                get {
                    if (_id == null)
                        throw new Exception("Id is not initialized");
                    else
                    return _id;
                }
                set {
                    _id = value;
                }
            }

        public Label(string Name)
        {
            this.Name = Name;
        }
    }
}
