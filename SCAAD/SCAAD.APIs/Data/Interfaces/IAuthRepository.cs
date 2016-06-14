using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCAAD.APIs.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IAuthRepository : IUpdatable<UserModel>, ICollectionReadable<UserModel>
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<IdentityResult> ChangePassword(string userId, string currentPassword, string newPassword);
        Task<IdentityResult> ChangePassword(string UserId, string Password);
        Task<Usuario> FindUser(string userName, string password);
        Task<Usuario> FindUser(string id);
        Task<IdentityResult> AsignarComoDirector(string userId);
        IEnumerable<string> GetRegisteredUserRoles(string userId);
        void Dispose();
    }
}