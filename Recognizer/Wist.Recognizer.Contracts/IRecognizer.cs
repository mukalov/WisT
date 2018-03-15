namespace Wist.Recognizer.Contracts
{
    public interface IRecognizer
    {
        ILabel GetIdentity(IFaceImage img);
    }
}
