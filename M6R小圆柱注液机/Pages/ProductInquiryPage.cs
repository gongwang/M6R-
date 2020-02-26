using M6R小圆柱注液机.Data;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

namespace M6R小圆柱注液机.Pages
{
    public partial class ProductInquiryPage : Form
    {
        public ProductInquiryPage()
        {
            InitializeComponent();
        }

        private MySQL_Helper mysql_Helper = new MySQL_Helper();
        private DataSet saveDs = new DataSet();

        private string _searchColName;
        private int _pageSize = 100;
        private int currentPage;
        private string sql;


        private void ProductInquiry_Load(object sender, EventArgs e)
        {
            cmbSearchWays.Items.Add("时间查询");
            cmbSearchWays.Items.Add("二维码查询");
            cmbSearchWays.SelectedIndex = 0;//默认时间查询
            tbCode.Text = string.Empty;//清空二维码
            this.Show();
            tbCode.Focus();
            this.tabControl1.Region = new Region(new RectangleF(this.tabPage1.Left, this.tabPage1.Top, this.tabPage1.Width, this.tabPage1.Height));
            string connStr = GlobalValues.PathVariable.DataBasePath;
            mysql_Helper.SqlConn(connStr);
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            saveDs.Clear();//每次查询，都会想saveDs数据集里写数据，会导致数据重复，所以需要在此处清空一次

            if (cmbSearchWays.Text == "时间查询")
            {
                string startTime = dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string endTime = dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
                sql = string.Format("SELECT * FROM `tbresult_data` WHERE `记录时间` BETWEEN '{0}'AND '{1}'", startTime, endTime);
                _searchColName = "记录时间";
            }
            else
            {
                //二维码查询
                if (tbCode.Text == string.Empty)
                {
                    MessageBox.Show("输入的条码不能为空！！", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GlobalValues.log_Helper.DispProcess("输入的条码不能为空", "Alarm");
                }
                else
                {
                    sql = string.Format("SELECT * FROM `tbresult_data` WHERE `Tab 号`LIKE'%{0}%'", tbCode.Text);
                    _searchColName = "Tab 号";
                }
            }

            //pagingDA = mySqlHelperBz.GetDataAdapter(sql);

            //if (pagingDA != null)
            //{
            //    //pagingDA.Fill(pagingDS, "tbproductdata");
            //    pagingDA.Fill(saveDs, "tbproductdata2");
            //    dgvProduct.DataSource = saveDs.Tables[0];
            //}


            saveDs = mysql_Helper.GetDataByPagination(sql, _pageSize);
            if (saveDs.Tables.Count > 1)
            {
                dgvProduct.DataSource = saveDs.Tables[1];
                dgvProduct.Columns[_searchColName].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                currentPage = 1;
                lbPage.Text = string.Format("第{0}页/共{1}页", currentPage, saveDs.Tables.Count - 1);
            }
            tbTotalNum.Text = "                                                            共  " + saveDs.Tables[0].Rows.Count.ToString() + "  条数据";
        }





        /// <summary>
        /// 查询方式改变时，切换对应的弹窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSearchWays_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchWays.Text == "时间查询") { tabControl1.SelectedIndex = 0; }
            else
            {
                tabControl1.SelectedIndex = 1;
                tbCode.Text = string.Empty;//清空二维码
                tbCode.Focus();
                //下面这行代码是临时用的，用于通过扫码机将条码输入的窗口控件里
                //GlobalVals.bzHoneywell1902.eventProcessBarcode += bzHoneywell1902_eventProcessBarcode;
            }
        }


        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            lbPage.Text = string.Format("第{0}页/共{1}页", currentPage, saveDs.Tables.Count - 1);
            dgvProduct.DataSource = saveDs.Tables[currentPage];
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpPage_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            {
                MessageBox.Show("已是第一页！");
                return;
            }
            currentPage--;
            lbPage.Text = string.Format("第{0}页/共{1}页", currentPage, saveDs.Tables.Count - 1);
            dgvProduct.DataSource = saveDs.Tables[currentPage];
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage == saveDs.Tables.Count - 1)
            {
                MessageBox.Show("已是最后一页！");
                return;
            }
            currentPage++;
            lbPage.Text = string.Format("第{0}页/共{1}页", currentPage, saveDs.Tables.Count - 1);
            dgvProduct.DataSource = saveDs.Tables[currentPage];
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndPage_Click(object sender, EventArgs e)
        {
            currentPage = saveDs.Tables.Count - 1;
            lbPage.Text = string.Format("第{0}页/共{1}页", currentPage, saveDs.Tables.Count - 1);
            dgvProduct.DataSource = saveDs.Tables[currentPage];
        }




        /// <summary>
        /// 从PLC中获取二维码(产品的二维码)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFromPLC_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;//清空二维码
            tbCode.Focus();
            //tbCode.Text = GlobalVals.omronPlcNj.NjReadString("D4404");
        }

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("E://Data"))//判断文件夹是否存在
            {
                //不存在，创建文件夹
                Directory.CreateDirectory("E://Data");
            }

            Task tt = new Task(ReportDoWoek);
            tt.Start();
        }



        public void ReportDoWoek()
        {
            try
            {
                ExcelPackage ep = new ExcelPackage();
                ExcelWorkbook wb = ep.Workbook;
                ExcelWorksheet ws = wb.Worksheets.Add("result");
                ws.Cells["A1"].LoadFromDataTable(saveDs.Tables[0], true);//数据加载表中
                #region 设置单元格

                ws.Cells[1, 1, saveDs.Tables[0].Rows.Count + 1, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";//这是保留两位小数
                ws.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;//数据居中显示

                //ws.Cells.Style.ShrinkToFit = true;//内容自适应表格的宽度
                //ws.Cells.Style.Font.Color.SetColor(Color.Pink);//设置整个变得字体的颜色
                ws.View.FreezePanes(2, 1);//冻结列名

                //设定指定行列单元格的颜色//会增加耗时
                //using (var range = ws.Cells[1, 1, 1, 51])
                //{
                //    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                //    range.Style.Fill.BackgroundColor.SetColor(Color.Pink);
                //}

                //输出Excel 单元格宽度自适应
                //需要注意的是，需要在填充工作表后调用此方法，因为如果工作表中没有数据，ws.Dimension属性将返回null。会不起作用的
                ws.Cells[1, 1, 100, 37].AutoFitColumns();//数据量大的时候，会比较耗时。所以，这里选择100行进行处理
                #endregion
                Type t = saveDs.Tables[0].Columns[0].DataType;
                string path = "E://Data//" + DateTime.Now.ToString("yyyy - MM - dd HH-mm-ss") + ".xlsx";
                ep.SaveAs(new FileInfo(path));

                MessageBox.Show("生产数据导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GlobalValues.log_Helper.DispProcess("数据导出成功", "Info");
                //打开数据文件夹
                string path2 = @"E:\Data";
                System.Diagnostics.Process.Start(path2, "ExpLore");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GlobalValues.log_Helper.DispProcess("数据导出失败，请排查错误", "Alarm");
            }
            finally
            {

            }
        }





        //
        //
        //这段程序是是配合扫码枪的，后续可以删掉
        //void bzHoneywell1902_eventProcessBarcode(string barcodeData)
        //{
        //    //将currentBarcode传出去，在定时器里实时显示，单个显示时这样操作，多个数据时可以使用List变量存，在timer里remove显示
        //    this.Invoke(new EventHandler(delegate { tbCode.Text = barcodeData; }));
        //    //将获取的胶水批次号与MFG通讯
        //    GlobalVals.bzMFG.SendMsg(barcodeData, false);
        //}



    }
}
