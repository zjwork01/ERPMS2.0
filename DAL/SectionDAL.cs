using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Tool;

/**
*作者：赵进
*时间：2017/9/29 16:28:56
*描述：部门数据操作类
*版本：1.0.0
*/
namespace DAL
{
    public class SectionDAL
    {
        public bool Add(section s)
        {
            try
            {
                ERPContext context = new ERPContext();
                context.sections.Add(s);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "添加部门信息失败：" + s.ToString() + ",原因：" + ex.ToString());
                return false;
            }
        }

        public bool Alter(section s)
        {

            return false;
        }
    }
}
