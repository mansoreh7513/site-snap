using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Snapp.Core.Securities
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IAccount _account;
        private string _roleName;

        public RoleAttribute(string roleName)
        {
            _roleName = roleName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string username = context.HttpContext.User.Identity.Name;

                _account = (IAccount)context.HttpContext.RequestServices.GetService(typeof(IAccount));

                if (!_account.CheckUserRole(_roleName, username))
                {
                    context.Result = new RedirectResult("/Account/Register");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Register");
            }
        }
    }
}
