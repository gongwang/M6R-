namespace M6R小圆柱注液机
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtProcessDisp = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnProductData = new System.Windows.Forms.Button();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelForm = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProcessDisp
            // 
            this.txtProcessDisp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcessDisp.Location = new System.Drawing.Point(1019, 596);
            this.txtProcessDisp.Name = "txtProcessDisp";
            this.txtProcessDisp.ReadOnly = true;
            this.txtProcessDisp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtProcessDisp.Size = new System.Drawing.Size(329, 127);
            this.txtProcessDisp.TabIndex = 5;
            this.txtProcessDisp.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 88);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(509, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(659, 86);
            this.panel4.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(170, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "M6R小圆柱注液机";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1168, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 86);
            this.panel3.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStart.Location = new System.Drawing.Point(34, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(63, 69);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "启动";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(115, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 69);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSetting);
            this.panel2.Controls.Add(this.btnChart);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.btnProductData);
            this.panel2.Controls.Add(this.btnAlarm);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 86);
            this.panel2.TabIndex = 3;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetting.Location = new System.Drawing.Point(86, 6);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(63, 69);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "设置";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnChart.FlatAppearance.BorderSize = 0;
            this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart.Image = ((System.Drawing.Image)(resources.GetObject("btnChart.Image")));
            this.btnChart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChart.Location = new System.Drawing.Point(414, 6);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(63, 69);
            this.btnChart.TabIndex = 1;
            this.btnChart.Text = "图表";
            this.btnChart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHome.Location = new System.Drawing.Point(5, 6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(63, 69);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "主页";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnProductData
            // 
            this.btnProductData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnProductData.FlatAppearance.BorderSize = 0;
            this.btnProductData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductData.Image = ((System.Drawing.Image)(resources.GetObject("btnProductData.Image")));
            this.btnProductData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProductData.Location = new System.Drawing.Point(171, 6);
            this.btnProductData.Name = "btnProductData";
            this.btnProductData.Size = new System.Drawing.Size(63, 69);
            this.btnProductData.TabIndex = 1;
            this.btnProductData.Text = "生产数据";
            this.btnProductData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductData.UseVisualStyleBackColor = false;
            this.btnProductData.Click += new System.EventHandler(this.btnProductData_Click);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAlarm.FlatAppearance.BorderSize = 0;
            this.btnAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlarm.Image = ((System.Drawing.Image)(resources.GetObject("btnAlarm.Image")));
            this.btnAlarm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlarm.Location = new System.Drawing.Point(252, 6);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(63, 69);
            this.btnAlarm.TabIndex = 1;
            this.btnAlarm.Text = "报警数据";
            this.btnAlarm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogin.Location = new System.Drawing.Point(333, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(63, 69);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "账号";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelForm
            // 
            this.panelForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelForm.Location = new System.Drawing.Point(0, 88);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(812, 661);
            this.panelForm.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.txtProcessDisp);
            this.Controls.Add(this.panelForm);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "M6R小圆柱注液机";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtProcessDisp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnProductData;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelForm;
    }
}

