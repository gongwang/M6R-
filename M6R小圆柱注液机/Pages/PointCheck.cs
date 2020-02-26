using DataAction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6R小圆柱注液机.Pages
{
    public partial class PointCheck : Form
    {
        public static float 点检误差 = 0.015f;
        public static float 砝码质量 = 50.000f;

        public static bool pointcheck1 = false;
        public static bool pointcheck2 = false;
        public static bool pointcheck3 = false;
        public static bool pointcheck4 = false;
        public static bool pointcheckOK = false;

        public static float Q1 = 0F;
        public static float Q2 = 0F;
        public static float H1 = 0F;
        public static float H2 = 0F;

        public static string Q1N = "62BAQ02913";
        public static string Q2N = "62BAQ02914";
        public static string H1N = "62BAQ02911";
        public static string H2N = "62BAQ02912";

        public static string Q1R = "-";
        public static string Q2R = "-";
        public static string H1R = "-";
        public static string H2R = "-";

        public PointCheck()
        {
            InitializeComponent();
        }

        private void 点检_Load(object sender, EventArgs e)
        {
         

            ///////////////////////////////////////////////////////////////以下判断是否点检

       
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    

    }
}
