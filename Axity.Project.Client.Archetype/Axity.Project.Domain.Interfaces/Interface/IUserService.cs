// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Interfaces.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Project.Domain.Entities.Dto;
    using Axity.Project.Domain.Entities.Models;

    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<IPagedList<User>> GetAllUsers(int page, int pageSize);
        Task<User> GetUserById(int id);
        Task<User> UpsertUser(User entity);
    }
}
