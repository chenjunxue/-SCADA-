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
    /*************˵���ĵ�************
    //�ļ�����봦���ࣺNiceFileProduce
    //��д���ӱ���ࣺNiceExcelSaveAndRead
    
    *********************************/


    /*************�ļ�������*************/
    public class NiceFileProduce
    {
        //�ֽ�·����ö��
        public enum DecomposePathEnum
        {
            PathOnly = 0,//������·��
            NameAndExtension = 1,//�����ļ���+��չ��
            NameOnly = 2,//�������ļ���
            ExtensionOnly = 3,//��������չ��(��.)

        }

        //------------�����������ļ�·���ֽ⡿------------  

        //filePath�ļ�·��
        //DecomposePathEnum��������
        //------------------------------------------------
        public static string DecomposePathAndName(string filePath, DecomposePathEnum decomposePathEnum)
        {
            string result = "";
            switch (decomposePathEnum)
            {
                case DecomposePathEnum.PathOnly://������·��
                    result = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    break;
                case DecomposePathEnum.NameAndExtension://�����ļ���+��չ��
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    break;
                case DecomposePathEnum.NameOnly://�������ļ���
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);
                    break;
                case DecomposePathEnum.ExtensionOnly://��������չ��(��.)
                    result = filePath.Substring(filePath.LastIndexOf("."));
                    break;
                default://
                    result = "";
                    break;
            }
            return result;
        }


        //------------���������ж��ļ�·���Ƿ���ڣ��������򴴽���------------  

        //filePath�ļ���·��
        //DecomposePathEnum��������
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


    /*************ʹ��NPOI��д���ӱ����*************/
    public class NiceExcelSaveAndRead
    {
        

        //------------�������������ؼ�������Excel�ļ�(�½�/�滻)��------------    

        //filePathҪ�����Ŀ��Excel�ļ�·����
        //datagGridViewҪ������Excel�ı��ؼ�
        //------------------------------------------------------------------------
        public static bool SaveToExcelNew(string filePath,DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//����һ���µ��ļ���
            HSSFWorkbook workbook = null;//����һ���µ�Excel�ļ�
            ISheet sheet = null;//ΪExcel����һ�Ź�����

            //�����������������뵱ǰExcel��������
            int rowCount = dataGridView.RowCount;//��¼����е�����
            int colCount = dataGridView.ColumnCount;//��¼����е�����

            //�ж��ļ����Ƿ����
            if (NiceFileProduce.CheckAndCreatPath(NiceFileProduce.DecomposePathAndName(filePath, NiceFileProduce.DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }
            
            //����������
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet("Sheet1");
                IRow row = sheet.CreateRow(0);
                for (int j = 0; j < colCount; j++)  //��ѭ��
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//������
                        cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//���ĵ�Ԫ��ֵ                  
                    }
                }
            }
            catch
            {
                result = false;
                return result;
            }

            for (int i = 0; i < rowCount; i++)      //��ѭ��
            {
                //��ֹ��������Excel����
                if (i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(1 + i);  //������
                for (int j = 0; j < colCount; j++)  //��ѭ��
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//������
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//���ĵ�Ԫ��ֵ                  
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

        //------------�������������ؼ�������Excel�ļ�(���/�½�)��------------    
        //filePathҪ�����Ŀ��Excel�ļ�·����
        //datagGridViewҪ������Excel�ı��ؼ�
        //------------------------------------------------
        public static bool SaveToExcelAdd(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//����һ���µ��ļ���
            HSSFWorkbook workbook = null;//����һ���µ�Excel�ļ�
            ISheet sheet = null;//ΪExcel����һ�Ź�����

            //�����������������뵱ǰExcel��������
            int rowCount = dataGridView.RowCount;//��¼����е�����
            int colCount = dataGridView.ColumnCount;//��¼����е�����
            int numCount = 0;//Excell���һ�����

            //�ж��ļ����Ƿ����
            if (NiceFileProduce.CheckAndCreatPath(NiceFileProduce.DecomposePathAndName(filePath, NiceFileProduce.DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }
            //�ж��ļ��Ƿ����
            if (!File.Exists(filePath))
            {
                try
                {
                    fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet1");
                    IRow row = sheet.CreateRow(0);
                    for (int j = 0; j < colCount; j++)  //��ѭ��
                    {
                        if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                        {
                            ICell cell = row.CreateCell(j);//������
                            cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//���ĵ�Ԫ��ֵ                  
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
            //����ָ���ļ��Ĺ�����
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

            for (int i = 0; i < rowCount; i++)      //��ѭ��
            {
                //��ֹ��������Excel����
                if (numCount + i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(numCount + i);  //������
                for (int j = 0; j < colCount; j++)  //��ѭ��
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//������
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//���ĵ�Ԫ��ֵ                  
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


        //------------����������Excel�ļ���ȡ���ݵ����ؼ���------------    
        //filePathΪExcel�ļ�·����
        //datagGridViewҪ��ʾ���ݵı��ؼ�
        //------------------------------------------------
        public static bool ReadFromExcel(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//����һ���µ��ļ���
            HSSFWorkbook workbook = null;//����һ���µ�Excel�ļ�
            ISheet sheet = null;//ΪExcel����һ�Ź�����

            //��������������
            int rowCount = 0;//��¼Excel�е�����
            int colCount = 0;//��¼Excel�е�����

            //�ж��ļ��Ƿ����
            if (!File.Exists(filePath))
            {
                result = false;
                return result;
            }
            //����ָ���ļ��Ĺ�����
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
                for (int j = 0; j < colCount; j++)  //��ѭ��
                {
                    ICell cell = sheet.GetRow(0).GetCell(j);//��ȡ��
                    dataGridView.Columns.Add(j.ToString()+ cell.ToString(), cell.ToString());
                }
                for (int i = 1; i < rowCount; i++)      //��ѭ��
                {
                    IRow row = sheet.GetRow(i);  //��ȡ��
                    int index = dataGridView.Rows.Add();
                    colCount = row.LastCellNum;
                    for (int j = 0; j < colCount; j++)  //��ѭ��
                    {
                        ICell cell = row.GetCell(j);//��ȡ��
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
