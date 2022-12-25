using System;
using Microsoft.AspNetCore.Identity;

namespace Swaap_api.Models
{
    public class User : IdentityUser
    {
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public User()
        {
        }
    }
}

