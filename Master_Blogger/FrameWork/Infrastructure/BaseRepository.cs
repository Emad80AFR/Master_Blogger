using System.Linq.Expressions;
using FrameWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Infrastructure
{
    public class BaseRepository<TKey,T>:IRepository<TKey,T> where T : DomainBase<TKey>
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public T Get(TKey id)
        {
            return _dbContext.Find<T>(id)!;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }
    }
}
