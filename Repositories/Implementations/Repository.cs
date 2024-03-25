using EmployeeManagementEF.Data;
using EmployeeManagementEF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementEF.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _context;

        public Repository(AppDBContext context)
        {
            _context = context;
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            T model = _context.Set<T>().Find(id);
            if (model != null)
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}
