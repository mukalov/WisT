using System;
using System.Collections.Generic;
using System.Linq;
using WisT.DemoWeb.Persistence.Control.Excepsions;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class LabelStorage : ILabelStorage
    {
        public void Add(ILabel addObj)
        {
            using (WisTEntities context = new WisTEntities())
            {
                User user = new User(addObj);

                context.Users.Add(user);
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new AddExistingUserException();
                }

                addObj.Id = new Identifier(user.Id);
            }
        }
        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }
        public ILabel Get(IIdentifier id)
        {
            User user = new User();

            using (WisTEntities context = new WisTEntities())
            {
                try
                {
                    user = context.Users.Where
                    (x => x.Id == id.IdentifingCode)
                    .SingleOrDefault();
                }
                catch
                {
                    throw new LablelNotStoredException();
                }
            }

            return new DatabaseLabel(user); 
        }
        public IEnumerable<ILabel> GetAll()
        {
            List<ILabel> labels = new List<ILabel>();
            List<User> users = new List<User>();

            using (WisTEntities context = new WisTEntities())
            {
                try
                {
                    users = context.Users.ToList();
                }
                catch
                {
                    throw new NoStoredLabelsException();
                }

                foreach (var user in users)
                {
                    labels.Add(new DatabaseLabel(user));
                }
            }

            return labels;
        }
    }
}