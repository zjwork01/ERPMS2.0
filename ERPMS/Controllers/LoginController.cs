using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Tool;

namespace ERPMS.Controllers
{
    public class LoginController : Controller
    {
        LoginBLL lb = new LoginBLL();

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View("Login");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(string uname, string upwd,string validateCode)
        {
            string result = string.Empty;
            if (IsValidate(validateCode))
            {
                if (lb.Login(uname, upwd))
                {
                    Session.Add("loginname", uname);
                    result = "success";
                }
                else
                {
                    result = "error";
                }
            }
            else
            {
                result = "fail";
            }
            var msg = new { result = result };
            return Json(msg);
        }

        /// <summary>
        /// 验证验证码是否正确
        /// </summary>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Validate(string validateCode)
        {
            string result = string.Empty;
            if (IsValidate(validateCode))
            {
                result = "success";
            }
            else
            {
                result = "fail";
            }
            var msg = new { result = result };
            return Json(msg);
        }

        /// <summary>
        /// 查看验证码是否正确
        /// </summary>
        /// <returns></returns>
        public bool IsValidate(string validate)
        {
            try
            {
                //获取生成的验证码
                string code = Session["validateCode"].ToString();
                //判断验证码是否正确
                if (validate.Equals(code))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Log.WriteLog(LogType.Error, "读取验证码出错");
                return false;
            }
        }
    }
}
