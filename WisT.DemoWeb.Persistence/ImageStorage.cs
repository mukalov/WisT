﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using WisT.DemoWeb.Persistence.Control.Excepsions;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class ImageStorage : IImageStorage
    {
        public void Add(IEnumerable<IFaceImage> addObj)

        {
            UserImage userImage = new UserImage();
            
            using (WisTEntities context = new WisTEntities())
            {
                foreach (var obj in addObj)
                {
                    userImage = new UserImage(obj);

                    context.UserImages.Add(userImage);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch
                    {
                        // Delete Label From Db
                        throw new ImagesUnsavedException();
                    }
                }
            }
        }
        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            List<IFaceImage> images = new List<IFaceImage>();
            List<UserImage> userImages = new List<UserImage>();

            using (WisTEntities context = new WisTEntities())
            {
                try
                {
                    userImages = context.UserImages.Where
                    (x => x.Id == id.IdentifingCode)
                    .Distinct()
                    .ToList();
                }
                catch
                {
                    throw new ImagesNotStoredException();
                }

                foreach (var userImage in userImages)
                {
                    images.Add(new FaceImage(new Bitmap(new MemoryStream(userImage.Image)), new Identifier(userImage.Id)));
                }
            }

            return images;
        }
    }
}
