// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Project.Domain.Interfaces.Interface;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private Dictionary<Type, object> _repositories;
        private bool _disposed = false;

        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositories = new Dictionary<Type, object>();
        }

        TContext IUnitOfWork<TContext>.Context => _context;

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task<int> SaveChanges(bool ensureAutoHistory = false)
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_repositories != null)
                    {
                        _repositories.Clear();
                    }

                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
