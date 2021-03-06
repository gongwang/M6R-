﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  OMRON.Compolet.CIP;
using System.Collections;
using System.Control;

namespace FastCtr
{
    [Serializable]
    struct OmroPlcMultiVarSetting
    {
        public ConnectionType ConnectionType;
        public long ReceiveTimeLimit;
        public bool UseRoutePath;
        public string PeerAddress;
        public int LocalPort;
        public bool Active;
    }
    public delegate void OnVarChangedHandler(string varname,object value);

    public partial class OmroPlcMultiVar : UserControl
    {

        Hashtable HT = new Hashtable();

        List<string> Contemplistvar = new List<string>();
        bool IsInitSuccess = false;
        OmroPlcMultiVarSetting setting;

        public TaskActionCtr taskActionCtr = new TaskActionCtr();
        bool scanflag = false;
        Dictionary<string, object> ContempValues = new Dictionary<string, object>(); 
        //Dictionary<object, Dictionary<object, string>> dictionaryList = new Dictionary<object, Dictionary<object, string>>();
        TaskFrameGlobal tfglobal;
        public NJCompolet njCompolet = new NJCompolet();
        List<string> listvar = new List<string>();
        public event OnVarChangedHandler OnVarChanged;
     
        public OmroPlcMultiVar()
        {
            InitializeComponent();
            taskActionCtr.Name = "Var扫描";
            this.ParentChanged += new EventHandler(controlchanged);

        }
        public OmroPlcMultiVar(string name)
        {
            InitializeComponent();
            taskActionCtr.Name = "Var扫描";
            this.Name = name;
            this.ParentChanged += new EventHandler(controlchanged);
        }




        public OmroPlcMultiVar(NJCompolet _njCompolet)
        {
            InitializeComponent();
            njCompolet = _njCompolet;
        }

        private bool InitPlc()
        {
            try
            {
                OmroPlcMultiVarSetting setting = (OmroPlcMultiVarSetting)DataAction.SaveStatic.ReadBinF(Name + "_Connection");
                njCompolet.ConnectionType = setting.ConnectionType;
                njCompolet.ReceiveTimeLimit = setting.ReceiveTimeLimit;
                njCompolet.UseRoutePath = setting.UseRoutePath;
                njCompolet.PeerAddress = setting.PeerAddress;
                njCompolet.LocalPort = setting.LocalPort;
                njCompolet.Active = setting.Active;
                if (njCompolet.IsConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(Name + "_Connection" + "配置失败！");
                return false;
            }
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("空字符串", "提示");
                return;
            }
            if (listvar.Exists(t => t == textBox1.Text))
            {
                MessageBox.Show("该变量已存在！", "提示");
                return;
            }
            listvar.Add(textBox1.Text);
            DataAction.SaveStatic.SaveBinF(Name + "_Var", listvar);
            object ret = DataAction.SaveStatic.ReadBinF(Name+  "_Var");
            if (ret != null)
                listvar = (List<string>)ret;
           // listBox1.DataSource = listvar;
        }

        private void OmroPlcMultiVar_Load(object sender, EventArgs e)
        {
            label14.Text = this.Name;
            comboBox1.DataSource = Enum.GetNames(typeof(ConnectionType));
            comboBox2.Items.Add(true);
            comboBox2.Items.Add(false);
            comboBox3.Items.Add(true);
            comboBox3.Items.Add(false);
            try
            {
                OmroPlcMultiVarSetting setting = (OmroPlcMultiVarSetting)DataAction.SaveStatic.ReadBinF(Name+"_Connection");//文件保存以父容器的文本命名
                comboBox1.SelectedItem = setting.ConnectionType.ToString();
                textBox4.Text = setting.ReceiveTimeLimit.ToString();
                comboBox3.SelectedItem = setting.UseRoutePath;
                textBox6.Text = setting.PeerAddress;
                textBox7.Text = setting.LocalPort.ToString();
                comboBox2.SelectedItem = setting.Active;
            }
            catch { }
            
           // timer2.Start();
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("空字符串", "提示");
                return;
            }
            try
            {
                textBox2.Text = ReadSingleVariable(textBox1.Text).ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }


      
        public Hashtable ReadMultiVariables(List<string> varnames)
        {
            //lock (this)
            //{
            //    try
            //    {
            //        Hashtable ht = njCompolet.ReadVariableMultiple(varnames.ToArray());
            //        return ht;
            //    }
            //    catch
            //    {
            //        try
            //        {
            //            Hashtable ht = njCompolet.ReadVariableMultiple(varnames.ToArray());
            //            return ht;
            //        }
            //        catch
            //        {
            //            try
            //            {
            //                Hashtable ht = njCompolet.ReadVariableMultiple(varnames.ToArray());
            //                return ht;
            //            }
            //            catch (Exception exp)
            //            {
            //                throw new Exception("读取多变量" + DataAction.Conver.ConvertToString(varnames, ",") + "失败！" + exp.ToString());
            //            }
            //        }
            //    }
            //}

          
            return HT;
        }

