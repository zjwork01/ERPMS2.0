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
        public string AddSection(section s)
        {
            SectionDAL sd = new SectionDAL();
            if (sd.Add(s))
            {
                return "数据添加成功";
            }
            else
            {
                return "数据添加失败";
            }
        }
    }
}
