using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiChuanZhangYiYuan_SCADA
{
    /*************说明文档************
    //文件检测与处理类：NiceFileProduce
    //读写电子表格类：NiceExcelSaveAndRead
    
    *********************************/


    /*************文件处理类*************/
    public class NiceFileProduce
    {
        //分解路径用枚举
        public enum DecomposePathEnum
        {
            PathOnly = 0,//仅返回路径
            NameAndExtension = 1,//返回文件名+扩展名
            NameOnly = 2,//仅返回文件名
            ExtensionOnly = 3,//仅返回扩展名(带.)

        }

        //------------【函数：将文件路径分解】------------  

        //filePath文件路径
        //DecomposePathEnum返回类型
        //------------------------------------------------
        public static string DecomposePathAndName(string filePath, DecomposePathEnum decomposePathEnum)
        {
            string result = "";
            switch (decomposePathEnum)
            {
                case DecomposePathEnum.PathOnly://仅返回路径
                    result = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    break;
                case DecomposePathEnum.NameAndExtension://返回文件名+扩展名
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    break;
                case DecomposePathEnum.NameOnly://仅返回文件名
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);
                    break;
                case DecomposePathEnum.ExtensionOnly://仅返回扩展名(带.)
                    result = filePath.Substring(filePath.LastIndexOf("."));
                    break;
                default://
                    result = "";
                    break;
            }
            return result;
        }


        //------------【函数：判断文件路径是否存在，不存在则创建】------------  

        //filePath文件夹路径
        //DecomposePathEnum返回类型
        //---------------------------------------------------------------------
        public static string CheckAndCreatPath(string path)
        {
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                if (path.LastIndexOf("\\") <= 0)
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        return path;
                    }
                    catch
                    {
                        return "error";
                    }
                }
                else
                {
                    if (CheckAndCreatPath(DecomposePathAndName(path, DecomposePathEnum.PathOnly)) == "error")
                    {
                        return "error";
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        return path;
                    }
                }
            }
        }
    }


    /*************使用NPOI读写电子表格类*************/
    public class NiceExcelSaveAndRead
    {
        

        //------------【函数：将表格控件保存至Excel文件(新建/替换)】------------    

        //filePath要保存的目标Excel文件路径名
        //datagGridView要保存至Excel的表格控件
        //------------------------------------------------------------------------
        public static bool SaveToExcelNew(string filePath,DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数、与当前Excel已有行数
            int rowCount = dataGridView.RowCount;//记录表格中的行数
            int colCount = dataGridView.ColumnCount;//记录表格中的列数

            //判断文件夹是否存在
            if (NiceFileProduce.CheckAndCreatPath(NiceFileProduce.DecomposePathAndName(filePath, NiceFileProduce.DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }
            
            //创建工作表
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet("Sheet1");
                IRow row = sheet.CreateRow(0);
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//更改单元格值                  
                    }
                }
            }
            catch
            {
                result = false;
                return result;
            }

            for (int i = 0; i < rowCount; i++)      //行循环
            {
                //防止行数超过Excel限制
                if (i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(1 + i);  //创建行
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//更改单元格值                  
                    }
                }
            }
            try
            {
                workbook.Write(fs);
            }
            catch
            {
                result = false;
                return result;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                workbook = null;
            }
            return result;
        }

        //------------【函数：将表格控件保存至Excel文件(添加/新建)】------------    
        //filePath要保存的目标Excel文件路径名
        //datagGridView要保存至Excel的表格控件
        //------------------------------------------------
        public static bool SaveToExcelAdd(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数、与当前Excel已有行数
            int rowCount = dataGridView.RowCount;//记录表格中的行数
            int colCount = dataGridView.ColumnCount;//记录表格中的列数
            int numCount = 0;//Excell最后一行序号

            //判断文件夹是否存在
            if (NiceFileProduce.CheckAndCreatPath(NiceFileProduce.DecomposePathAndName(filePath, NiceFileProduce.DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }
            //判断文件是否存在
            if (!File.Exists(filePath))
            {
                try
                {
                    fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet1");
                    IRow row = sheet.CreateRow(0);
                    for (int j = 0; j < colCount; j++)  //列循环
                    {
                        if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                        {
                            ICell cell = row.CreateCell(j);//创建列
                            cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//更改单元格值                  
                        }
                    }
                    workbook.Write(fs);
                }
                catch
                {
                    result = false;
                    return result;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                        fs = null;
                    }
                    workbook = null;
                }
            }
            //创建指向文件的工作表
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new HSSFWorkbook(fs);//.xls
                sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                {
                    result = false;
                    return result;
                }
                numCount = sheet.LastRowNum + 1;
            }
            catch
            {
                result = false;
                return result;
            }

            for (int i = 0; i < rowCount; i++)      //行循环
            {
                //防止行数超过Excel限制
                if (numCount + i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(numCount + i);  //创建行
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//更改单元格值                  
                    }
                }
            }
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook.Write(fs);
            }
            catch
            {
                result = false;
                return result;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                workbook = null;
            }
            return result;
        }


        //------------【函数：从Excel文件读取数据到表格控件】------------    
        //filePath为Excel文件路径名
        //datagGridView要显示数据的表格控件
        //------------------------------------------------
        public static bool ReadFromExcel(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数
            int rowCount = 0;//记录Excel中的行数
            int colCount = 0;//记录Excel中的列数

            //判断文件是否存在
            if (!File.Exists(filePath))
            {
                result = false;
                return result;
            }
            //创建指向文件的工作表
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                workbook = new HSSFWorkbook(fs);//.xls
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                {
                    result = false;
                    return result;
                }
                rowCount = sheet.LastRowNum;
                colCount = sheet.GetRow(0).LastCellNum;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    ICell cell = sheet.GetRow(0).GetCell(j);//获取列
                    dataGridView.Columns.Add(j.ToString()+ cell.ToString(), cell.ToString());
                }
                for (int i = 1; i < rowCount; i++)      //行循环
                {
                    IRow row = sheet.GetRow(i);  //获取行
                    int index = dataGridView.Rows.Add();
                    colCount = row.LastCellNum;
                    for (int j = 0; j < colCount; j++)  //列循环
                    {
                        ICell cell = row.GetCell(j);//获取列
                        dataGridView.Rows[index].Cells[j].Value = cell.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = false;
                return result;
            }    
            return result;
        }
   
    }
}
