using System.Collections.Generic;

namespace WisT.Recognizer.Contracts
{
    public interface IRecognizer
    {
        double GetComparison(IFaceImage img, IEnumerable<IFaceImage> batch);
    }
}
