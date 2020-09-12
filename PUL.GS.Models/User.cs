using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUL.GS.Models
{
    public class User
    {
        public string Id { get; set; } = new Guid().ToString();
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
        public Role Role { get; set; }
        public Establishment Establishment { get; set; }
        public List<Module> Modules { get; set; }
        public string ModulesString { get; set; }
        public string Token { get; set; }
        public Guid SecurityStamp { get; set; }
    }
}
