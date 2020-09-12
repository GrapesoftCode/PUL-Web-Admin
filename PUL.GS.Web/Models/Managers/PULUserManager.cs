using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models.Managers
{
    public class PULUserManager<PULUser> : UserManager<PULUser>, IUserManager<PULUser>
        where PULUser : class
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store"></param>
        /// <param name="optionsAccessor"></param>
        /// <param name="passwordHasher"></param>
        /// <param name="userValidators"></param>
        /// <param name="passwordValidators"></param>
        /// <param name="keyNormalizer"></param>
        /// <param name="errors"></param>
        /// <param name="services"></param>
        /// <param name="logger"></param>
        public PULUserManager(
            IUserStore<PULUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<PULUser> passwordHasher,
            IEnumerable<IUserValidator<PULUser>> userValidators,
            IEnumerable<IPasswordValidator<PULUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<PULUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        /// <summary>
        /// CheckPasswordAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override Task<bool> CheckPasswordAsync(PULUser model, string password)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> CreateAsync(PULUser user, string password)
        {
            return await CreateAsync(user);
        }

        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> CreateAsync(PULUser user)
        {
            ThrowIfDisposed();
            var result = await ValidateUserAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }

            return await Store.CreateAsync(user, CancellationToken);
        }

        /// <summary>
        /// ValidateUserAsync
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected async Task<IdentityResult> ValidateUserAsync(PULUser user)
        {
            var errors = new List<IdentityError>();

            // Validate user duplicates here and other validations

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }

            return await Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// GetUserLockoutStore
        /// </summary>
        /// <returns></returns>
        private IUserLockoutStore<PULUser> GetUserLockoutStore()
        {
            var cast = Store as IUserLockoutStore<PULUser>;
            if (cast == null)
            {
                throw new NotSupportedException();
            }
            return cast;
        }
    }
}
