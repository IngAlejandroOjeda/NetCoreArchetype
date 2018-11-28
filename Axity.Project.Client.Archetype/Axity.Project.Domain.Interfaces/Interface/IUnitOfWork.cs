// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Interfaces.Interface
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork<TContext> : IRepositoryFactory, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
        Task<int> SaveChanges(bool ensureAutoHistory = false);
    }
}
