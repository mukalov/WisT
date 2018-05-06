using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using WisT.DemoWeb.Persistence.DataEntities;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.Persistence.Control
{
    public class ImageStorage : IImageStorage
    {
        public void Add(IEnumerable<IFaceImage> addObj)

        {
            List<UserImage> userImages = new List<UserImage>();
            int id;

            using (WisTEntities context = new WisTEntities())
            {
                id = context.UserImages.Max(x => x.ImageId);
            }

            foreach (var obj in addObj)
            {
                MemoryStream memoryStream = new MemoryStream();
                obj.ImageOfFace.Save(memoryStream, ImageFormat.Bmp);
                byte[] image = memoryStream.ToArray();

                userImages.Add(new UserImage
                {
                    ImageId = id,
                    Id = obj.Id.IdentifingCode,
                    Image = image

                });
                id++;
            }

            using (WisTEntities context = new WisTEntities())
            {
                context.UserImages.AddRange(userImages);
                context.SaveChanges();
            }
        }
        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            List<IFaceImage> images = new List<IFaceImage>();

            using (WisTEntities context = new WisTEntities())
            {
                List<UserImage> userImages = context.UserImages.Where
                    (x => x.Id == id.IdentifingCode)
                    .Distinct()
                    .ToList();

                foreach (var userImage in userImages)
                {
                    images.Add(new FaceImage(new Bitmap(new MemoryStream(userImage.Image)), new Identifier(userImage.Id)));
                }
            }

            return images;
        }
    }
}
