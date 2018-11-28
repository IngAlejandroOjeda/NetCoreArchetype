// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserService.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Services.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Axity.Project.Domain.Entities.Dto;
    using Axity.Project.Domain.Entities.Models;
    using Axity.Project.Domain.Interfaces.Interface;
    using Axity.Project.infrastructure.Persistence;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork<Context> _unitOfWork;
        private readonly IRepository<User> _users;

        public UserService(IUnitOfWork<Context> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _users = _unitOfWork.GetRepository<User>();
        }
        
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var result = await _users.GetList().ConfigureAwait(false);
            return result.Select(c=> new UserDto { FirstName = c.FirstName, LastName = c.LastName });
        }

        public async Task<IPagedList<User>> GetAllUsers(int page, int pageSize)
        {
            return await _users.GetPagedList(pageIndex: page, pageSize: pageSize).ConfigureAwait(false);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _users.Find(id).ConfigureAwait(false);
        }

        public async Task<User> UpsertUser(User entity)
        {
            if (entity.Id > 0)
            {
                _users.Update(entity);
            }
            else
            {
                await _users.Insert(entity);
            }

            await _unitOfWork.SaveChanges().ConfigureAwait(false);

            return entity;
        }
    }
}
