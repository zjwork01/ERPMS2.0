using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Text;

/**
 * 用于日志的读写
 * 赵进
 * 2017-09-27
 * */
namespace Tool
{
    /// <summary>
    /// 日志类，用于日志操作
    /// </summary>
    public class Log
    {
        //获取日志文件的地址
        private static string LogPath = AppDomain.CurrentDomain.BaseDirectory+ @"Log\Log-" + DateTime.Now.ToString("yyyy-MM-dd")+".txt";
        
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="type">日志类型</param>
        /// <param name="msg">日志内容</param>
        public static bool WriteLog(LogType type, string msg)
        {
            //判断文件夹是否存在
            string path = Path.GetDirectoryName(LogPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //判断文件是否存在
            if (!File.Exists(LogPath))
            {
                File.Create(LogPath).Close();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(type.ToString()+"     ");
            sb.Append(DateTime.Now.ToString("hh:mm:ss")+"       ");
            sb.Append(msg+"\n");
            try
            {
                FileStreamOperate operate = new FileStreamOperate();
                if (operate.Write(LogPath, sb.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 日志类型 Trace,Error,Warning,SQL
    /// </summary>
    public enum LogType
    {
        Trace,
        Warning,
        Error,
        SQL
    }
}