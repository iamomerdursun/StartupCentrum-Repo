
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DesingPattern
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, new()
        where TContext : AppDbContext, new()
    {
        public void Add(TEntity entity)
        {
            // Yeni bir öğe eklemek için veritabanı bağlaması oluşturulur ve öğe eklenir.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }
        public void Delete(TEntity entity)
        {
            // Mevcut bir öğeyi silmek için veritabanı bağlaması oluşturulur ve öğe silinir.
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            // Belirli bir öğeyi getirmek için veritabanı bağlaması oluşturulur ve LINQ sorgusu çalıştırılır.
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // Tüm öğeleri getirmek için veritabanı bağlaması oluşturulur ve LINQ sorgusu çalıştırılır.
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Update(TEntity entity)
        {        
            // Mevcut bir öğeyi güncellemek için veritabanı bağlaması oluşturulur ve öğe güncellenir.
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
