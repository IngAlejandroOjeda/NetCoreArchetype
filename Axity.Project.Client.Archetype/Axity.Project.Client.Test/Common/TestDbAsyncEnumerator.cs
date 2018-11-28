// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDbAsyncEnumerator.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Client.Test.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Clase que se encarga de definir las pruebas async
    /// </summary>
    /// <typeparam name="T">Objeto genérico</typeparam>
    [ExcludeFromCodeCoverage]
    internal class TestDbAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        /// <summary>
        /// Campo de solo lectura para el enumerador
        /// </summary>
        private readonly IEnumerator<T> inner;

        /// <summary>
        /// Constructor que genera la instancia de la clase <see cref="TestDbAsyncEnumerator"/>
        /// </summary>
        /// <param name="inner">Objeto lista</param>
        public TestDbAsyncEnumerator(IEnumerator<T> inner)
        {
            this.inner = inner;
        }

        /// <summary>
        /// Proporciona la lista actual
        /// </summary>
        public T Current
        {
            get { return this.inner.Current; }
        }

        /// <summary>
        /// Metodo disposable que se encarga de liberar la memoria del GC
        /// </summary>
        public void Dispose()
        {
            this.inner.Dispose();
        }

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(this.inner.MoveNext());
        }

        /// <summary>
        /// Metodo que se encarga de realizar el siguiente movimiento asincrono
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Retorna true si fue exitoso, de lo contrario false</returns>
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(this.inner.MoveNext());
        }
    }
}
