// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryFactory.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Interfaces.Interface
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
