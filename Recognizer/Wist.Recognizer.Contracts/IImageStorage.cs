namespace ValidationLLD
{
    public interface IImageStorage : IRepository<IIdentifier, IFaceImage>
    {
        int SizeOfDataBase { get; }

        void Add(IFaceImage add_obj);

        void Delete(IIdentifier id);

        IFaceImage[] Get(IIdentifier id);

    }
}
