// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedList.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Interfaces.Interface
{
    using System.Collections.Generic;

    public interface IPagedList<T>
    {
        int IndexFrom { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPages { get; }
        IList<T> Items { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
