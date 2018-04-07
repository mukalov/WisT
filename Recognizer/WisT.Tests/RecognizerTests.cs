using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WisT.Recognizer.Identifier.Tests
{
    [TestClass()]
    public class RecognizerTests
    {
        private Recognizer _testReco;
        private FaceImage _testImage;
        private List<FaceImage> _testBatch;

        public RecognizerTests()
        {
            _testReco = new Recognizer();
            _testBatch = new List<FaceImage>();
        }

        [TestMethod()]
        public void Test1()
        {
            Bitmap load_img = new Bitmap(@"C:\Users\pavlo\source\repos\WisT\Recognizer\TestSample\TestPerson1\e2105db7-8e4f-4cbe-b1d0-7b0c7274431c.bmp");
            _testImage = new FaceImage(load_img); // face detection there
            _testImage.Id = new Identifier(0);
            string[] img_pathes = Directory.GetFiles(@"C:\Users\pavlo\source\repos\WisT\Recognizer\TestSample\TestPerson1\TestBatch");

            foreach (var img_path in img_pathes)
            {
                load_img = new Bitmap(img_path);
                _testBatch.Add(new FaceImage(load_img));
                _testBatch[_testBatch.Count - 1].Id = new Identifier(_testBatch.Count - 1);
            }

            double actual = _testReco.GetComparison(_testImage, _testBatch);
            double expected = 3000;
            double tolerance = 2000;
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod()]
        public void Test2()
        {
            Bitmap load_img = new Bitmap(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson2\0e231aaa-8ed8-4043-aa01-b5b40ff37f07.bmp");
            _testImage = new FaceImage(load_img); // face detection there
            _testImage.Id = new Identifier(0);
            string[] img_pathes = Directory.GetFiles(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson2\TestBatch");

            foreach (var img_path in img_pathes)
            {
                load_img = new Bitmap(img_path);
                _testBatch.Add(new FaceImage(load_img));
                _testBatch[_testBatch.Count - 1].Id = new Identifier(_testBatch.Count - 1);
            }

            double actual = _testReco.GetComparison(_testImage, _testBatch);
            double expected = 3000;
            double tolerance = 2000;
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod()]
        public void Test3()
        {
            Bitmap load_img = new Bitmap(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson3\bc23325e-a23c-45ac-b970-e26726eca09c.bmp");
            _testImage = new FaceImage(load_img); // face detection there
            _testImage.Id = new Identifier(0);
            string[] img_pathes = Directory.GetFiles(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson3\TestBatch");

            foreach (var img_path in img_pathes)
            {
                load_img = new Bitmap(img_path);
                _testBatch.Add(new FaceImage(load_img));
                _testBatch[_testBatch.Count - 1].Id = new Identifier(_testBatch.Count - 1);
            }

            double actual = _testReco.GetComparison(_testImage, _testBatch);
            double expected = 3000;
            double tolerance = 2000;
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod()]
        public void Test4()
        {
            Bitmap load_img = new Bitmap(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson4\28e24e03-20cf-4c1b-bf7d-5d82d67d15f7.bmp");
            _testImage = new FaceImage(load_img); // face detection there
            _testImage.Id = new Identifier(0);
            string[] img_pathes = Directory.GetFiles(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\TestSample\TestPerson4\TestBatch");

            foreach (var img_path in img_pathes)
            {
                load_img = new Bitmap(img_path);
                _testBatch.Add(new FaceImage(load_img));
                _testBatch[_testBatch.Count - 1].Id = new Identifier(_testBatch.Count - 1);
            }

            double actual = _testReco.GetComparison(_testImage, _testBatch);
            double expected = 3000;
            double tolerance = 2000;
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual, tolerance);
        }
    }
}
