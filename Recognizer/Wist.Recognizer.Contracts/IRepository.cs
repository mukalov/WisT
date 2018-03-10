namespace ValidationLLD
{
    public interface IRepository<KeyT, EntityT>
    { 
        void Add(EntityT add_obj);

        void Delete(KeyT id);

        EntityT Get(KeyT id);
    }
}
