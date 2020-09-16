using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Data
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
        }

        public AppUser(string userName) : base(userName)
        {
        }

        public AppUser(string userName, string firstName, string lastName, string email, string phone) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;

            Email = email;
            PhoneNumber = phone;
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
