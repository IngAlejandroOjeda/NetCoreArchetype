// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Axity">
//   Axity
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Axity.Project.Domain.Entities.Models
{
    using System;

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
