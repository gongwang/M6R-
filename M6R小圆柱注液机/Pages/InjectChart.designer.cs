namespace VisionFram3
{
    partial class 图表界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(图表界面));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.导入上次数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.userChart1 = new FastCtr.UserChart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(389, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 63);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.vScrollBar1);
            this.panel2.Location = new System.Drawing.Point(2, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(48, 175);
            this.panel2.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 112);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 38);
            this.button4.TabIndex = 2;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 38);
            this.button3.TabIndex = 1;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(14, 43);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入上次数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 导入上次数据ToolStripMenuItem
            // 
            this.导入上次数据ToolStripMenuItem.Name = "导入上次数据ToolStripMenuItem";
            this.导入上次数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导入上次数据ToolStripMenuItem.Text = "导入上次数据";
            this.导入上次数据ToolStripMenuItem.Click += new System.EventHandler(this.导入上次数据ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // userChart1
            // 
            this.userChart1.C_color1 = System.Drawing.Color.Black;
            this.userChart1.C_color2 = System.Drawing.Color.Black;
            this.userChart1.C_color3 = System.Drawing.Color.Black;
            this.userChart1.C_color4 = System.Drawing.Color.Black;
            this.userChart1.C_color5 = System.Drawing.Color.Black;
            this.userChart1.C_color6 = System.Drawing.Color.Black;
            this.userChart1.C_color7 = System.Drawing.Color.Black;
            this.userChart1.C_color8 = System.Drawing.Color.Black;
            this.userChart1.C_colorHigh = System.Drawing.Color.Red;
            this.userChart1.C_colorLow = System.Drawing.Color.Red;
            this.userChart1.C_colorMid = System.Drawing.Color.Lime;
            this.userChart1.ChartCount = 500;
            this.userChart1.DownLineShow = true;
            this.userChart1.DownValue = 0.2F;
            this.userChart1.IntervalX = 2;
            this.userChart1.IntervalY = 0.1D;
            this.userChart1.IsSecondaryY = false;
            this.userChart1.ItemVisible = new bool[] {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true};
            this.userChart1.LabelYcount = 10;
            this.userChart1.LimitCount = 1F;
            this.userChart1.LineName = new string[] {
        "line0",
        "line1",
        "line2",
        "line3",
        "line4",
        "line5",
        "line6",
        "line7",
        "下限线条",
        "上限线条",
        "中间线条"};
            this.userChart1.ListDataBinTOTxt = new string[] {
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        ""};
            this.userChart1.ListX = new System.Collections.Generic.List<float>[] {
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX1"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX2"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX3"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX4"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX5"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX6"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListX7")))};
            this.userChart1.ListY = new System.Collections.Generic.List<float>[] {
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY1"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY2"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY3"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY4"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY5"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY6"))),
        ((System.Collections.Generic.List<float>)(resources.GetObject("userChart1.ListY7")))};
            this.userChart1.Location = new System.Drawing.Point(74, 23);
            this.userChart1.MaxY = 1D;
            this.userChart1.MidLineShow = true;
            this.userChart1.MinY = 0D;
            this.userChart1.Name = "userChart1";
            this.userChart1.ShowCount = 50;
            this.userChart1.Size = new System.Drawing.Size(950, 301);
            this.userChart1.StartX = 0F;
            this.userChart1.TabIndex = 6;
            this.userChart1.UpLineShow = true;
            this.userChart1.UpValue = 0.8F;
            // 
            // 图表界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1070, 436);
            this.Controls.Add(this.userChart1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "图表界面";
            this.Text = "图表界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.图表界面_FormClosing);
            this.Load += new System.EventHandler(this.图表界面_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入上次数据ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private FastCtr.UserChart userChart1;
    }
}