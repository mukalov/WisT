using System;
using Wist.Recognizer.Contracts;

namespace WisTRecogniazer
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
