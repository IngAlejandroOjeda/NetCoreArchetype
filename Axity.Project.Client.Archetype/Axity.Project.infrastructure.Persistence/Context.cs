// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.infrastructure.Persistence
{
    using Axity.Project.Domain.Entities.Models;
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options)
        : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
    }
}