using BlazorRoleAndUserManager.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRoleAndUserManager.Services
{
    public class AuditService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ApplicationDbContext _db;

        public AuditService(AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext db)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _db = db;
        }
        public async Task<object> ForCreate(object o)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            var userId = (await _db.Users.SingleOrDefaultAsync(x=>x.UserName == user.Identity.Name)).Id;

            var now = DateTime.Now;

            ((Auditable)o).CreatedBy = userId;
            ((Auditable)o).CreatedOn = now;
            ((Auditable)o).LastModifiedBy = userId;
            ((Auditable)o).LastModifiedOn = now;

            return o;

        }

        public async Task<object> ForEdit(object o)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            var userId = (await _db.Users.SingleOrDefaultAsync(x => x.UserName == user.Identity.Name)).Id;

            ((Auditable)o).LastModifiedBy = userId;
            ((Auditable)o).LastModifiedOn = DateTime.Now;

            return o;
        }
    }
}