        //读取单个PLC变量
        int k =4;
        public object ReadSingleVariable(string varibleName)
        {
            //lock (this)
            //{
            //    try
            //    {
            //        return njCompolet.ReadVariable(varibleName);
            //    }
            //    catch
            //    {
            //        try
            //        {
            //            return njCompolet.ReadVariable(varibleName);    //读取失败多次读取，一共三次
            //        }
            //        catch
            //        {
            //            try
            //            {
            //                return njCompolet.ReadVariable(varibleName);
            //            }
            //            catch (Exception exp)
            //            {
            //                throw new Exception("读取PLC变量" + varibleName + "失败！" + exp.ToString());
            //            }
            //        }
            //    }
            //}
            if (varibleName == "r")
            {
      
                return k;

            }
            return 0;
        }
        //写入单个PLC变量
        public void WriteSingleVariable(string varibleName, object writeData)
        {
            lock (this)
            {
                try
                {
                    njCompolet.WriteVariable(varibleName, writeData);
                }
                catch
                {
                    try
                    {
                        njCompolet.WriteVariable(varibleName, writeData);      //写入失败多次写入，一共三次
                    }
                    catch
                    {
                        try
                        {
                            njCompolet.WriteVariable(varibleName, writeData);
                        }
                        catch (Exception exp)
                        {
                            throw new Exception("写入PLC变量" + varibleName + "失败！" + exp.ToString());
                        }
                    }
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                setting.ConnectionType = (ConnectionType)Enum.Parse(typeof(ConnectionType), comboBox1.Text);
                setting.ReceiveTimeLimit = long.Parse(textBox4.Text);
                setting.UseRoutePath = bool.Parse(comboBox3.Text);
                setting.PeerAddress = textBox6.Text;
                setting.LocalPort = int.Parse(textBox7.Text);
                setting.Active = bool.Parse(comboBox2.Text);
                DataAction.SaveStatic.SaveBinF(Name + "_Connection", setting);
            }
            catch
            {
                MessageBox.Show("保存失败！", "message");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OmroPlcMultiVar_Click(object sender, EventArgs e)
        {
            label1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InitPLC();
        }


        public void InitPLC()
        {
           IsInitSuccess =InitPlc();
           //throw new Exception("PLC连接失败");
           
        }


        private void bt_init_Click(object sender, EventArgs e)
        {
            InitVar();
       
         
        }


        public void InitVar()
        {

            try
            {
                taskActionCtr.OnFunctionTaskInitialed += new FunctionTaskEvent(taskScan_OnFunctionTaskInitialed);
                taskActionCtr.OnFunctionTaskStarted += new FunctionTaskEvent(taskScan_OnFunctionTaskStarted);
                //taskActionCtr.OnFunctionTaskOvered += new FunctionTaskEvent(taskScan_OnFunctionTaskOvered);
                taskActionCtr.OnFunctionTaskFaulted += new FunctionTaskEvent(taskScan_OnFunctionTaskFaulted);

                //初始化变量数组
                object ret = DataAction.SaveStatic.ReadBinF(Name + "_Var");//读取以控件名称命名文件
                if (ret != null)
                    listvar = (List<string>)ret;
                //初始化PLC变量监测初始值
                foreach (string varname in listvar)
                {
                    if (!ContempValues.ContainsKey(varname))
                        ContempValues.Add(varname, new object());
                }
                //显示listbox的检测变量



               // listBox1.DataSource = listvar;




                taskActionCtr.Function = new FunctionHandle(() =>
                {
                    try
                    {
                        scanflag = true;

                        while (scanflag)
                        {
                            Thread.Sleep(50);//50ms 扫描一周变量
                            Hashtable ht = ReadMultiVariables(listvar);
                            foreach (string varname in listvar)
                            {
                                object value = ht[varname];
                                if (!ContempValues[varname].Equals(value))
                                {
                                    ContempValues[varname] = value;
                                    if (OnVarChanged != null)
                                    {
                                        Task changetask = new Task(new Action(() =>
                                            {
                                                OnVarChanged(varname, value);//委托一个值改变事件
                                            }), TaskCreationOptions.LongRunning);
                                        changetask.Start();
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception exp)
                    {
                        MessageBox.Show("任务内容初始化失败\r\n"+exp.ToString());
                    }

                });

                HT.Add(listvar[0], 0);
                HT.Add(listvar[1], 0);
            }
            catch (Exception exp)
            {
                MessageBox.Show("初始化失败！" + exp.ToString());
                throw new Exception("初始化失败！");
            }





        }





        private void button10_Click(object sender, EventArgs e)
        {
            listvar.Remove(listBox1.SelectedItem.ToString());
            DataAction.SaveStatic.SaveBinF(Name + "_Var", listvar);
            object ret = DataAction.SaveStatic.ReadBinF(Name + "_Var");
            if (ret != null)
                listvar = (List<string>)ret;
          

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }



        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HT[listvar[0]] = true;
            HT[listvar[1]] = 8;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                taskActionCtr.Start();
              

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }


        

        private void button4_Click(object sender, EventArgs e)
        {
            scanflag = false;
            
        }

        private void taskScan_OnFunctionTaskInitialed(object sender, FunctionTaskEventArgs args)
        {
            //taskActionCtr.UIshow(label13);
        }
        private void taskScan_OnFunctionTaskStarted(object sender, FunctionTaskEventArgs args)
        {
            //taskActionCtr.UIshow(label13);
        }
        private void taskScan_OnFunctionTaskOvered(object sender, FunctionTaskEventArgs args)
        {
            //taskActionCtr.UIshow(label13);
        }
        private void taskScan_OnFunctionTaskFaulted(object sender, FunctionTaskEventArgs args)
        {
            //taskActionCtr.UIshow(label13);
        }

        private void label13_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (taskActionCtr.State == StateType.faulted)
            {
                Form form = new Form();
                form.Text = this.Name + ":错误消息";
                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                TextBox txt = new TextBox();
                txt.ReadOnly = true;
                txt.Dock = DockStyle.Fill;
                txt.Multiline = true;
                txt.Width = 500;
                txt.Height = 300;
                txt.ScrollBars = ScrollBars.Both;
                txt.Text = taskActionCtr.Exp.ToString();
                form.Controls.Add(txt);
                form.ShowDialog();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataAction.SaveStatic.SaveBinF(Name + "_Var", listvar);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            taskActionCtr.UIshow(label13);
            if (IsInitSuccess)
            {

                label11.BackColor = Color.LimeGreen;
                label11.Text = "PLC连接成功！";
            }
            else
            {
                label11.BackColor = Color.Yellow;
                label11.Text = "PLC连接失败！";
            }
            listBox1.DataSource = listvar;

            if (taskActionCtr.State == StateType.busy)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button4.Enabled = false;
                button3.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.ParentForm.IsHandleCreated)
            {
                if (ParentForm.Opacity >= 1)
                {
                    timer2.Stop();
                }
                else
                {
                    ParentForm.Opacity += 0.2;
                }
            }
        }

        private void controlchanged(object sender, EventArgs e)
        {
            if (this.ParentForm!=null)
            {
                this.ParentForm.Opacity = 0;
                timer2.Start();
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
            }
        }


    }
}
