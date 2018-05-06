using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.DemoWeb.FilePersistence
{
    public class ImageStorage : IImageStorage
    {
        private string _prjPath;
        private string _imagesPath;

        public ImageStorage()
        {
            _prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            _imagesPath = _projectPath + @"\WisT.DemoWeb.FilePersistence\Repo\Images";
        }

        public void Add(IEnumerable<IFaceImage> addObj)
        {
            int photoCounter = 0;
            var haarPath = _prjPath + @"\Recognizer\haarcascade_frontalface_default.xml";
            foreach (var obj in addObj)
            {
                string pathToCurrent = _imagesPath + (photoCounter++).ToString() + "$" + obj.Id.IdentifingCode.ToString() + ".bmp";
                var currentImg = new FaceImage(obj.ImageOfFace, haarPath);
                currentImg.ImageOfFace.Save(pathToCurrent);
            }
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            int photoCounter = 0;
            int photoCount = 5;
            List<FaceImage> batch = new List<FaceImage>();
            for( ; photoCounter < photoCount ; photoCount++)
            {
                string currrentPath = _imagesPath + photoCounter.ToString() + "$" + id.IdentifingCode.ToString() + ".bmp";
                FaceImage currentImage = new FaceImage(new Bitmap(currrentPath)) { Id = id};
                batch.Add(currentImage);
            }
            return batch;
        }
    }
}
