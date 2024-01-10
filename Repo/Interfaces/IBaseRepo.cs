public interface IBaseRepo<TEntity> where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(int id);
}
