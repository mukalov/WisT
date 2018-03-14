namespace WistRecognizerContracts
{
    public interface IRecognizer
    {
        ILabel GetIdentity(IFaceImage img);
    }
}
