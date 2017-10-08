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
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

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
        #region 增删改

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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
                Log.WriteLog(LogType.SQL, "添加部门信息失败，" + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                ERPContext context = new ERPContext();
                section s = new section()
                {
                    s_id = id
                };
                #region 方法一：用attach和remove

                //将对象附加到EF中
                //context.sections.Attach(s);
                //标记为删除
                //context.sections.Remove(s);

                #endregion

                #region 方法二：用entry实现删除

                DbEntityEntry<section> entry = context.Entry<section>(s);
                entry.State = EntityState.Deleted;

                #endregion

                //执行删除操作
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "删除部门信息失败，" + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="s">修改后的实体类</param>
        /// <param name="pronames">修改的属性的名称</param>
        /// <returns></returns>
        public bool Alter(section s, params string[] pronames)
        {
            try
            {
                ERPContext context = new ERPContext();
                DbEntityEntry<section> entry = context.Entry(s);
                entry.State = EntityState.Unchanged;
                foreach (string pro in pronames)
                {
                    entry.Property(pro).IsModified = true;
                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "修改部门信息失败，" + ex.ToString());
                return false;
            }
        }


        #endregion

        #region 查询

        /// <summary>
        /// 根据条件获取部门信息
        /// </summary>
        /// <returns></returns>
        public List<section> GetSectionByCondition(Expression<Func<section, bool>> condition)
        {
            try
            {
                ERPContext context = new ERPContext();
                //延迟加载。缺点：每次调用实体时都会查询数据库（EF小优化：外键实体相同，则只查一次）
                //用include可以实现连接查询
                IQueryable<section> query = context.sections.Where(condition);
                List<section> list = query.ToList<section>();
                return list;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "查询部门信息失败，" + ex.ToString());
                return new List<section>();
            }
        }

        /// <summary>
        /// 根据id获取部门信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public section GetSectionById(int id)
        {
            try
            {
                return new ERPContext().sections.Where(s => s.s_id == id).ToList<section>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                Log.WriteLog(LogType.SQL, "查询部门信息失败，" + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 获取所有的部门信息
        /// </summary>
        /// <returns></returns>
        public List<section> GetSections()
        {
            try
            {
                return new ERPContext().sections.ToList<section>();
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "查询部门信息失败，" + ex.ToString());
                return new List<section>();
            }
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pid">当前页码</param>
        /// <param name="pageSize">页面数据容量</param>
        /// <param name="condition">数据查询条件</param>
        /// <returns></returns>
        public List<section> GetSectionPage(int pid, int pageSize, Expression<Func<section, bool>> condition)
        {
            try
            {
                List<section> list = GetSectionByCondition(condition);
                if (list.Count >= pid * pageSize)
                {
                    return list.Skip((pid - 1) * pageSize).Take(pageSize).ToList<section>();
                }
                else
                {
                    return list.Skip((pid - 1) * pageSize).Take(list.Count - (pid - 1) * pageSize).ToList<section>();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "查询部门信息失败，" + ex.ToString());
                return new List<section>();
            }
        }

        /// <summary>
        /// 根据条件查询数据总数量
        /// </summary>
        /// <returns></returns>
        public int GetSectionCount(Expression<Func<section, bool>> condition)
        {
            try
            {
                return GetSectionByCondition(condition).Count;
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.SQL, "查询部门信息失败，" + ex.ToString());
                return 0;
            }
        }

        #endregion
    }
}
