using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAction
{
    /// <summary>
    /// 这是关于Excel文件操作的类
    /// 这里Excel引用了EEplus类库,所以需要添加EEplus的引用
    /// </summary>
    class Excel_Helper
    {
        //        先申明
        //        ExcelPackage ep = new ExcelPackage();
        //        ExcelWorkbook wb = ep.Workbook;
        //        ExcelWorksheet ws = wb.Worksheets.Add("result");


        //1、设置单元格的格式--将第一列设置为 时间格式 显示   
        //可通过修改列号，具体修改某一列的属性

        //                for (int i = 1; i<saveDs.Tables[0].Rows.Count + 1; i++)
        //                {
        //                    ws.Cells[i + 1, 5].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";//这是保留两位小数

        //                    ws.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;//数据居中显示

        //                }

        //2、//内容自适应表格的宽度 （列宽是固定的）   

        //                ws.Cells.Style.ShrinkToFit = true;


        //3、设置整个变得字体的颜色

        //                ws.Cells.Style.Font.Color.SetColor(Color.Pink);

        //4、冻结列名
        //                ws.View.FreezePanes(2, 1);

        //5、设定指定行列单元格的颜色   

        //                using (var range = ws.Cells[1, 1, 1, 51])
        //                {
        //                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                    range.Style.Fill.BackgroundColor.SetColor(Color.Pink);

        //                }

        // 6、输出Excel 单元格宽度自适应

        //                ws.Cells[ws.Dimension.Address].AutoFitColumns();

        //需要注意的是，需要在填充工作表后调用此方法，因为如果工作表中没有数据，ws.Dimension属性将返回null。会不起作用的。



        ///*****************************实例--数据导出*****************************///
        /// **********************************************************************///




        /// <summary>
        /// 将指定数据集中的数据导出到指定Excel表中
        /// </summary>
        /// <param name="filePath">将要导出的文件路径。
        /// 导出的Excel将会在该路径下，以时间的命名方式展现</param>
        /// <param name="data">要导出的数据集</param>
        public void btnReport(string filePath, DataSet data)
        {
            if (!Directory.Exists(filePath))//判断文件夹是否存在
            {
                //不存在，创建文件夹
                Directory.CreateDirectory(filePath);
            }

            ExcelPackage ep = new ExcelPackage();
            ExcelWorkbook wb = ep.Workbook;
            ExcelWorksheet ws = wb.Worksheets.Add("result");
            //格式化设置单元格的值类型

            //设置单元格的格式--将第一列设置为 时间格式 显示   
            for (int i = 1; i < data.Tables[0].Rows.Count + 1; i++)
            {
                ws.Cells[i + 1, 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";//这是保留两位小数
                //ws.Cells[i+1,i+1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;//数据居中显示
            }
            

            ws.Cells["A1"].LoadFromDataTable(data.Tables[0], true);
            Type t = data.Tables[0].Columns[0].DataType;
            string path = filePath + "//" + DateTime.Now.ToString("yyyy - MM - dd HH-mm-ss") + ".xlsx";
            ep.SaveAs(new FileInfo(path));
        }



    }
}
