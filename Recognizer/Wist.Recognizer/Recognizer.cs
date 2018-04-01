using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using WisT.Recognizer.Contracts;

namespace WisT.Recognizer.Identifier
{
    public class Recognizer : IRecognizer
    {
        private ILabelStorage _labelDB;
        private IImageStorage _imageDB;

        public ILabel GetIdentity(IFaceImage img)
        {
            var labels = _labelDB.GetAll();
            List<string> names = new List<string>();
            float distance;
            MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
            List<Image<Gray, Byte>> trainingFaces = new List<Image<Gray, Byte>>();

            var index = 0;
            float min = 0;
            for (int i = 0; i < labels.Count(); i++)
            {
                var currenImages = _imageDB.Get(labels.ElementAt(i).Id);
                foreach(var current in currenImages)
                {
                    trainingFaces.Add(new Image<Gray, Byte>(current.ImageOfFace));
                }

                MCvTermCriteria termCrit = new MCvTermCriteria(currenImages.Count(), 0.0001);
                var recognizer = new EigenObjectRecognizer(trainingFaces.ToArray(), ref termCrit);
                float[] avarageDist = recognizer.GetEigenDistances(new Image<Gray, Byte>(img.ImageOfFace));

                //distance = avarageDist.Sum() / avarageDist.Length; //TO TEST
                distance = avarageDist.Min();

                if (distance < min)
                {
                    min = distance;
                    index = i;
                }
            }

            return labels.ElementAt(index);
        }
    }
}
