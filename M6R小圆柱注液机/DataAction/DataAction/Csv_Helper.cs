using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAction
{
    /// <summary>
    /// 这是关于csv文件操作的类
    /// </summary>
    class Csv_Helper
    {
        /// <summary>
        /// 保存List数据到csv文件中
        /// </summary>
        /// <param name="data">list数据</param>
        /// <param name="append">是否将数据追加在文末</param>
        /// <param name="path">保存路径</param>
        public void SaveCSV(List<string> data, bool append, string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                fi.Directory.Create();
            }
            //FileStream fs = new FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            StreamWriter sw = new StreamWriter(path, append, System.Text.Encoding.UTF8);
            string dataStr = "";
            for (int i = 0; i < data.Count; i++)
            {
                dataStr += data[i];
                if (i < data.Count - 1)
                {
                    dataStr += ",";
                }
            }

            sw.WriteLine(dataStr);
            sw.Close();
        }


       //读取csv文件的方式，可以直接参考Excel文件读取的方式，毕竟，csv文件的读取方式和Excel的读取方式可以是一样的
    }
}
