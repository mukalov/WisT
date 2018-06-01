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
        private string _projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
        private string _imagesPath;
        private const string _repoPath = @"\WisT.DemoWeb.FilePersistence\Repo";
        private static int _numOfPhotoes = 1;

        public ImageStorage()
        {
            _imagesPath = _projectPath + _repoPath + @"\Images";
            ConfigureRepo();
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

        private void ConfigureRepo()
        {
            Directory.CreateDirectory(_repoPath);
            Directory.CreateDirectory(_imagesPath);
        }
    }
}
