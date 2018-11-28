
namespace Axity.Project.Client.Test.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Query.Internal;

    /// <summary>
    /// Clase que se encarga de establecer el proveedor para el test asincrono
    /// </summary>
    /// <typeparam name="TEntity">Objeto genérico que identifica a una entidad</typeparam>
    [ExcludeFromCodeCoverage]
    internal class TestDbAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        /// <summary>
        /// Campo de solo lectura para el enumerador
        /// </summary>
        private readonly IQueryProvider inner;

        /// <summary>
        /// Constructor que se encarga de generar una instancia de la clase <see cref="TestDbAsyncQueryProvider"/>
        /// </summary>
        /// <param name="inner">Objeto lista</param>
        internal TestDbAsyncQueryProvider(IQueryProvider inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Método que se encarga de crar un query
        /// </summary>
        /// <param name="expression">Expresión para formular el query</param>
        /// <returns>Retorna un IQueryable</returns>
        public IQueryable CreateQuery(Expression expression)
        {
            return new TestDbAsyncEnumerable<TEntity>(expression);
        }

        /// <summary>
        /// Método que se encarga de crar un query
        /// </summary>
        /// <typeparam name="TElement">objeto genérico</typeparam>
        /// <param name="expression">Expresión para formular el query</param>
        /// <returns>Retorna un IQueryable</returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        /// <summary>
        /// Método que Ejecuta la expresión
        /// </summary>
        /// <param name="expression">Expresión para formular el query</param>
        /// <returns>Retorna un objeto</returns>
        public object Execute(Expression expression)
        {
            return this.inner.Execute(expression);
        }

        /// <summary>
        /// Método que ejecuta la expresión
        /// </summary>
        /// <typeparam name="TResult">Objeto genérico</typeparam>
        /// <param name="expression">Expresión para formular el query</param>
        /// <returns>Retorna un objeto asincrono</returns>
        public TResult Execute<TResult>(Expression expression)
        {
            return this.inner.Execute<TResult>(expression);
        }

        /// <summary>
        /// Método que se encarga de ejecutar la expresion asincrona
        /// </summary>
        /// <param name="expression">Expresión para formular el query</param>
        /// <param name="cancellationToken">Token para la cancelación</param>
        /// <returns>Retorna un objeto asincrono</returns>
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.Execute(expression));
        }

        /// <summary>
        /// Método que se encarga de ejecutar la expresion asincrona
        /// </summary>
        /// <typeparam name="TResult">Objeto genérico</typeparam>
        /// <param name="expression">Expresión para formular el query</param>
        /// <param name="cancellationToken">Token para la cancelación</param>
        /// <returns>Retorna un objeto asincrono</returns>
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.Execute<TResult>(expression));
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return this.Execute<IAsyncEnumerable<TResult>>(expression);
        }
    }
}
