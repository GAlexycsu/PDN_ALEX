using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

using System.Reflection;
using OfficeOpenXml;

/// <summary>
/// Summary description for ABC
/// </summary>
public class ABC : DAL_ERP_GenericDataAccess
{
	public ABC()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  DataSet ImportExceltoDataset(string FilePath,string SheetName)
    {

       Excel.Application oXL;
        Excel.Workbook oWB;
        Excel.Worksheet oSheet;

        Excel.Range oRng;
        //  creat a Application object
        oXL = new Microsoft.Office.Interop.Excel.Application();
        try
        {
            //   get   WorkBook  object
            oWB = oXL.Workbooks.Open(FilePath);

            //   get   WorkSheet object 
            int M = oXL.Worksheets.Count;

            //for (int sheetnum = 1; sheetnum <= M; sheetnum++)
            //{
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[SheetName];

                for (int j = oSheet.UsedRange.Cells.Columns.Count + 10; j > 0; j--)
                {
                    if (j > oSheet.UsedRange.Cells.Columns.Count)
                    {
                        if (string.IsNullOrEmpty(((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j]).Text.ToString()))
                        {
                            ((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j]).EntireColumn.Delete(null);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j]).Text.ToString()))
                        {
                            int IsDeleteCunt = 1;
                            for (int i = 1; i < oSheet.UsedRange.Cells.Rows.Count; i++)
                            {
                                if (string.IsNullOrEmpty(((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j]).Text.ToString()))
                                {
                                    IsDeleteCunt++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (IsDeleteCunt == oSheet.UsedRange.Cells.Rows.Count)// Here you can get the used rows.
                            {
                                ((Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j]).EntireColumn.Delete(null);
                            }
                        }
                    }
                }
           // }

            DataSet ds = new DataSet();
            string WrkshtName = "";
            for (int N = 1; N <= M; N++)
            {
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[N];
                WrkshtName = oSheet.Name;
                System.Data.DataTable dt = new System.Data.DataTable(WrkshtName);
                ds.Tables.Add(dt);
                DataRow dr;

                StringBuilder sb = new StringBuilder();

                int jValue = oSheet.UsedRange.Cells.Columns.Count;
                int iValue = oSheet.UsedRange.Cells.Rows.Count;
                int EmptyColumnCount = 1;
                for (int j = 1; j <= jValue; j++)
                {
                    oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[1, j];

                    string strValue = oRng.Text.ToString();
                    if (strValue.Trim() == "")
                    {
                        EmptyColumnCount++;
                    }

                    dt.Columns.Add(strValue, System.Type.GetType("System.String"));
                }
                if (EmptyColumnCount >= jValue)
                {
                    ds.Tables.Remove(WrkshtName);
                }
                else
                {
                    for (int i = 2; i <= iValue; i++)
                    {
                        dr = ds.Tables[WrkshtName].NewRow();
                        int k = 0;
                        EmptyColumnCount = 1;
                        for (int j = 1; j <= jValue; j++)
                        {
                            oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                            ((Excel.Range)oSheet.Cells[1, j]).EntireColumn.AutoFit();

                            string strValue = oRng.Text.ToString();
                            if (strValue.Trim() == "")
                            {
                                EmptyColumnCount++;
                            }
                            dr[k] = strValue;
                            k++;
                        }
                        if (EmptyColumnCount < jValue)
                        {
                            ds.Tables[WrkshtName].Rows.Add(dr);
                        }
                    }
                }
            }
            return ds;
        }
        catch (Exception )
        {
            return null;
        }
    }
    public DataSet GetExcel(string fileName)
    {
       Excel. Application oXL;
       Excel.Workbook oWB;
       Excel. Worksheet oSheet;
       Excel . Range oRng;
        try
        {
            //  creat a Application object
            oXL = new Excel.Application();
            //   get   WorkBook  object
            oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);

            //   get   WorkSheet object
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[1];
            System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            DataRow dr;

            StringBuilder sb = new StringBuilder();
            int jValue = oSheet.UsedRange.Cells.Columns.Count;
            int iValue = oSheet.UsedRange.Cells.Rows.Count;
            //  get data columns
            for (int j = 1; j <= jValue; j++)
            {
                dt.Columns.Add("column" + j, System.Type.GetType("System.String"));
            }

            //  get data in cell
            for (int i = 1; i <= iValue; i++)
            {
                dr = ds.Tables["dtExcel"].NewRow();
                for (int j = 1; j <= jValue; j++)
                {
                    oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                    string strValue = oRng.Text.ToString();
                    dr["column" + j] = strValue;
                }
                ds.Tables["dtExcel"].Rows.Add(dr);
            }
            return ds;
        }
        catch (Exception )
        {
            return null;
        }
        
    }
}