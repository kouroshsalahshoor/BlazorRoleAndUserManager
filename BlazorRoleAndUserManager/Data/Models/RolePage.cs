using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Data
{
    public class RolePage : Auditable
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public AppRole AppRole { get; set; }
        public int PageId { get; set; }
        public AppPage AppPage { get; set; }
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }

    }
}
