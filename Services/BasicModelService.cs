//#define POST_OLD


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using BlazorJob.Data;
using BlazorJob.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;



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

    //IBasicModelService<TEntity>

    public class BasicModelService<TEntity> : IBasicModelService<TEntity> where TEntity : class, IBasicEntity
    {
        protected const int DEFAULT_LIMIT = 20;

        //protected readonly ApplicationDbContext ef;
        protected readonly IConfiguration _configuration;

        //public DbSet<TEntity> Items => ef.Set<TEntity>();

        const bool ALWAYS_USE_NEW_CONTEXT = true;
        readonly string _connectionString;

        /*ApplicationDbContext dbContext, */
        public BasicModelService(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            //ef = dbContext;
            _configuration = configuration;


            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected ApplicationDbContext GetEFContext()
        {
            if (ALWAYS_USE_NEW_CONTEXT)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(_connectionString);
                return new ApplicationDbContext(optionsBuilder.Options);
            }
            else
            {
                //return ef;
                return null;
            }

        }

        async public virtual Task<TEntity> Add(TEntity entity)
        {

#if FALSE

            EntityEntry < TEntity > result = await ef.Set<TEntity>()
                .AddAsync(entity);

            int id = await ef.SaveChangesAsync();

            return result.Entity; 
#endif

            TEntity item;

            using (var context = GetEFContext())
            {
                var result = await context.Set<TEntity>().AddAsync(entity);
                int id = await context.SaveChangesAsync();
                item = result.Entity;
            }

            return item;

        }

        async public virtual Task<bool> Delete(long id)
        {
#if FALSE
            TEntity item = await ef.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                return false;
            }

            ef.Remove(item);
            _ = ef.SaveChangesAsync();
            return true; 
#endif
            bool result = false;

            using (var context = GetEFContext())
            {
                TEntity item = await context.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
                if (item == null)
                {
                    result = false;
                }
                else
                {
                    context.Remove(item);
                    int state = await context.SaveChangesAsync();
                    result = true;
                }
            }

            return result;

        }

        async public virtual Task<List<TEntity>> List()
        {
#if FALSE
            List<TEntity> items;

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                items = await ef.Set<TEntity>().Take(DEFAULT_LIMIT).ToListAsync();
                ts.Complete();
            }

            return items;  
#endif
            //return await ef.Set<TEntity>().Take(DEFAULT_LIMIT).ToListAsync();



            List<TEntity> items;

            using (var context = GetEFContext())
            {
                items = await context.Set<TEntity>().Take(DEFAULT_LIMIT).OrderByDescending(s => s.Id).ToListAsync();
            }

            return items;
        }

        async public virtual Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate = null, int offset = 0, int limit = DEFAULT_LIMIT)
        {

#if FALSE
            return await ef.Set<TEntity>().Where(predicate).Skip(offset).Take(limit).ToListAsync(); 
#endif
            List<TEntity> items;

            using (var context = GetEFContext())
            {
                var query = predicate != null ? context.Set<TEntity>().Where(predicate) : context.Set<TEntity>();
                items = await query.Skip(offset).Take(limit).OrderByDescending(s => s.Id).ToListAsync();
            }

            return items;

        }

        async public virtual Task<TEntity> Get(long id)
        {

#if FALSE
            TEntity item = await ef.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id); 
#endif
            TEntity item;
            using (var context = GetEFContext())
            {
                item = await context.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
            }
            return item;
        }

        async public virtual Task<TEntity> Update(long id, TEntity entity)
        {
            //ef.Entry(entity).State = EntityState.Modified;

#if FALSE
            var item = await Get(id);

            if (item == null)
            {
                return null;
            }

            EntityEntry<TEntity> e = ef.Set<TEntity>().Update(item);
            int state = await ef.SaveChangesAsync();
            return e.Entity; 
#endif
            TEntity item = null;

            using (var context = GetEFContext())
            {
                TEntity _item = await context.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);

                if (_item != null)
                {
                    //if(_item is Option _o && entity is Option o)
                    //{
                    //    _o.Key = o.Key;
                    //}

                    context.Entry(_item).CurrentValues.SetValues(entity);

                    EntityEntry <TEntity> e = context.Set<TEntity>().Update(_item);
                    int state = await context.SaveChangesAsync();
                    item = e.Entity;
                } 
            }

            return item;

        }
    }

}

/*
NOTES:
append to array field - https://entityframework.net/knowledge-base/13236116/entity-framework--problems-updating-related-objects

 */
