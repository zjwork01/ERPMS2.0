using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "首页";
            return View();
        }

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="tel"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public ActionResult Add(string name, string sex, string tel,string note)
        {
            section s = new section()
            {
                s_name = name,
                s_note = note,
                s_owner = name,
                s_tel = tel
            };
            BLL.SectionBLL sb = new BLL.SectionBLL();
            string result = sb.AddSection(s);
            ViewBag.result = result;
            return View("Index");
        }
    }
}
