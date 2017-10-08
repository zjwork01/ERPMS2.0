using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPMS.Filters
{
    public class LoginAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //如果保留这行代码，则执行.Net Framework定义好的身份验证，若要运行自定义的身份验证，则删除此行代码
            //base.OnAuthorization(filterContext);
            UrlHelper url = new UrlHelper(filterContext.RequestContext);
            try
            {
                if (filterContext.HttpContext.Session["loginname"] == null)
                {
                    filterContext.Result = new RedirectResult(url.Action("Index","Login"));
                    return;
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult(url.Action("Index", "Login"));
                return;
            }
            
        }
    }
}