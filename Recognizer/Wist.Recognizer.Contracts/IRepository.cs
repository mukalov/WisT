namespace Wist.Recognizer.Contracts
{
    public interface IRepository<KeyT, EntityT>
    { 
        void Add(EntityT addObj);

        void Delete(KeyT id);

        EntityT Get(KeyT id);
    }
}
