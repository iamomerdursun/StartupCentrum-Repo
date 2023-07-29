using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DesingPattern
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        // Tüm öğeleri getirir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        // Belirli bir öğeyi getirir.
        T Get(Expression<Func<T, bool>> filter);
        // Yeni bir öğe ekler.
        void Add(T entity);
        // Mevcut bir öğeyi günceller.
        void Update(T entity);
        // Mevcut bir öğeyi siler.
        void Delete(T entity);
    }
}
