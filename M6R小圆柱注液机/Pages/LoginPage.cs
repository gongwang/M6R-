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


namespace M6R小圆柱注液机.Pages
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cbmUserName.Items.Add("     管 理 员");
            cbmUserName.Items.Add("     工 程 师");
            cbmUserName.Items.Add("     操 作 员");
            cbmUserName.SelectedIndex = 0;

            tbPassword.Text = string.Empty;
            this.Show();//先Show 才能设置焦点，下面focus方法才有用
            tbPassword.Focus();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Xml_Helper xml_Helper = new Xml_Helper();
            string cmbName = "";
            switch (cbmUserName.Text)
            {
                case "     管 理 员": cmbName = "Administrator"; break;
                case "     工 程 师": cmbName = "Engineer"; break;
                case "     操 作 员": cmbName = "Operator"; break;
                default: break;
            }
            string result = xml_Helper.ReadXml(GlobalValues.PathVariable.File_XML_ConfigurationFile, cmbName);
            if (result == tbPassword.Text)
            {
                MessageBox.Show("登录成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalValues.log_Helper.DispProcess("登录成功", "Info");
                GlobalValues.CommonVariable.isLogicSuccess = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败，请检查", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GlobalValues.log_Helper.DispProcess("登录失败，请检查", "Alarm");
                GlobalValues.CommonVariable.isLogicSuccess = false;
                tbPassword.Text = string.Empty;
                tbPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalValues.CommonVariable.isLogicSuccess = false;
            this.Close();
        }


    }
}

