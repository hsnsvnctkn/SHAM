﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace SHAM.Repository.Authorize
{
    public class UnAuthorized
    {
        public class UnAuthorizedAttribute : TypeFilterAttribute
        {
            public UnAuthorizedAttribute() : base(typeof(UnauthorizedFilter))
            {
                //Empty constructor
            }
        }
        public class UnauthorizedFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                bool IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
                if (!IsAuthenticated)
                {
                    if (context.HttpContext.Request.IsAjaxRequest())
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    }
                    else
                    {
                        context.Result = new RedirectResult("~/LogIn/Index");
                    }
                }
            }
        }

    }
}
