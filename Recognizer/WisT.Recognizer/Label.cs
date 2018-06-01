using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Label : ILabel
    {
        private IIdentifier _id;
        private IList<IFaceImage> _images = new List<IFaceImage>();

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

        public IEnumerable<IFaceImage> Images { get { return _images; } }

        public Label(string Name)
        {
            this.Name = Name;
        }

        public Label(string Name, IIdentifier Id)
        {
            this.Name = Name; 
            _id = Id;
        }

        public void AddImage(IFaceImage image)
        {
            _images.Add(image);
        }
    }
}
