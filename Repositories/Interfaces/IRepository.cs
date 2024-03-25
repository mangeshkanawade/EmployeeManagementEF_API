namespace EmployeeManagementEF.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id);
        IQueryable<T> GetAll();
    }
}
