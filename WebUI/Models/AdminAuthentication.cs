using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class AdminAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["oturum"] !=null)
            {
                AppUser gelen = (AppUser)httpContext.Session["oturum"];
                if (gelen.IsAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                httpContext.Response.Redirect("/Login/Login");
                return false;
            }
            
        }
    }
}