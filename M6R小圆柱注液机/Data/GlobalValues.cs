using M6R小圆柱注液机.Foundation;
using M6R小圆柱注液机.Pages;
using M6R小圆柱注液机.TaskList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M6R小圆柱注液机.Data
{
    class GlobalValues
    {
        /// <summary>
        /// 状态全局变量
        /// </summary>
        public struct StatusVariable
        {
            /// <summary>
            /// 程序运行状态
            /// true：运行状态；false：停止状态
            /// </summary>
            public static bool status_Running;
        }

        /// <summary>
        /// 路径全局变量
        /// </summary>
        public struct PathVariable
        {
            //文件夹路径
            public static string Folder_ConfigurationData;

            //文件路径
            public static string File_CommonPara;
            public static string File_XML_ConfigurationFile;

            //数据库路径
            public static string DataBasePath;
        }

        /// <summary>
        /// 通用变量
        /// </summary>
        public struct CommonVariable
        {
            /// <summary>
            /// 管理员账户登录状态
            /// </summary>
            public static bool isLogicSuccess;

        }


        //声明引用
        public static ProductDataAcq productDataAcq = new ProductDataAcq();//数据采集与存储线程
        public static AlarmAcq alarmAcq = new AlarmAcq();//报警采集与存储线程

        public static LoginPage loginPage = new LoginPage();//登录界面
        public static MainPage mainPage = new MainPage();//主页
        public static SettingPage settingPage = new SettingPage();//设置界面
        public static ProductInquiryPage productInquiryPage = new ProductInquiryPage();//数据查询界面
        public static AlarmInquiryPage alarmInquiryPage = new AlarmInquiryPage();//报警查询界面
        public static ChartPage chartPage = new ChartPage();


        public static Log_Helper log_Helper = new Log_Helper("Logs");
        public static Xml_Helper xml_Helper = new Xml_Helper();

        /// <summary>
        /// 全局变量 初始化
        /// </summary>
        public static void InitPath()
        {
            PathVariable.File_XML_ConfigurationFile = @"ConfigurationData\ConfigurationFile";


            PathVariable.DataBasePath = xml_Helper.ReadXml(PathVariable.File_XML_ConfigurationFile, "mySqlConnStr");
        }



    }
}
