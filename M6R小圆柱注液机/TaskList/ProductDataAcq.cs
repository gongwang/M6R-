using M6R小圆柱注液机.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M6R小圆柱注液机.TaskList
{
    class ProductDataAcq
    {
        bool status;//获得程序当前的运行状态

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            status = GlobalValues.StatusVariable.status_Running;//获得程序当前的运行状态
        }


        /// <summary>
        /// 实时采集线程
        /// </summary>
        public void MonitorMethod_Vacuometer()
        {
            while (status)
            {
                Thread.Sleep(5000);
            }
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        public void SaveData()
        {

        }


    }
}
