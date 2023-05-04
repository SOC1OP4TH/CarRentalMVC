using CarRentalMVC.Abstraction;
using CarRentalMVC.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarRentalMVC.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        AppDbContext _appDbContext;
        protected DbSet<T> _DbSet;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _DbSet = appDbContext.Set<T>();
        }

        
        public void Create(T item)
        {
            _DbSet.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var res = _DbSet.Find(id);
            if (res != null)
            {
                _DbSet.Remove(res);
                Save();
            }
        }

        public T Get(int id)
        {
            return _DbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _DbSet;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(T item)
        {
            _DbSet.Update(item);
            Save();
        }
    }
}
