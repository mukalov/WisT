namespace WisT.Recognizer.Contracts
{
    public interface IRecognizer
    {
        ILabel GetIdentity(IFaceImage img);
    }
}
