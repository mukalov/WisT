using System.Collections.Generic;
using System.Linq;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class DatabaseLabel : ILabel
    {
        public IIdentifier Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IFaceImage> Images { get; private set; }

        public DatabaseLabel(User user)
        {
            Id = new Identifier(user.Id);
            Name = user.Name;
            Images = user.UserImages.Select(i => new FaceImage(i.Image, new Identifier(i.Id)));
        }
    }
}
