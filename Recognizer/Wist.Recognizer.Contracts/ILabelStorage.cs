namespace ValidationLLD
{
    public interface ILabelStorage : IRepository<IIdentifier, ILabel>
    {
        int SizeOfDataBase { get; }

        void Add(ILabel add_obj);

        void Delete(IIdentifier id);

        ILabel[] GetAll();

        ILabel Get(IIdentifier id);

        //ILabel Get(int index);
    }
}
