using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using Unity;
using WisT.Recognizer.Contracts;
using static Emgu.CV.Face.FaceRecognizer;

namespace WisT.Recognizer.Identifier
{
    public class Recognizer : IRecognizer
    {
        private UnityContainer Container;

        public Recognizer()
        {
            Container = new UnityContainer();
            Container.RegisterType(typeof(IFaceImage), typeof(FaceImage));
        }

        public double GetComparison(IFaceImage img, IEnumerable<IFaceImage> batch)
        {
            FaceRecognizer recognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            List<Image<Gray, Byte>> compBatch = new List<Image<Gray, Byte>>();
            List<int> labels = new List<int>();

            foreach (IFaceImage current in batch)
            {
                compBatch.Add(new Image<Gray, Byte>(current.ImageOfFace));
                labels.Add(current.Id.IdentifingCode);
            }

            recognizer.Train(compBatch.ToArray(), labels.ToArray());
            
            PredictionResult result = recognizer.Predict(new Image<Gray, Byte>(img.ImageOfFace));

            return result.Distance;
        }


    }
}
