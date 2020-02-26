using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Txt_Helper tp = new Txt_Helper();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Xml_Helper xh = new DataAction.Xml_Helper();
            //xh.CreateNode("test", "Namep12pa", "ppa");
            //xh.CreateXml("test");
            //xh.DeleteXml("test");
            //xh.DeleteNode("test", "ppa");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string defaultPath = System.IO.Directory.GetCurrentDirectory().ToString();
            string path = "we.txt";
            if (File.Exists(path))
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("ng");
            }



        }
    }
}
