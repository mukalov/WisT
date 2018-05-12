using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Recognizer.Identifier;

namespace WisT.Tests
{
    public class ImageStorageMock : IImageStorage
    {
        public string RepoPath;

        public ImageStorageMock()
        {
            RepoPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        }

        public void Add(IEnumerable<IFaceImage> addObj)
        {
            throw new NotImplementedException();
        }

        public void Delete(IIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFaceImage> Get(IIdentifier id)
        {
            var path = RepoPath + @"\Recognizer\TestSample\TestPerson" + (id.IdentifingCode + 1).ToString() + @"\TestBatch";

            var haarPath = RepoPath + @"\DTO\haarcascade_frontalface_alt.xml";
            var samplePathes = Directory.GetFiles(path);
            List<FaceImage> Batch = new List<FaceImage>();
            foreach (var imagePath in samplePathes)
            {
                Batch.Add(new FaceImage(new Bitmap(imagePath), haarPath) {Id = id });
            }
            return Batch;
        }

        
    }
}
