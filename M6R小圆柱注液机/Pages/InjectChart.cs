using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionFram3
{
    public partial class 图表界面 : Form
    {
        public 图表界面()
        {
            InitializeComponent();
            TopLevel = false ;

       

           // timer1.Start();
        }

        int x = 1;
        int x0 = 0;
        Random rd = new Random();
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //userChart1.MaxY = FormMain.zhuye_max + 0.1;
        //    //userChart1.MinY = FormMain.zhuye_min - 0.1;

        //    userChart1.ListX[0].Add(x);
        //    userChart1.ListY[0].Add(Convert.ToSingle(FormMain.zhuye_min));
        //    userChart1.ListX[1].Add(x);
        //    userChart1.ListY[1].Add(Convert.ToSingle(FormMain.zhuye_max));

        //    userChart1.ListX[6].Add(x);
        //    userChart1.ListY[6].Add(Convert.ToSingle((FormMain.zhuye_min + FormMain.zhuye_max) / 2d));


        //    userChart1.ListX[2].Add(x0);
        //    double d1 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    userChart1.ListY[2].Add(Convert.ToSingle(d1));
        //    userChart1.fresh();
            

        //    userChart1.ListX[3].Add(x0);
        //    double d2 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    userChart1.ListY[3].Add(Convert.ToSingle(d2));
        //    userChart1.fresh();

        //    userChart1.ListX[4].Add(x0);
        //    double d3 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    userChart1.ListY[4].Add(Convert.ToSingle(d3));
        //    userChart1.fresh();

        //    userChart1.ListX[5].Add(x0);
        //    double d4 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    userChart1.ListY[5].Add(Convert.ToSingle(d4));
        //    userChart1.fresh();

        //    x0++;
        //    x++;
        //    userChart1.IntervalX = userChart1.TotalCount / 20;
        //}


        //public void ChartAdd(MyControl.UserChart _userchart, float _min, float _max, float _x, float _y1, float _y2, float _y3, float _y4, float _y5)
        //{
        //    _userchart.ListX[0].Add(x);
        //    _userchart.ListY[0].Add(Convert.ToSingle(FormMain.zhuye_min));
        //    _userchart.ListX[1].Add(x);
        //    _userchart.ListY[1].Add(Convert.ToSingle(FormMain.zhuye_max));

        //    _userchart.ListX[6].Add(x);
        //    _userchart.ListY[6].Add(Convert.ToSingle((FormMain.zhuye_min + FormMain.zhuye_max) / 2d));

        //    _userchart.ListX[2].Add(x0);
        //    double d1 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    _userchart.ListY[2].Add(Convert.ToSingle(d1));
        //    _userchart.fresh();

        //    _userchart.ListX[3].Add(x0);
        //    double d2 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    _userchart.ListY[3].Add(Convert.ToSingle(d2));
        //    _userchart.fresh();

        //    _userchart.ListX[4].Add(x0);
        //    double d3 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    _userchart.ListY[4].Add(Convert.ToSingle(d3));
        //    _userchart.fresh();

        //    _userchart.ListX[5].Add(x0);
        //    double d4 = rd.NextDouble() * (FormMain.zhuye_max - FormMain.zhuye_min) + FormMain.zhuye_min;
        //    _userchart.ListY[5].Add(Convert.ToSingle(d4));
        //    _userchart.fresh();

        //    x0++;
        //    x++;
        //    _userchart.IntervalX = _userchart.TotalCount / 20;
        //}


        private void 图表界面_Load(object sender, EventArgs e)
        {
            userChart1.InitChartset();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (userChart1.ShowCount > 20)
            {
                userChart1.ShowCount -= 5;
                userChart1.IntervalX = userChart1.ShowCount / 20;
            }
            //userChart1.fresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userChart1.ShowCount += 5;
            userChart1.IntervalX = userChart1.ShowCount / 20;
            //userChart1.fresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userChart1.MaxY > userChart1.MinY + 0.03)
            {
                userChart1.MaxY -= 0.01;
                userChart1.MinY += 0.01;
                userChart1.IntervalY = (userChart1.MaxY - userChart1.MinY) / 20d;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userChart1.MaxY += 0.01;
            userChart1.MinY -= 0.01;
            userChart1.IntervalY = (userChart1.MaxY - userChart1.MinY) / 20d;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //    userChart1.ItemVisible[2] = true;
            //else
            //    userChart1.ItemVisible[2] = false;
            //userChart1.fresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        //    if (checkBox2.Checked)
        //        userChart1.ItemVisible[3] = true;
        //    else
        //        userChart1.ItemVisible[3] = false;
        //    userChart1.fresh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox3.Checked)
            //    userChart1.ItemVisible[4] = true;
            //else
            //    userChart1.ItemVisible[4] = false;
            //userChart1.fresh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox4.Checked)
            //    userChart1.ItemVisible[5] = true;
            //else
            //    userChart1.ItemVisible[5] = false;
            //userChart1.fresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //label5.Text = string.Join(",", 指令执行.cpklist1.ToArray());
            //label6.Text = string.Join(",", 指令执行.cpklist2.ToArray());
            //label7.Text = string.Join(",", 指令执行.cpklist3.ToArray());
            //label8.Text = string.Join(",", 指令执行.cpklist4.ToArray());

            //SAVE.SaveArry("userChart1_listY1.bin", userChart1.ListY[0]);
            //SAVE.SaveArry("userChart1_listY2.bin", userChart1.ListY[1]);
            //SAVE.SaveArry("userChart1_listY3.bin", userChart1.ListY[2]);
            //SAVE.SaveArry("userChart1_listY4.bin", userChart1.ListY[3]);
            //SAVE.SaveArry("userChart1_listY5.bin", userChart1.ListY[4]);
            //SAVE.SaveArry("userChart1_listY6.bin", userChart1.ListY[5]);
            //SAVE.SaveArry("userChart1_listY7.bin", userChart1.ListY[6]);

            //SAVE.SaveArry("userChart1_listX1.bin", userChart1.ListX[0]);
            //SAVE.SaveArry("userChart1_listX2.bin", userChart1.ListX[1]);
            //SAVE.SaveArry("userChart1_listX3.bin", userChart1.ListX[2]);
            //SAVE.SaveArry("userChart1_listX4.bin", userChart1.ListX[3]);
            //SAVE.SaveArry("userChart1_listX5.bin", userChart1.ListX[4]);
            //SAVE.SaveArry("userChart1_listX6.bin", userChart1.ListX[5]);
            //SAVE.SaveArry("userChart1_listX7.bin", userChart1.ListX[6]);


        }

        private void 图表界面_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void 导入上次数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

          

        }

        private void userChart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void userChart1_mousedown_1(object sender, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            userChart1.fresh();
            
        }

        private void userChart1_Load(object sender, EventArgs e)
        {

        }

    }
}
