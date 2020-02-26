using myEvent;
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入物料编码！");
                menuButton2.Selected = false;
                return;
            }
                
            物料编码 = textBox1.Text;
            Task task = new Task(new Action(() =>
            {
                bianmaCheck();
            }));
            task.Start();
            Task task1 = Task.WhenAll(task);
            task1.ContinueWith(tt =>
            {
                this.Invoke(new Action(() =>
                {
                    menuButton2.Selected = false;
                    if (StartCheck1)
                    {
                        groupBox2.Enabled = true;
                        label3.Text = "OK";
                        label3.BackColor = Color.LimeGreen;
                        groupBox1.Enabled = false;

                        DataAction.Save.SaveBin("Vwuliao", 物料编码);
                    }
                    else
                    {
                        label3.Text = "NG";
                        label3.BackColor = Color.IndianRed;
                        groupBox2.Enabled = false;

                    }
                }));
            });
        }

        public static void bianmaCheck()
        {
            string retLogIn = "";
            try
            {
                ////////////////////////////////
                retLogIn = Program.FormATLscan.SendBackMessageInstant(物料编码, 2000);
                if (retLogIn.Contains("OK"))
                {
                    StartCheck1 = true;
                    //Program.FormMain1.timeCount2.ReStart(); //成品编码验证或再次验证成功时候
                    物料编码验证时间 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Thread t = new Thread(new ThreadStart(new ThreadStart(() =>
                    {
                        Time2RestartSignal = true;
                        Thread.Sleep(2000);
                        Time2RestartSignal = false;
                    })));
                    t.Start();

                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("LOG:" + "成品编码" + 物料编码 + "验证成功！"));
                    }
                }
                else if (retLogIn.Contains("NG"))
                {
                    StartCheck1 = false;
                    if (retLogIn.Contains("E0006"))
                    {
                        if (onLogEvent != null)
                        {
                            onLogEvent(new OnLogEventArgs("ERR:" + "成品编码" + 物料编码 + "成品P/N验证不存在"));
                        }
                    }
                    else if (retLogIn.Contains("E0007"))
                    {
                        if (onLogEvent != null)
                        {
                            onLogEvent(new OnLogEventArgs("ERR:" + "成品编码" + 物料编码 + "托盘品种与MI不匹配"));
                        }
                    }
                    else
                    {
                        if (onLogEvent != null)
                        {
                            onLogEvent(new OnLogEventArgs("ERR:" + "无法解析NG指令：" + retLogIn));
                        }
                    }
                }
                else
                {
                    StartCheck1 = false;
                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("ERR:" + "无法解析指令：" + retLogIn));
                    }
                }
            }
            catch (Exception exp)
            {
                StartCheck1 = false;
                if (onLogEvent != null)
                {
                    onLogEvent(new OnLogEventArgs("ERR:" + exp.Message));
                }
            }
        }

        private void menuButton3_SelectedChanged(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("请扫码获取电解液信息！");
                menuButton3.Selected = false;
                return;
            }

            if (textBox3 != null)
            {
                电解液号 = textBox3.Text;
            }
            Task task = new Task(new Action(() =>
            {
                开机验证.dianjieyeCheck();
            }), TaskCreationOptions.LongRunning);
            task.Start();
            Task task1 = Task.WhenAll(task);
            task1.ContinueWith(tt =>
            {
                this.Invoke(new Action(() =>
                {
                    menuButton3.Selected = false;
                    if (StartCheck2)
                    {
                        label4.Text = "OK";
                        label4.BackColor = Color.LimeGreen;
                        groupBox2.Enabled = false;
                        if (开机验证.StartCheck1 && 开机验证.StartCheck2)
                        {
                            button1.Enabled = true;
                        }
                    }
                    else
                    {
                        label4.Text = "NG";
                        label4.BackColor = Color.IndianRed;
                    }
                }));
            });
        }

        public static void dianjieyeCheck()
        {
            string retLogIn = "";
            try
            {
                retLogIn = Program.FormATLscan2.SendBackMessageInstant(物料编码 + "," + 电解液号,40000);
                if (retLogIn.Contains("OK") && 电解液号.Contains(设置界面.电解液前几位))
                {
                    StartCheck2 = true;
                    电解液号验证时间 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //OnDianJieYeCheckSuccess(true, EventArgs.Empty);
                     string wuliaobianma_dianjieyehao = 物料编码 + "," + 电解液号;
                     DataAction.Save.SaveBinF("wuliaobianmadianjieyehao", wuliaobianma_dianjieyehao);
                     Task TT = new Task(new Action(() =>
                         {
                             Time3RestartSignal = true;
                             Thread.Sleep(2000);
                             Time3RestartSignal = false;
                         }));
                    TT.Start();
                    //Program.FormMain1.timeCount3.ReStart();
                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("LOG:" + "物料编码：" + 物料编码 + "和电解液型号：" + 电解液号 + "验证成功！"));
                    }
                }
                else if (retLogIn.Contains("NG"))
                {
                    StartCheck2 = false;
                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("ERR:" + "电解液型号" + 电解液号 + "验证不成功！"));
                    }
                }
                else if (!电解液号.Contains(设置界面.电解液前几位))
                {
                    StartCheck2 = false;
                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("ERR:" + "电解液前几位不匹配：" + retLogIn));
                    }
                }
                else
                {
                    StartCheck2 = false;
                    if (onLogEvent != null)
                    {
                        onLogEvent(new OnLogEventArgs("ERR:" + "无法解析指令：" + retLogIn));
                    }
                }
            }
            catch (Exception exp)
            {
                StartCheck2 = false;
                if (onLogEvent != null)
                {
                    onLogEvent(new OnLogEventArgs("ERR:" + exp.Message));
                }
            }
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

            //saveVarible savevarible1 = new saveVarible();
            //SAVE.ReadVar("wuliaobianma", ref savevarible1);
            //comboBox1.Items.AddRange(savevarible1.wuliaobianma);
            textBox2.Text = 设置界面.机台号;
            textBox1.Text = 物料编码;
            textBox3.Text = 电解液号;

        }

        private void 开机验证_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveVarible saveVariblewuliaobianma = new saveVarible();
            SAVE.SaveVar("wuliaobianma", saveVariblewuliaobianma);
        }

        private void menuButton1_SelectedChanged(object sender, EventArgs e)
        {
            string Ret = "";
            DialogResult ret = MessageBox.Show("获取或更新电解液号需要先验证当前成品编码，请确认？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0);
            if (ret == DialogResult.OK)
            {
                开机验证.电解液号 = "000000000000000000";
                string wuliaobianma_dianjieyehaoNULL = 开机验证.物料编码 + "," + "000000000000000000";
                textBox3.Text = "000000000000000000";
                DataAction.Save.SaveBinF("wuliaobianmadianjieyehao", wuliaobianma_dianjieyehaoNULL);

                Program.FormDianjieye = new 电解液更换中();
                Program.FormDianjieye.Show();
                onLogEvent(new OnLogEventArgs("LOG:获取电解液中..."));
                try
                {
                    Program.FormATLscan3.SendMessage("ESN");
                    Thread.Sleep(1000);
                    Ret = Program.FormATLscan3.SendBackMessageLong("ESN");


                    if (开机验证.物料编码 != Ret.Split(',')[2])
                    {
                        onLogEvent(new OnLogEventArgs("WARNING:成品编码信息不一致！新成品编码为" + Ret.Split(',')[2] + "," + "旧成品编码为" + 开机验证.物料编码));
                        OmroPLCvar.WriteSingleVarible(PLC扫描.PLC扫电芯码数据内存名称[1], 8);
                        //MessageBox.Show("WARNING:成品编码信息不一致！新成品编码为" + Ret.Split(',')[2] + "," + "旧成品编码为" + 开机验证.物料编码);
                        Program.FormDianjieye.Close();
                        menuButton1.Selected = false;
                        return;
                    }
                    开机验证.电解液号 = Ret.Split(',')[3];
                    textBox3.Text = 电解液号;
                    onLogEvent(new OnLogEventArgs("LOG:物料编码:" + 开机验证.物料编码 + "电解液号:" + 开机验证.电解液号 + "更换成功！"));
                }
                catch
                {
                    if (Ret == "")
                    {
                        onLogEvent(new OnLogEventArgs("WARNING:未获取到电解液信息，更换电解液超时！"));
                    }
                    else
                    {
                        onLogEvent(new OnLogEventArgs("WARNING:电解液信息不合法！"));
                    }
                }
                Program.FormDianjieye.Close();
            }
            menuButton1.Selected = false;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                FormMain.dianchi_max = double.Parse(DataAction.Save.ReadIni("F:\\注液规格配置\\注液规格配置.ini", 物料编码, "电池最大"));
                FormMain.dianchi_min = double.Parse(DataAction.Save.ReadIni("F:\\注液规格配置\\注液规格配置.ini", 物料编码, "电池最小"));
                FormMain.zhuye_max = double.Parse(DataAction.Save.ReadIni("F:\\注液规格配置\\注液规格配置.ini", 物料编码, "注液最大"));
                FormMain.zhuye_min = double.Parse(DataAction.Save.ReadIni("F:\\注液规格配置\\注液规格配置.ini", 物料编码, "注液最小"));
                FormMain.tiaomaqianjiwei = DataAction.Save.ReadIni("F:\\注液规格配置\\注液规格配置.ini", 物料编码, "条码前几位");


                this.Close();
                Program.FormExcuteCmd.vrStatemode = StateMode.ReadyToAuto;
            }
            catch
            {
                MessageBox.Show("该物料编码的电芯配置不存在，请先配置电芯文件，再点击下一步！");
            }
            
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
