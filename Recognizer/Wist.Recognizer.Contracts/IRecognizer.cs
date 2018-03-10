namespace ValidationLLD
{
    public interface IRecognizer
    {
        ILabel GetIdentity(IFaceImage img);
    }
}
