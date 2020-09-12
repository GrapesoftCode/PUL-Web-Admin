using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models.Stores
{
    public class RoleStore : IRoleStore<ApplicationRole>
    {
        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Dispose
        /// </summary>
        public void Dispose()
        {
            // Nothing to dispose.
        }

        /// <summary>
        /// Find Role by Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find Role by Name
        /// </summary>
        /// <param name="normalizedRoleName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Normalized Role Name
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Role Id
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Role name
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set Normalized role name
        /// </summary>
        /// <param name="role"></param>
        /// <param name="normalizedName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set Role Name
        /// </summary>
        /// <param name="role"></param>
        /// <param name="roleName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
