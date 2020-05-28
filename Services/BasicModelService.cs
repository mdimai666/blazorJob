//#define POST_OLD


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlazorJob.Data;
using BlazorJob.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorJob.Services
{
    //public interface IGenericRepository<TEntity> where TEntity : class, IBasicEntity
    //{
    //    Task<IList<TEntity>> GetList();
    //    Task<TEntity> GetById(long id);
    //    Task<TEntity> Create(TEntity entity);
    //    Task<TEntity> Update(long id, TEntity entity);
    //    Task<bool> Delete(long id);
    //}

    public class BasicModelService<TEntity> where TEntity : class, IBasicEntity
    {
        protected const int DEFAULT_LIMIT = 20;

        protected readonly ApplicationDbContext ef;

        public DbSet<TEntity> Items => ef.Set<TEntity>();

        public BasicModelService(ApplicationDbContext dbContext)
        {
            ef = dbContext;
        }

        async public virtual Task<TEntity> Add(TEntity entity)
        {
            EntityEntry<TEntity> result = await ef.Set<TEntity>()
                .AddAsync(entity);

            int id = await ef.SaveChangesAsync();

            return result.Entity;
        }

        async public virtual Task<bool> Delete(long id)
        {
            TEntity item = await ef.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                return false;
            }

            ef.Remove(item);
            _ = ef.SaveChangesAsync();
            return true;

        }

        async public virtual Task<List<TEntity>> List()
        {
            return await ef.Set<TEntity>().Take(DEFAULT_LIMIT).ToListAsync();
        }

        async public virtual Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate, int offset = 0, int limit = DEFAULT_LIMIT)
        {
            
            return await ef.Set<TEntity>().Where(predicate).Skip(offset).Take(limit).ToListAsync();

        }

        async public virtual Task<TEntity> Get(long id)
        {
            TEntity item = await ef.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
            return item;
        }

        async public virtual Task<TEntity> Update(long id, TEntity entity)
        {
            //ef.Entry(entity).State = EntityState.Modified;

            var item = await Get(id);

            if (item == null)
            {
                return null;
            }

            EntityEntry<TEntity> e = ef.Set<TEntity>().Update(item);
            int state = await ef.SaveChangesAsync();
            return e.Entity;
        }
    }

}