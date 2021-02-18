using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorJob.Services
{
    public interface IBasicModelService<TEntity>
    {
        Task<TEntity> Add(TEntity entity);
        Task<bool> Delete(long id);

        Task<List<TEntity>> List();

        Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate = null, int offset = 0, int limit = 10);

        Task<TEntity> Get(long id);

        Task<TEntity> Update(long id, TEntity entity);

    }
}