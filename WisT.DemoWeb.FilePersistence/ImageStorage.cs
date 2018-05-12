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
        private static int _numOfPhotoes = 1;

        public ImageStorage()
        {
            _prjPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            _imagesPath = _prjPath + @"\WisT.DemoWeb.FilePersistence\Repo\Images";
        }

        public void Add(IEnumerable<IFaceImage> addObj)
        {
            int photoCounter = 0;
            foreach (var obj in addObj)
            {
                string pathToCurrent = _imagesPath + @"\" + (photoCounter++).ToString() + "$" + LabelStorage.CurrentClient.Id.IdentifingCode.ToString() + ".bmp";
                var currentImg = new FaceImage(obj.ImageOfFace);
                currentImg.ImageOfFace.Save(pathToCurrent);
            }
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            List<FaceImage> batch = new List<FaceImage>();
            for(int photoCounter = 0; photoCounter < _numOfPhotoes; photoCounter++)
            {
                string currrentPath = _imagesPath + @"\" + photoCounter.ToString() + "$" + id.IdentifingCode.ToString() + ".bmp";
                FaceImage currentImage = new FaceImage(new Bitmap(currrentPath)) { Id = id};
                batch.Add(currentImage);
            }
            return batch;
        }
    }
}
