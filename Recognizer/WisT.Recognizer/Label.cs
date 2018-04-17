using System;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Label : ILabel
    {
        public string Name { get; }
        public IIdentifier Id {
                get {
                    if (Id == null)
                        throw new Exception("Id is not initialized");
                    else
                    return Id;
                }
                set {
                    Id = value;
                }
            }

        public Label(string Name)
        {
            this.Name = Name;
        }
    }
}
