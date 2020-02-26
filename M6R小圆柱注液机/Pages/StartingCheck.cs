
using OmroPlcVar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionFram3
{
    public partial class 开机验证 : Form
    {
        //public static event OnExceptionVEventHandler onExceptionV;

        public static event EventHandler OnDianJieYeCheckSuccess;
        public static bool StartCheck1 = false;
        public static bool StartCheck2 = false;
        public static string 物料编码 = "";
        public static string 电解液号 = "";
        public static string 物料编码验证时间 = "";
        public static string 电解液号验证时间 = "";
        public static int checkTime = 5;
        public static bool Time2RestartSignal = false;
        public static bool Time3RestartSignal = false;
        string[] wuliao_dianjieye = new string[2] { "", "" };
        public 开机验证()
        {
            InitializeComponent();
           
        }

        private void menuButton2_SelectedChanged(object sender, EventArgs e)
        {
           
        }

        public static void bianmaCheck()
        {
           
        }

        private void menuButton3_SelectedChanged(object sender, EventArgs e)
        {

           
        }

        public static void dianjieyeCheck()
        {
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Program.FormMain1.comboBox1.SelectedIndex = comboBox2.SelectedIndex;
            //saveVarible saveVaribleCheck = new saveVarible();
            //saveVaribleCheck.AutoCheckTime = comboBox2.SelectedIndex;
            //checkTime = int.Parse(comboBox2.Items[comboBox2.SelectedIndex].ToString());
            //SAVE.SaveVar("xunhuanjianceshijian", saveVaribleCheck);
        }

        private void 开机验证_Load(object sender, EventArgs e)
        {
            this.TopLevel = true;


        }

        private void 开机验证_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void menuButton1_SelectedChanged(object sender, EventArgs e)
        {
          
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 开机验证_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            StartCheck1 = false;
            StartCheck2 = false;
            label3.Text = "-";
            label3.BackColor = Color.Beige;
            label4.Text = "-";
            label4.BackColor = Color.Beige;
            button1.Enabled = false;
            groupBox2.Enabled = false;
        }
    }
}
