using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using WisT.DemoWeb.Persistence.Control.Excepsions;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class LabelStorage : ILabelStorage
    {
        private IDbContextFactory<WisTEntities> _contextFactory;

        public LabelStorage(IDbContextFactory<WisTEntities> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Add(ILabel addObj)
        {
            using (WisTEntities context = _contextFactory.Create())
            {
                User user = new User(addObj);

                context.Users.Add(user);

                foreach (var image in addObj.Images)
                    user.UserImages.Add(new UserImage(image));

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
            using (WisTEntities context = _contextFactory.Create())
            {
                User user = new User();

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

                return new DatabaseLabel(user);
            }
        }

        public IEnumerable<ILabel> GetAll()
        {
            using (WisTEntities context = _contextFactory.Create())
            {
                return context.Users.ToList().Select(x => new DatabaseLabel(x)).ToList();
            }
        }
    }
}