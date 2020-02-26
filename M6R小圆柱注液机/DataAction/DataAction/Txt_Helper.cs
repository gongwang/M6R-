using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataAction
{
    /// <summary>
    /// 这是关于TXT文件操作的类
    /// </summary>
    class Txt_Helper
    {
        private object lock_txt = new object();

        /// <summary>
        /// 保存字符串到指定文件位置
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <param name="_contents">数据内容</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, string _contents, bool _append)
        {
            lock (lock_txt)
            {
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", _contents + "\r\n", Encoding.Default);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", _contents + "\r\n", Encoding.Default);
                }
            }
        }


        /// <summary>
        /// 保存浮点数数组到指定文件位置
        /// </summary>
        /// <param name="_path">指定文件路径</param>
        /// <param name="_contents">浮点数数组</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, IEnumerable<float> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string[] uu = Array.ConvertAll<float, string>(_contents.ToArray(), Convert.ToString);
                if (!_append)
                {
                    File.WriteAllLines(_path + ".txt", uu, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllLines(_path + ".txt", uu, Encoding.UTF8);
                }
            }
        }


        /// <summary>
        /// 保存整形数组到指定文件路径
        /// </summary>
        /// <param name="_path">指定文件路径</param>
        /// <param name="_contents">整数型数组</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, IEnumerable<int> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string[] uu = Array.ConvertAll<int, string>(_contents.ToArray(), Convert.ToString);
                if (!_append)
                {
                    File.WriteAllLines(_path + ".txt", uu, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllLines(_path + ".txt", uu, Encoding.UTF8);
                }
            }
        }

     
        /// <summary>
        /// 保存一维字符串数组类型到指定位置
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_contents">字符串类型的一维数组，string[][]</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, IEnumerable<string[]> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string str = "";
                foreach (string[] a in _contents)
                {
                    str = str + string.Join("\t", a) + "\r\n";
                }
                //Array.ConvertAll<string[], string>(_contents, Convert.ToString);
                //string.Join(",", _contents);
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", str, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", str, Encoding.UTF8);
                }
            }
        }


        /// <summary>
        /// 保存一维浮点数数组类型到指定位置
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_contents">浮点数类型的一维数组，float[][]</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, IEnumerable<float[]> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string str = "";
                foreach (float[] a in _contents)
                {
                    str = str + string.Join(",", a) + "\r\n";
                }
                //Array.ConvertAll<string[], string>(_contents, Convert.ToString);
                //string.Join(",", _contents);
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", str, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", str, Encoding.UTF8);
                }
            }
        }


        /// <summary>
        /// 保存一维整数型数组类型到指定文件位置
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <param name="_contents">整型数组类型的一维数组，int[][]</param>
        /// <param name="_append">如果文件不存在，能否创建文件，true为创建新文件，false为不创建</param>
        public void SaveTxt(string _path, IEnumerable<int[]> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string str = "";
                foreach (int[] a in _contents)
                {
                    str = str + string.Join(",", a) + "\r\n";
                }
                //Array.ConvertAll<string[], string>(_contents, Convert.ToString);
                //string.Join(",", _contents);
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", str, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", str, Encoding.UTF8);
                }
            }
        }


        /// <summary>
        /// 保存二维字符串类型的数组到指定文件位置
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <param name="arr">数据内容</param>
        public void SaveTxt(string _path, string[,] arr, bool append)
        {
            string sign = " "; //元素之间分隔符号，此处设置为空格，可自行更改设置
            StreamWriter sw = new StreamWriter(_path + ".txt", append); //第一个参数是读取到流的文件名，第二个参数是如果文件不存在，能否创建文件，true为创建新文件，false为不创建
            for (int i = 0; i < arr.GetLength(0); i++)//行数
            {
                for (int j = 0; j < arr.GetLength(1); j++)//列数
                {
                    sw.Write(arr[i, j] + sign);
                    sw.WriteLine();
                }
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        ///Console.WriteLine(arr.GetLength(0));        //求行数
        ///Console.WriteLine(arr.GetLength(1));        //求列数


        /// <summary>
        /// 保存二维字符串类型的数组到指定文件位置
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <param name="arr">数据内容</param>
        public void SaveTxt(string _path, int[,] arr, bool append)
        {
            string sign = " "; //元素之间分隔符号，此处设置为空格，可自行更改设置
            StreamWriter sw = new StreamWriter(_path + ".txt", append); //第一个参数是读取到流的文件名，第二个参数是如果文件不存在，能否创建文件，true为创建新文件，false为不创建
            for (int i = 0; i < arr.GetLength(0); i++)//行数
            {
                for (int j = 0; j < arr.GetLength(1); j++)//列数
                {
                    sw.Write(arr[i, j].ToString() + sign);
                    sw.WriteLine();
                }
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }


        /// <summary>
        /// 保存二维字符串类型的数组到指定文件位置
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <param name="arr">数据内容</param>
        public void SaveTxt(string _path, float[,] arr, bool append)
        {
            string sign = " "; //元素之间分隔符号，此处设置为空格，可自行更改设置
            StreamWriter sw = new StreamWriter(_path + ".txt", append); //第一个参数是读取到流的文件名，第二个参数是如果文件不存在，能否创建文件，true为创建新文件，false为不创建
            for (int i = 0; i < arr.GetLength(0); i++)//行数
            {
                for (int j = 0; j < arr.GetLength(1); j++)//列数
                {
                    sw.Write(arr[i, j].ToString() + sign);
                    sw.WriteLine();
                }
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }



        /// <summary>
        /// 存储特殊类型的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_path">文件路径</param>
        /// <param name="_contents">数据内容</param>
        /// <param name="_append">是否将数据追加到文件末尾</param>
        public void SaveTxt<T>(string _path, IEnumerable<T> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string str = "";
                str = string.Join(",", _contents) + "\r\n";
                //Array.ConvertAll<string[], string>(_contents, Convert.ToString);
                //string.Join(",", _contents);
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", str, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", str, Encoding.UTF8);
                }
            }
        }


        /// <summary>
        /// 存储特殊类型的一维数据，比如List.ToArray()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_path">文件路径</param>
        /// <param name="_contents">数据内容</param>
        /// <param name="_append">是否将数据追加到文件末尾</param>
        public void SaveTxt<T>(string _path, IEnumerable<T[]> _contents, bool _append)
        {
            lock (lock_txt)
            {
                string str = "";
                foreach (T[] a in _contents)
                {
                    str = str + string.Join(",", a) + "\r\n";
                }
                //Array.ConvertAll<string[], string>(_contents, Convert.ToString);
                //string.Join(",", _contents);
                if (!_append)
                {
                    File.WriteAllText(_path + ".txt", str, Encoding.UTF8);
                }
                else
                {
                    File.AppendAllText(_path + ".txt", str, Encoding.UTF8);
                }
            }
        }
        ///eg:     public static List<object[]> chartlist2 = new List<object[]>();
        ///           Save.SaveTxt("F:\\10.txt", chartlist2.ToArray(), false);


        /// <summary>
        /// 保存datatable类型到逗号分隔符文件
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_dt"></param>
        /// <param name="_titleInclude">是否显示行标题</param>
        /// <param name="_append">是否将数据追加到文件末尾</param>
        public void SaveTxt(string _path, DataTable _dt, bool _titleInclude, bool _append)
        {
            lock (lock_txt)
            {
                if (!_titleInclude)
                {
                    int count = _dt.Rows.Count;
                    string[][] strArry = new string[count][];
                    for (int i = 0; i < count; i++)
                    {
                        strArry[i] = Array.ConvertAll(_dt.Rows[i].ItemArray, Convert.ToString);
                    }
                    SaveTxt(_path + ".txt", strArry, _append);
                }
                else
                {
                    int count = _dt.Rows.Count + 1;
                    string[][] strArry = new string[count][];
                    strArry[0] = new string[_dt.Columns.Count];
                    for (int j = 0; j < _dt.Columns.Count; j++)
                    {
                        strArry[0][j] = _dt.Columns[j].ColumnName;
                    }
                    for (int i = 1; i < count; i++)
                    {
                        strArry[i] = Array.ConvertAll(_dt.Rows[i - 1].ItemArray, Convert.ToString);
                    }
                    SaveTxt(_path + ".txt", strArry, _append);
                }
            }
        }



        ///***************************************************************///
        ///***************************************************************///
        ///***************************************************************///


        /// <summary>
        /// 读取单列TXT文件，返回string类型的数组（一维）
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <returns></returns>
        public string[] ReadTxt(string _path)
        {
            lock (lock_txt)
            {
                return File.ReadLines(_path + ".txt", Encoding.UTF8).ToArray();
            }
        }


        /// <summary>
        /// 读取带逗号分隔符的TXT文件，返回string[][]类型的数组（二维）
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <returns></returns>
        public string[][] ReadMultiTxt(string _path)
        {
            lock (lock_txt)
            {
                string[] strRow = File.ReadLines(_path + ".txt", Encoding.UTF8).ToArray();
                if (strRow.Count() == 0)
                {
                    return null;
                }
                string[][] retstr = new string[strRow.Count()][];
                for (int i = 0; i < strRow.Count(); i++)
                {
                    retstr[i] = strRow[i].Split(',');
                }
                return retstr;
            }
        }


        /// <summary>
        /// 读取带制表符的TXT文件，返回string[][]类型的数组（二维）
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public string[][] ReadMultiTxtT(string _path)
        {
            lock (lock_txt)
            {
                string[] strRow = File.ReadLines(_path + ".txt", Encoding.Default).ToArray();
                if (strRow.Count() == 0)
                {
                    return null;
                }
                string[][] retstr = new string[strRow.Count()][];
                for (int i = 0; i < strRow.Count(); i++)
                {
                    retstr[i] = strRow[i].Split('\t');
                }
                return retstr;
            }
        }


        ///**************************************************************///
        ///**************************************************************///
        ///**************************************************************///


        /// <summary>
        /// 二维数组的转换
        /// 将特殊的二维数组转换成字符串二维数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_arry2"></param>
        /// <returns></returns>
        public static string[][] TransPosition<T>(T[][] _arry2)
        {
            string[][] arry = new string[_arry2[0].Count()][];
            for (int k = 0; k < _arry2[0].Count(); k++)
            {
                arry[k] = new string[_arry2.Count()];
            }

            for (int i = 0; i < _arry2.Count(); i++)
            {
                for (int j = 0; j < _arry2[i].Count(); j++)
                {
                    arry[j][i] = _arry2[i][j].ToString();
                }
            }
            return arry;
        }





    }
}
