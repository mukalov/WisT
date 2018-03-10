using System;
using ValidationLLD;

namespace WisTRecogniazer
{
    public class Label : ILabel
    {
        public string Name { get; }
        public IIdentifier ID {
                get {
                    if (ID == null)
                        throw new Exception("ID is not initialized");
                    else
                    return ID;
                }
                set {
                    ID = value;
                }
            }

        public Label(string Name)
        {
            this.Name = Name;
        }
    }
}
