using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace SCAAD.APIs.Data.Implementations
{
    public class AuthRepository : UpdatableRepositoryBase<UserModel>,IAuthRepository,IDisposable
    {
        //private AuthContext _ctx;

        private UserManager<Usuario> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AuthRepository()
        {
            //_ctx = new AuthContext();
            _userManager = new UserManager<Usuario>(new UserStore<Usuario>(context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            Usuario user = new Usuario
            {
                UserName = userModel.UserName
            };


            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;


        }

        public async Task<Usuario> FindUser(string userName, string password)
        {
            Usuario user = await _userManager.FindAsync(userName, password);            

            return user;
        }

        public async Task<Usuario> FindUser(string id)
        {
            Usuario user = await _userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<IdentityResult> ChangePassword(string userId, string currentPassword, string newPassword)
        {
            var identityResult = await _userManager.ChangePasswordAsync(userId, currentPassword, newPassword);

            return identityResult;
        }

        public async Task<IdentityResult> ChangePassword(string UserId, string Password)
        {
            var identityResult = await _userManager.RemovePasswordAsync(UserId);
            if (!identityResult.Succeeded)
                return identityResult;
            identityResult = await _userManager.AddPasswordAsync(UserId, Password);
            return identityResult;
        }

        public void Dispose()
        {
            context.Dispose();
            _userManager.Dispose();

        }

        public async Task<IdentityResult> AsignarComoDirector(string userId)
        {
            var identityResult = await _userManager.AddToRoleAsync(userId, "Director");

            return identityResult;
        }

        public IEnumerable<string> GetRegisteredUserRoles(string userId)
        {
            var userRoles = _userManager.GetRoles(userId);

            return userRoles;
            
        }
    }
}