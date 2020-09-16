using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Data
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {
        }
        public AppRole(string roleName) : base(roleName)
        {
        }
        public AppRole(string roleName, string faName) : base(roleName)
        {
            FaName = faName;
        }
        public AppRole(string roleName, string faName, string createdBy) : base(roleName)
        {
            FaName = faName;
            CreatedBy = createdBy;
        }

        [Required]
        public string FaName { get; set; }
        public string CreatedBy { get; set; }
    }
}
