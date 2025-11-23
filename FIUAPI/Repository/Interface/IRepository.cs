namespace FIUAPI.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(long id);
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
    }
}
