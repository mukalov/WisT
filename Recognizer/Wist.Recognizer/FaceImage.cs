using System;
using System.Drawing;
using WistRecognizerContracts;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WisTRecogniazer
{
    public class FaceImage : IFaceImage
    {
        public Bitmap ImageOfFace { get; set; }

        public FaceImage(Bitmap img)
        {
            Image<Gray, Byte> trainingImage = new Image<Gray, Byte>(img);
            Capture capture = new Capture();
            HaarCascade faceCascade = new HaarCascade("haarcascade_frontalface_alt_tree.xml");

            var Face = trainingImage.DetectHaarCascade(faceCascade)[0];
            Image<Gray, Byte> detectedFace = trainingImage.Copy(Face[0].rect).Resize(200, 150, INTER.CV_INTER_LINEAR);

            ImageOfFace = detectedFace.Bitmap;
        }

    }
}
