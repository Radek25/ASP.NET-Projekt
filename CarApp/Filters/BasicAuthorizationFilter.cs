using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace CarApp.Filters
{
    public class BasicAuthorizationFilter : IAuthorizationFilter
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;      
        public BasicAuthorizationFilter(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string s = context.ActionDescriptor.DisplayName;
            if (!context.ActionDescriptor.DisplayName.Contains("CarApp.Controllers.RestCarController"))
                return;
            if (!context.HttpContext.Request.Headers.Keys.Contains(HeaderNames.Authorization))
            {
                context.HttpContext.Request.Headers.Add("WWW-Authenticate",
                    string.Format($"Basic "));
                context.Result = new UnauthorizedResult();
                return;
            }
            string authenticationToken = context.HttpContext.Request.Headers[HeaderNames.Authorization];
            authenticationToken = authenticationToken.Split(" ")[0].Trim();
            string[] usernamePasswordArray = authenticationToken.Split(':');
            string username = usernamePasswordArray[0];
            string password = usernamePasswordArray[1];
            if (Validate(username, password).Result)
            {
                var identity = new GenericIdentity(username);
                IPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
            }
            else { context.Result = new UnauthorizedResult(); }
        }
        public async Task<bool> Validate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                var isAdmin = await _userManager.IsInRoleAsync(new IdentityUser(username), "Admin");
                if (isAdmin)
                    return true;
                return false;
            }
            return false;
        }
    }



}
