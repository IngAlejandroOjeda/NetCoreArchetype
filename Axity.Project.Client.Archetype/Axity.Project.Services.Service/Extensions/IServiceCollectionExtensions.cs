// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Services.Service.Extensions
{
    using Axity.Project.Domain.Interfaces.Interface;
    using Axity.Project.infrastructure.Persistence;
    using Axity.Project.Infrastructure.Repository.Extensions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Get App Settings
            var appSettings = configuration.GetSection("AppSettings");

            // Configure Services
            services.AddTransient<IUserService, UserService>();

            //// Configure Context
            //services.AddDbContext<Context>();

            // Configure Repositories
            services.AddRepositories<Context>();
        }
    }
}
