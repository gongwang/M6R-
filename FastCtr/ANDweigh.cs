using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FastCtr
{
    public partial class ANDweigh : UserControl
    {
        private NewSerialPort ANDserial;
       
        public ANDweigh()
        {
            InitializeComponent();
            
        }

        public ANDweigh(NewSerialPort serialport)
        {
            InitializeComponent();
            ANDserial = serialport;
            Name = ANDserial.Name;
    
        }

        public void PowerON()
        {
            if (ANDserial == null)
                return;
            if (ANDserial.IsOpen)
                ANDserial.SendMessage("ON\r\n");
        }

        public void PowerOFF()
        {
            if (ANDserial == null)
                return;
            if (ANDserial.IsOpen)
                ANDserial.SendMessage("OFF\r\n");
        }

        public string GetWeightInstant(int timeout)
        {
            if (ANDserial == null)
                return null;
            return ConvertString(ANDserial.SendBackMessageInstant("Q\r\n", timeout));
        }

        public string GetWeightStable(int timeout)
        {
            if (ANDserial == null)
                return null;
            return ConvertString(ANDserial.SendBackMessageInstant("S\r\n", timeout));
        }

        public bool Zero(int milliSenconds)
        {
            int timeout = 0;
            if (ANDserial == null)
                return false;
            ANDserial.SendMessage("R\r\n");
            while (String.IsNullOrEmpty(ANDserial.SendBackMessageIntime("Q\r\n", 100)) && timeout < milliSenconds / 100)
            {
                Thread.Sleep(5);
                timeout++;
            }
            if (timeout >= milliSenconds / 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ZeroV(int milliSenconds)
        {
            int timeout = 0;
            if (ANDserial == null)
                return ;
            ANDserial.SendMessage("R\r\n");
            while (String.IsNullOrEmpty(ANDserial.SendBackMessageIntime("Q\r\n", 100)) && timeout < milliSenconds / 100)
            {
                Thread.Sleep(5);
                timeout++;
            }
        }

        private string ConvertString(string content)
        {
            if (string.IsNullOrEmpty(content))
                return null;
            string ret = "";
            if (content.Contains("ST,") || content.Contains("US,"))
            {
                char[] chenzhong = content.Split(',')[1].ToCharArray(0, 9);
                for (int i = 0; i < 9; i++)
                {
                    ret += chenzhong[i];
                }
                return ret;
            }
            else
            {
                return null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PowerON();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PowerOFF();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ret = GetWeightInstant(1000);
            if (!string.IsNullOrEmpty(ret))
                textBox1.Text = ret;
            else
                textBox1.Text = "err";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ret = GetWeightStable(3000);
            if (!string.IsNullOrEmpty(ret))
                textBox2.Text = ret;
            else
                textBox2.Text = "err";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZeroV(5000);
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.AutoSize = true;
            form.Text = ANDserial.Name;
            form.Controls.Add(ANDserial);
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form)sender).Controls.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                NewSerialPortSetting setting = (NewSerialPortSetting)DataAction.SaveStatic.ReadBinF(Parent.Text);
                ANDserial = new NewSerialPort(setting._port, setting._baudrate, setting._parity, setting._databit, setting._stopbit);
                
                ANDserial.Open();
                if (ANDserial.IsOpen)
                {
                    this.BackColor = Color.LightGreen;
                }
            }
            catch { }
        }

        private void ANDweigh_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ANDserial.IsOpen)
            {
                ANDserial.Close();
                this.BackColor = Color.Khaki;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ANDserial.IsOpen)
            {
                this.BackColor = Color.GreenYellow;
                label5.Text = ANDserial.setting._port + "-已打开";
            }
            else
            {
                this.BackColor = Color.LightGray;
                label5.Text = "已关闭";
            }
        }

        private void ANDweigh_ParentChanged(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
