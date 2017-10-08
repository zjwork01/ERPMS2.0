using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


/**
*作者：赵进
*时间：2017/10/6 9:37:27
*描述：
*版本：1.0.0
*/
namespace Tool
{
    public class JSONHelper
    {
        /// <summary>
        /// 数据转换为JSON
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DataToJson(object data)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(data);
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "数据转换为JSON出错，数据为：" + data.ToString()+"，错误："+ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// JSON转换为数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object JsonToData<T>(string data)
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<T>(data);
            }
            catch (Exception ex)
            {
                Log.WriteLog(LogType.Error, "JSON转换为对象出错，数据为：" + data.ToString() + "，错误：" + ex.ToString());
                return null;
            }
        }
    }
}
