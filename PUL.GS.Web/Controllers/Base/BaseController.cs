using Microsoft.AspNetCore.Mvc;
using PUL.GS.Models;
using PUL.GS.Web.Models.Managers;

namespace PUL.GS.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        /// <summary>
        /// UserManager
        /// </summary>
        protected readonly PULUserManager<User> _userManager;

        /// <summary>
        /// SignInManager
        /// </summary>
        protected readonly PULSignInManager<User> _signInManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController()
        {
        }

        public BaseController(IUserManager<User> userManager, ISignInManager<User> signInManager)
        {
            var customUserManager = userManager as PULUserManager<User>;
            var customSignInManager = signInManager as PULSignInManager<User>;
            _userManager = customUserManager;
            _signInManager = customSignInManager;

            // Override the default User Manager
            _signInManager.UserManager = customUserManager;
        }
    }
}
