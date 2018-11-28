// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersController.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Client.Api.Controllers
{
    using System.Threading.Tasks;
    using Axity.Project.Domain.Interfaces.Interface;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Search all User.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllUsers(0, 10));
        }

        /// <summary>
        /// Search a specific User.
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetUserById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}