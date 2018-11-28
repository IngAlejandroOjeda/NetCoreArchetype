// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDbAsyncEnumerable.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Client.Test.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase que se encarga de gestionar las listas asincronas
    /// </summary>
    /// <typeparam name="T">Objeto genérico</typeparam>
    [ExcludeFromCodeCoverage]
    internal class TestDbAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        /// <summary>
        /// Constructor que genera la instancia de la clase <see cref="TestDbAsyncEnumerable"/>
        /// </summary>
        /// <param name="enumerable">Objeto enumerable genérico</param>
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        /// <summary>
        /// Constructor que genera la instancia de la clase <see cref="TestDbAsyncEnumerable"/>
        /// </summary>
        /// <param name="expression">Objeto expresión</param>
        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        /// <summary>
        /// Proporciona el proveedor
        /// </summary>
        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(this); }
        }

        /// <summary>
        /// Método que se encarga de obtener una lista asincrona genérica
        /// </summary>
        /// <returns>Retorna una lista asincrona</returns>
        public IAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return this.GetAsyncEnumerator();
        }
    }
}
