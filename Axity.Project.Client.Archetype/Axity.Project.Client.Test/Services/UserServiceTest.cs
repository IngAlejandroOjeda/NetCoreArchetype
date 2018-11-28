// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersServiceTest.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Client.Test.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Axity.Project.Client.Test.Common;
    using Axity.Project.Domain.Entities.Models;
    using Axity.Project.Domain.Interfaces.Interface;
    using Axity.Project.infrastructure.Persistence;
    using Axity.Project.Infrastructure.Repository;
    using Axity.Project.Services.Service;
    using Moq;
    using Xunit;

    public class UsersServiceTest
    {
        private readonly Mock<Context> mock;
        private readonly IUnitOfWork<Context> unitOfWork;
        private IUserService userServices;

        public UsersServiceTest()
        {
            mock = new Mock<Context>();
            mock.Setup(c => c.Users).ReturnsDbSet(GetAllUsers());
            mock.Setup(c => c.Set<User>()).ReturnsDbSet(GetAllUsers());
            unitOfWork = new UnitOfWork<Context>(mock.Object);
        }

        [Fact(DisplayName = "GetAllUsers")]
        public async void ValidateGetAllUsers()
        {
            userServices = new UserService(unitOfWork);
            var result = await userServices.GetAllUsers();

            Assert.True(result != null);
            Assert.True(result.Count() > 0);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return new List<User>()
            {
                new User { Id = 1, FirstName = "Alejandro", LastName = "Ojeda", Email = "alejandro.ojeda@axity.com" },
                new User { Id = 2, FirstName = "Jorge", LastName = "Morales", Email = "jorge.morales@axity.com" },
                new User { Id = 3, FirstName = "Arturo", LastName = "Miranda", Email = "arturo.miranda@axity.com" },
                new User { Id = 4, FirstName = "Benjamin", LastName = "Galindo", Email = "benjamin.galindo@axity.com" }
            };
        }
    }
}
