using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

/**
*作者：赵进
*时间：2017/9/30 14:22:35
*描述：
*版本：1.0.0
*/
namespace BLL
{
    public class SectionBLL
    {

        SectionDAL sd = new SectionDAL();

        public string AddSection(section s)
        {    
            if (sd.Add(s))
            {
                return "数据添加成功";
            }
            else
            {
                return "数据添加失败";
            }
        }

        public string DeleteSection(int id)
        {
            if (sd.Delete(id))
            {
                return "数据删除成功";
            }
            else
            {
                return "数据删除失败";
            }
        }

        public string AlterSection(section s,params string[] para)
        {
            if (sd.Alter(s, para))
            {
                return "修改信息成功";
            }
            else
            {
                return "修改信息失败";
            }
        }


    }
}
