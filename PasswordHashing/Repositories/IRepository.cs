namespace PasswordHashing.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(); 
        int Add(T entity); 
        void Save(); 
    }
}