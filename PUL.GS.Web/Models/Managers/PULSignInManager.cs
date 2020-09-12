using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PUL.GS.DataAgents;
using PUL.GS.Models;
using PUL.GS.Models.Common;
using PUL.GS.Web.Extensions;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PUL.GS.Web.Models.Managers
{
     public class PULSignInManager<PULUser> : SignInManager<PULUser>, ISignInManager<PULUser>
        where PULUser : class
    {
        private readonly AccountData agent;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="contextAccessor"></param>
        /// <param name="claimsFactory"></param>
        /// <param name="optionsAccessor"></param>
        /// <param name="logger"></param>
        /// <param name="schemes"></param>
        public PULSignInManager(
            UserManager<PULUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<PULUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<PULUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IOptions<AppSettings> appSettings,
            IUserConfirmation<PULUser> userConfirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, userConfirmation)
        {
            agent = new AccountData(appSettings.Value);
        }

        /// <summary>
        /// PasswordSignInAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="isPersistent"></param>
        /// <param name="lockoutOnFailure"></param>
        /// <returns></returns>
        public override async Task<SignInResult> PasswordSignInAsync(PULUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            // If needed, verify locked out attempts and return failure
            //var attempt = await CheckPasswordSignInAsync(user, password, lockoutOnFailure);
            var item = user as User;
            var attempt = agent.GetUserByCredentials(item.Username.ToLower(),password, item.Token);
            attempt.objectResult.SecurityStamp = Guid.NewGuid();
            //user.Equals(attempt.objectResult.Id);

            return attempt.Success
               ? await SignInOrTwoFactorAsync(user, isPersistent)
               : SignInResult.Failed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isPersistent"></param>
        /// <param name="loginProvider"></param>
        /// <param name="bypassTwoFactor"></param>
        /// <returns></returns>
        protected override async Task<SignInResult> SignInOrTwoFactorAsync(PULUser user, bool isPersistent, string loginProvider = null, bool bypassTwoFactor = false)
        {
            var item = user as User;

            if (!bypassTwoFactor &&
                UserManager.SupportsUserTwoFactor &&
                await UserManager.GetTwoFactorEnabledAsync(user) &&
                (await UserManager.GetValidTwoFactorProvidersAsync(user)).Count > 0)
            {
                if (!await IsTwoFactorClientRememberedAsync(user))
                {
                    // Store the userId for use after two factor check
                    var userId = await UserManager.GetUserIdAsync(user);
                    await Context.SignInAsync(IdentityConstants.TwoFactorUserIdScheme, StoreTwoFactorInfo(userId, loginProvider));
                    return SignInResult.TwoFactorRequired;
                }
            }
            // Cleanup external cookie
            if (loginProvider != null)
            {
                await Context.SignOutAsync(IdentityConstants.ExternalScheme);
            }

            await SignInAsync(user, isPersistent, loginProvider);
            return SignInResult.Success;
        }

        /// <summary>
        /// CheckPasswordSignInAsync
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="lockoutOnFailure"></param>
        /// <returns></returns>
        public override async Task<SignInResult> CheckPasswordSignInAsync(PULUser user, string password, bool lockoutOnFailure)
        {
            if (await UserManager.CheckPasswordAsync(user, password))
                return SignInResult.Success;
            else
                return SignInResult.Failed;
        }

        internal ClaimsPrincipal StoreTwoFactorInfo(string userId, string loginProvider)
        {
            var identity = new ClaimsIdentity(IdentityConstants.TwoFactorUserIdScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, userId));
            if (loginProvider != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.AuthenticationMethod, loginProvider));
            }
            return new ClaimsPrincipal(identity);
        }

    }
}
