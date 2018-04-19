using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.IO;
using WisT.Recognizer.Contracts;
using WisT.Tests;

namespace WisT.Recognizer.Identifier.Tests
{
    [TestClass()]
    public class RecognizerTests
    {
        [TestMethod()]
        public void Test1()
        {
            Recognizer _testReco;
            FaceImage _testImage;
            LabelStorageMock _labelRepo = new LabelStorageMock(4);
            ImageStorageMock _imageRepo = new ImageStorageMock();

            _testReco = new Recognizer(_imageRepo, _labelRepo);

            Bitmap load_img = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson1\e2105db7-8e4f-4cbe-b1d0-7b0c7274431c.bmp");
            _testImage = new FaceImage(load_img, _imageRepo.RepoPath + @"\Recognizer\haarcascade_frontalface_default.xml"); // face detection there
            _testImage.Id = new Identifier(0);

            IIdentifier actual = _testReco.GetIdentity(_testImage);
            var expected = new Identifier(0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test2()
        {;
            FaceImage _testImage;
            LabelStorageMock _labelRepo;
            ImageStorageMock _imageRepo;
            Recognizer _testReco;

            _labelRepo = new LabelStorageMock(4);
            _imageRepo = new ImageStorageMock();
            _testReco = new Recognizer(_imageRepo, _labelRepo);

            Bitmap load_img = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson2\ea055021-3316-4a9f-bef4-1b5cebb428ad.bmp");
            _testImage = new FaceImage(load_img, _imageRepo.RepoPath + @"\Recognizer\haarcascade_frontalface_default.xml"); // face detection there
            _testImage.Id = new Identifier(0);

            IIdentifier actual = _testReco.GetIdentity(_testImage);
            var expected = new Identifier(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test3()
        {
            FaceImage _testImage;
            LabelStorageMock _labelRepo;
            ImageStorageMock _imageRepo;
            Recognizer _testReco;

            _labelRepo = new LabelStorageMock(4);
            _imageRepo = new ImageStorageMock();
            _testReco = new Recognizer(_imageRepo, _labelRepo);

            Bitmap load_img = new Bitmap(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson3\bc23325e-a23c-45ac-b970-e26726eca09c.bmp");
            _testImage = new FaceImage(load_img, _imageRepo.RepoPath + @"\Recognizer\haarcascade_frontalface_default.xml"); // face detection there
            _testImage.Id = new Identifier(0);

            IIdentifier actual = _testReco.GetIdentity(_testImage);
            var expected = new Identifier(2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test4()
        {
            FaceImage _testImage;
            LabelStorageMock _labelRepo;
            ImageStorageMock _imageRepo;
            Recognizer _testReco;

            _labelRepo = new LabelStorageMock(4);
            _imageRepo = new ImageStorageMock();
            _testReco = new Recognizer(_imageRepo, _labelRepo);

            Bitmap load_img = new Bitmap(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson4\28e24e03-20cf-4c1b-bf7d-5d82d67d15f7.bmp");
            _testImage = new FaceImage(load_img, _imageRepo.RepoPath + @"\Recognizer\haarcascade_frontalface_default.xml"); // face detection there
            _testImage.Id = new Identifier(0);

            IIdentifier actual = _testReco.GetIdentity(_testImage);
            var expected = new Identifier(3);
            Assert.AreEqual(expected, actual);
        }
    }
}
