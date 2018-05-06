﻿using System;
using System.Collections.Generic;
using System.Linq;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;

namespace WisT.DemoWeb.Persistence.Control
{
    public class LabelStorage : ILabelStorage
    {
        public void Add(ILabel addObj)
        {
            using (WisTEntities context = new WisTEntities())
            {
                try
                {
                    context.Users.Add(new User(addObj));
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("AddExistingUserException");
                }
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
                user = context.Users.Where
                    (x => x.Id == id.IdentifingCode)
                    .SingleOrDefault();
            }

            return new DatabaseLabel(user); 
        }
        public IEnumerable<ILabel> GetAll()
        {
            List<ILabel> labels = new List<ILabel>();

            using (WisTEntities context = new WisTEntities())
            {
                List<User> users = context.Users.ToList();

                foreach (var user in users)
                {
                    labels.Add(new DatabaseLabel(user));
                }
            }

            return labels;
        }
    }
}
