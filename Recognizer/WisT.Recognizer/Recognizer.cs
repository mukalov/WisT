using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using WisT.Recognizer.Contracts;
using static Emgu.CV.Face.FaceRecognizer;

namespace WisT.Recognizer.Identifier
{
    public class Recognizer : IRecognizer
    {
        private double _minDistanse = double.PositiveInfinity;
        private double _transistRateCoefficient = 0.7;

        //Recognizer settings
        private const int _recognizerRadius = 2;
        private const int _recognizerNeighbors = 8;
        private const int _recognizerGridX = 8;
        private const int _recognizerGridY = 8;
        private const double _recognizerThreshold = 200;

        private const double _requiredDistance = 70;

        public Recognizer(ILabelStorage labelRepo)
        {
            _labelRepo = labelRepo;
        }

        public Recognizer(ILabelStorage labelRepo, double transistRateCoefficient)
        {
            _labelRepo = labelRepo;
            _transistRateCoefficient = transistRateCoefficient;
        }

        public IIdentifier GetIdentity(IFaceImage img)
        {
            IIdentifier answ = new Identifier(int.MinValue);
            var distanses = new List<double>();
            var labels = _labelRepo.GetAll();
            foreach (var label in labels)
            {
                IEnumerable<IFaceImage> batch = label.Images;
                List<Image<Gray, Byte>> compBatch = new List<Image<Gray, Byte>>();
                List<int> trainingLabels = new List<int>();

                int enumerator = 0;
                IIdentifier currentId = new Identifier(0);
                foreach (var current in batch)
                {
                    compBatch.Add(new Image<Gray, Byte>(current.ImageOfFace));
                    trainingLabels.Add(enumerator++);
                    currentId = current.Id;
                }

                FaceRecognizer recognizer = new LBPHFaceRecognizer(_recognizerRadius, _recognizerNeighbors,
                    _recognizerGridX, _recognizerGridY, _recognizerThreshold);

                recognizer.Train(compBatch.ToArray(), trainingLabels.ToArray());

                PredictionResult result = recognizer.Predict(new Image<Gray, Byte>(img.ImageOfFace));
                distanses.Add(result.Distance);
                if (result.Distance < _minDistanse)
                {
                    _minDistanse = result.Distance;
                    answ = label.Id;
                }
            }

            foreach (var dist in distanses)
            {
                if (_minDistanse > _transistRateCoefficient * dist && dist != _minDistanse)
                {
                    return new Identifier(-1);
                }
            }
            if(_minDistanse < _requiredDistance)
                return answ;
            else
                return new Identifier(-1);
        }

        private ILabelStorage _labelRepo;
    }
}