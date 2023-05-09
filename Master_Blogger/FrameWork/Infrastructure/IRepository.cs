using System.Linq.Expressions;
using FrameWork.Domain;

namespace FrameWork.Infrastructure
{
    public interface IRepository<in TKey,T> where T:DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exist(Expression<Func<T, bool>> expression);
    }
}