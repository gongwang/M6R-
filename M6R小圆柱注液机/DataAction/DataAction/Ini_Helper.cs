using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAction
{
    /// <summary>
    /// 这是关于 ini 配置文件的类
    /// </summary>
    class Ini_Helper
    {
        public static object lock_txt = new object();


        /// <summary>
        /// ini文件写入
        /// </summary>
        /// <param name="section">节点代号</param>
        /// <param name="key">关键字</param>
        /// <param name="val">值</param>
        /// <param name="filePath">ini文件路径</param>
        /// <returns>long</returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);


        /// <summary>
        /// ini文件读取
        /// </summary>
        /// <param name="section">节点代号</param>
        /// <param name="key">关键字</param>
        /// <param name="def">""</param>
        /// <param name="retVal">temp</param>
        /// <param name="size">500</param>
        /// <param name="filePath">ini文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);



        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        ///  <param name="filePath">ini文件路径</param>
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public static void SaveIni(string filePath, string Section, string Key, string Value)
        {
            lock (lock_txt)
            {
                WritePrivateProfileString(Section, Key, Value, filePath);
            }

        }


        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        ///  <param name="filePath">文件路径</param> 
        /// <param name="Key">键</param> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 

        public static string ReadIni(string filePath, string Section, string Key)
        {
            lock (lock_txt)
            {
                StringBuilder temp = new StringBuilder(500);
                int i = GetPrivateProfileString(Section, Key, "", temp, 500, filePath);
                return temp.ToString();
            }

        }
    }
}
