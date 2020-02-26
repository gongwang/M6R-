using HslCommunication.LogNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6R小圆柱注液机.Foundation
{
    class Log_Helper
    {

        private ILogNet logNet;

        public Log_Helper(string path)
        {
            logNet = new LogNetFileSize(path, 2 * 1024 * 1024);
        }

        public void logWriteInfo(string data)
        {
            logNet.WriteInfo(data);
        }
        /// <summary>
        /// 界面显示消息，msgType为类别，Info，Alarm
        /// </summary>
        /// <param name="data"></param>
        /// <param name="msgType"></param>
        public void DispProcess(string data, string msgType)
        {
            string tempData = data;
            try
            {
                if (eventDispProcess != null)
                {
                    if (msgType == "Info")
                    {
                        tempData = "[消息]" + DateTime.Now.ToString() + "  " + data + "\n";
                        eventDispProcess(tempData, Color.Black);
                    }
                    else if (msgType == "Alarm")
                    {
                        tempData = "[错误]" + DateTime.Now.ToString() + "  " + data + "\n";
                        eventDispProcess(tempData, Color.Red);
                    }
                    tempData = DateTime.Now.ToString() + "  " + data;
                    logNet.WriteInfo(data);
                }
            }
            catch (Exception ex)
            {
                logNet.WriteWarn(ex.Message + "DispProcess函数处");
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }




        public delegate void delegateDispProcess(string msg, Color foreColor);
        public event delegateDispProcess eventDispProcess;//消息显示事件
    }
}
