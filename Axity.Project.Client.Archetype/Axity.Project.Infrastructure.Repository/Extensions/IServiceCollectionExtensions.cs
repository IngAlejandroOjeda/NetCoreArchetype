// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceCollectionExtensions.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Infrastructure.Repository.Extensions
{
    using Axity.Project.Domain.Interfaces.Interface;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            // Register Unit Of Work
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
        }
    }
}
