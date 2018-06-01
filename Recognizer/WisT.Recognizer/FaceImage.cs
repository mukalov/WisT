using System;
using System.Drawing;
using WisT.Recognizer.Contracts;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using WisT.Recognizer.Identifier.Exceptions;

namespace WisT.Recognizer.Identifier
{
    public class FaceImage : IFaceImage
    {
        public Bitmap ImageOfFace { get; set; }
        public IIdentifier Id { get; set; }

        public FaceImage(Bitmap img)
        {
            ImageOfFace = img;
        }

        public FaceImage(byte[] imageBytes, IIdentifier id)
        {
            using (var memoryStream = new MemoryStream(imageBytes))
            {
                ImageOfFace = new Bitmap(Image.FromStream(memoryStream));
            }
            Id = id;
        }

        public FaceImage(Bitmap img, IIdentifier Id)
        {
            ImageOfFace = img;
            this.Id = Id;
        }

        public FaceImage(Bitmap img, string path_haar, IIdentifier id)
        {
            ImageOfFace = new Bitmap(DetectFace(img, path_haar), new Size(_faceHeight, _faceWeight));
            Id = id;
        }
        public FaceImage(Bitmap img, string path_haar)
        {
            ImageOfFace = new Bitmap(DetectFace(img, path_haar), new Size(_faceHeight, _faceWeight));
        }

        private Bitmap DetectFace(Bitmap img, string path_haar)
        {
            Image<Gray, Byte> detectionImage = new Image<Gray, Byte>(img);

            CascadeClassifier _cascadeClassifier = new CascadeClassifier(path_haar);
            var Face = _cascadeClassifier.DetectMultiScale(detectionImage);

            if (Face.Length == 0)
            {
                throw new UndetectedFaceException();
            }
            Image<Gray, Byte> detectedFace = detectionImage.Copy(Face[0]);

            return detectedFace.Bitmap;
        }

        private const int _faceHeight = 300;
        private const int _faceWeight = 250;
    }
}
