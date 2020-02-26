using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAction
{
    /// <summary>
    /// 这是关于二进制文件操作的类
    /// </summary>
    class Bin_Helper
    {
        /// <summary>
        /// 将数据以二进制的方式保存到bin文件中
        /// </summary>
        /// <param name="_filepath">文件路径</param>
        /// <param name="_obj">数据内容</param>
        public static void SaveBin(string _filepath, object _obj)
        {
            if (false == System.IO.Directory.Exists("BinData"))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory("BinData");
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_filepath + ".bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, _obj);
            stream.Close();
            stream.Dispose();
        }


        /// <summary>
        /// 读取二进制bin文件
        /// </summary>
        /// <param name="_filepath">文件路径</param>
        /// <returns></returns>
        public static object ReadBin(string _filepath)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream streamc = new FileStream(_filepath + ".bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                object ret = formatter.Deserialize(streamc);
                streamc.Close();
                streamc.Dispose();
                return ret;
            }
            catch (Exception exp)
            {
                throw new Exception("读取二进制文件" + _filepath + "失败！" + "错误信息：" + exp.Message);
            }
        }

    }
}
