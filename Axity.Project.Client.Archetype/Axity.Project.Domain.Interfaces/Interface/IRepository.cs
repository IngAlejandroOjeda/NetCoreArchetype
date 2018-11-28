// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Interfaces.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Query;

    public interface IRepository<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task Insert(params TEntity[] entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        void Delete(object id);

        Task<int> Count(Expression<Func<TEntity, bool>> predicate = null);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> Find(params object[] keyValues);

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TResult>> GetList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class;

        Task<IPagedList<TEntity>> GetPagedList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken));

        Task<IPagedList<TResult>> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class;

        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);

        Task<TResult> GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);
    }
}
