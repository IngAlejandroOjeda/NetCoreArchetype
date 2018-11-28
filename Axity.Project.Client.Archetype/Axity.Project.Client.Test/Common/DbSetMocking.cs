// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbSetMocking.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Client.Test.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Moq;
    using Moq.Language;
    using Moq.Language.Flow;

    /// <summary>
    /// Clase que extiende a Mock para generar dinamicamente los DBSet
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DbSetMocking
    {
        /// <summary>
        /// Método que se encarga de crear 
        /// </summary>
        /// <typeparam name="T">Objeto dbSet de la plantilla tt</typeparam>
        /// <param name="data">Objeto que contiene la información a cargar en el set</param>
        /// <returns>Retorna un MoqContext</returns>
        private static Mock<DbSet<T>> CreateMockSet<T>(IQueryable<T> data)
                where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IAsyncEnumerable<T>>()
               .Setup(m => m.GetEnumerator())
               .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>().Setup(c => c.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(c => c.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(c => c.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(this IReturns<TContext, DbSet<TEntity>> setup, TEntity[] entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IEnumerable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            Mock<DbSet<TEntity>> mockSet;
            return ReturnsDbSet(setup, entities, out mockSet);
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <param name="mockSet">Objeto que contiene el mock</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                TEntity[] entities,
                out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <param name="mockSet">Objeto que contiene el mock</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities,
                out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities);
            return setup.Returns(mockSet.Object);
        }

        /// <summary>
        /// Método que se encarga de retornar el DBSet del Mock
        /// </summary>
        /// <typeparam name="TEntity">Objeto que pertenece al tt</typeparam>
        /// <typeparam name="TContext">Objeco que hace referencia al contexto</typeparam>
        /// <param name="setup">Objeto DBSet para la configuración del Mock</param>
        /// <param name="entities">Lista de entidades</param>
        /// <param name="mockSet">Objeto que contiene el mock</param>
        /// <returns>Retorna un DBSet</returns>
        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IEnumerable<TEntity> entities,
                out Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
            where TContext : DbContext
        {
            mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }

        /// <summary>
        /// Método que se encarga de obtener un moq Set
        /// </summary>
        /// <typeparam name="T">modelo de la entidad</typeparam>
        /// <param name="entities">Lista querable para generar el DbSet</param>
        /// <returns>Retorna un Mock</returns>
        public static Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IAsyncEnumerable<T>>()
              .Setup(m => m.GetEnumerator())
              .Returns(new TestDbAsyncEnumerator<T>(entities.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(entities.Provider));

            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            return mockSet;
        }
    }
}
