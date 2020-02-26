using M6R小圆柱注液机.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6R小圆柱注液机
{
    public partial class FormMain : Form
    {
        private Button buttonCurrentSelected = new Button();



        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalValues.InitPath();//初始化文件路径


            //挂在事件       
            GlobalValues.log_Helper.eventDispProcess += Log_Helper_eventDispProcess;     //主界面Log信息显示事件

        }

        private void Log_Helper_eventDispProcess(string msg, Color ForeColor)
        {
            this.Invoke(new EventHandler(delegate
            {
                updataRichText(txtProcessDisp, 10);
                //txtProcessDisp.Focus();
                txtProcessDisp.SelectionColor = ForeColor;
                txtProcessDisp.AppendText(msg);
                //滚动条到最下面
                txtProcessDisp.Select(txtProcessDisp.Text.Length, 0);
                txtProcessDisp.ScrollToCaret();
            }));
        }

        /// <summary>
        /// 限制richTextbox的行数
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="maxLinds"></param>
        private void updataRichText(System.Windows.Forms.RichTextBox richTextBox, int maxLinds)
        {
            if (richTextBox.Lines.Length >= maxLinds)
            {
                richTextBox.SelectionStart = 0;
                richTextBox.SelectionLength = richTextBox.Text.IndexOf("\n") + 1;
                richTextBox.SelectedText = "";
                //光标聚焦在最后一行
                richTextBox.Select(richTextBox.Text.Length, 0);
                richTextBox.ScrollToCaret();
            }
        }








        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.mainPage);
            ButtonSelected(buttonCurrentSelected, btnHome);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.settingPage);
            ButtonSelected(buttonCurrentSelected, btnSetting);
        }

        private void btnProductData_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.productInquiryPage);
            ButtonSelected(buttonCurrentSelected, btnProductData);
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.alarmInquiryPage);
            ButtonSelected(buttonCurrentSelected, btnAlarm);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.loginPage);
            ButtonSelected(buttonCurrentSelected, btnLogin);
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            ShowForm(panelForm, GlobalValues.chartPage);
            ButtonSelected(buttonCurrentSelected, btnChart);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //ShowForm(panelForm, GlobalValues.productInquiry);
            ButtonSelected(buttonCurrentSelected, btnStart);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //ShowForm(panelForm, GlobalValues.productInquiry);
            ButtonSelected(buttonCurrentSelected, btnStop);
        }



        public void ShowForm(System.Windows.Forms.Panel panel, System.Windows.Forms.Form frm)
        {
            if (panel.Controls.Contains(frm))
            {
                return;
            }
            else
            {
                if (panel.Controls.Count > 0)
                {
                    Form f = (Form)panel.Controls[0];
                    f.Hide();
                }
                frm.TopLevel = false;
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                panel.Controls.Clear();
                panel.Controls.Add(frm);
                frm.Show();
                //按钮颜色变为选中
                //button.BackColor = Color.FromArgb(211, 211, 211);
                //其他的按钮变为未选中的颜色（235,235,235）
            }
        }
        //改变按钮颜色变为选中颜色
        private void ButtonSelected(Button currentButton, Button nextButton)
        {
            if (nextButton == currentButton)
            {
                return;
            }
            else
            {
                if (currentButton != null)
                {
                    currentButton.BackColor = Color.FromArgb(200, 200, 200);
                }
                nextButton.BackColor = Color.LightPink;
                buttonCurrentSelected = nextButton;
            }
        }


    }
}
