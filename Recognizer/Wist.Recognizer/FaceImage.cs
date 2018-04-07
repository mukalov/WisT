using System;
using System.Drawing;
using WisT.Recognizer.Contracts;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace WisT.Recognizer.Identifier
{
    public class FaceImage : IFaceImage
    {
        public Bitmap ImageOfFace { get; set; }
        public IIdentifier Id { get; set; }

        public FaceImage(Bitmap img)
        {        
            ImageOfFace = new Bitmap(DetectFace(img), new Size(_faceHeight, _faceWeight));
        }

        private Bitmap DetectFace(Bitmap img)
        {
          

            string path = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Recognizer\WisT.Recognizer\bin\Debug";
            Image<Gray, Byte> detectionImage = new Image<Gray, Byte>(img);

            CascadeClassifier _cascadeClassifier = new CascadeClassifier(path + @"\haarcascade_frontalface_alt_tree.xml");
            var Face = _cascadeClassifier.DetectMultiScale(detectionImage/*, 1.1, 10, new Size(20, 20)*/);

            if (Face.Length == 0) // using enother cascade classifier
            {
                _cascadeClassifier = new CascadeClassifier(path + @"\haarcascade_frontalface_default.xml");
                Face = _cascadeClassifier.DetectMultiScale(detectionImage/*, 1.1, 10, new Size(20, 20)*/);
            }

            if (Face.Length == 0) 
            {
                throw new Exception("UndetectedFaceException");
            }
                Image<Gray, Byte> detectedFace = detectionImage.Copy(Face[0]);

            return detectedFace.Bitmap;
        }

        private const int _faceHeight = 200;
        private const int _faceWeight = 150;
    }
}
