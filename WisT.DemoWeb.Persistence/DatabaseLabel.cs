using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class DatabaseLabel : ILabel
    {
        public IIdentifier Id { get; set; }

        public string Name { get; set; }

        public DatabaseLabel(User user)
        {
            Id = new Identifier(user.Id);
            Name = user.Name;
        }
    }
}
