using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SCAAD.APIs.Data;
using SCAAD.APIs.Infrastructure;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface IAuthLogic
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityResult> CambiarPassword(string userId, string currentPassword, string newPassword);
        Task<IdentityResult> CambiarPassword(string UserId, string Password);
        Task<Usuario> FindUser(string userName, string password);
        void Dispose();
        void iniciar(ApplicationUserManager appUserManager);
        UserReturnModel Create(Usuario appUser);
        RoleReturnModel Create(IdentityRole appRole);
        IEnumerable<string> GetRegisteredUserRoles(string userId);
        void AsignarComoDirector(ApplicationUserManager userManager, 
                                ApplicationRoleManager roleManager,
                                string userId);


    }
}
