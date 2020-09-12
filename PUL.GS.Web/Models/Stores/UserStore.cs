using Microsoft.AspNetCore.Identity;
using PUL.GS.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models.Stores
{
    public class UserStore :
        IUserStore<User>,
            IUserPasswordStore<User>
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            // Create user here

            return await Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            // Nothing to dispose.
        }

        /// <summary>
        /// FindByIdAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // If user doesn't exist, return null..

            return Task.FromResult(new User()
            {
                Id = userId
            });
        }

        /// <summary>
        /// FindByNameAsync
        /// </summary>
        /// <param name="normalizedUserName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // If user doesn't exist, return null..

            return Task.FromResult(new User()
            {
                Username = normalizedUserName
            });
        }

        /// <summary>
        /// GetNormalizedUserNameAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetPasswordHashAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetUserIdAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        /// <summary>
        /// GetUserNameAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        /// <summary>
        /// HasPasswordAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        /// <summary>
        /// SetNormalizedUserNameAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="normalizedName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SetPasswordHashAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordHash"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SetUserNameAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
