using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using WisT.Recognizer.Contracts;
using static Emgu.CV.Face.FaceRecognizer;

namespace WisT.Recognizer.Identifier
{
    public class Recognizer : IRecognizer
    {
        private IImageStorage _imgRepo;
        private ILabelStorage _labelRepo;
        public Recognizer(IImageStorage imgRepo, ILabelStorage labelRepo)
        {
            _imgRepo = imgRepo;
            _labelRepo = labelRepo;
        }

        public IIdentifier GetIdentity(IFaceImage img)
        {
            IIdentifier answ = new Identifier(int.MinValue);
            double minDistanse = double.PositiveInfinity;
            var labels = _labelRepo.GetAll();
            foreach (var label in labels)
            {
                var batch = _imgRepo.Get(label.Id);
                List<Image<Gray, Byte>> compBatch = new List<Image<Gray, Byte>>();
                List<int> trainingLabels = new List<int>();

                int enumerator = 0;

                foreach (var current in batch)
                {
                    compBatch.Add(new Image<Gray, Byte>(current.ImageOfFace));
                    trainingLabels.Add(enumerator++);
                }

                FaceRecognizer recognizer = new EigenFaceRecognizer(batch.Count() + 1, double.PositiveInfinity);

                recognizer.Train(compBatch.ToArray(), trainingLabels.ToArray());

                PredictionResult result = recognizer.Predict(new Image<Gray, Byte>(img.ImageOfFace));

                if(result.Distance < minDistanse)
                {
                    minDistanse = result.Distance;
                    answ = batch.First().Id;
                }
            }
            return answ;
        }
    }
}
