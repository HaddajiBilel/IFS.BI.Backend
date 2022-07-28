namespace API.Repository
{
    public interface IRepository<TEntity>
    {
        public Guid Add(TEntity entity);
        public TEntity Get(Guid id);
        public IList<TEntity> GetAll();
        public void Update(TEntity entity);
        public void Delete(Guid id);
    }
}
