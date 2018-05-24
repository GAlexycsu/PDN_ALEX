using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
/// <summary>
/// Summary description for BLL_File
/// </summary>
public class BLL_File
{
	public BLL_File()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable DocFileExcel(string excelFile, string SheetName)
    {
        try
        {            
            string srcConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES;""";
            string srcQuery = "Select * from [" + SheetName + "$]";
            OleDbConnection srcConn = new OleDbConnection(srcConnString);
            srcConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand(srcQuery, srcConn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
            da.Fill(ds, SheetName);
            srcConn.Close();
            return ds.Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable DocFileExcel(string excelFile, int sheetindex)
    {
        try
        {
            string sheetname = GetExcelSheetNames(excelFile)[sheetindex];
            string srcConnString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES;""";
            string srcQuery = "Select * from [" + sheetname + "]";
            OleDbConnection srcConn = new OleDbConnection(srcConnString);
            srcConn.Open();
            OleDbCommand objCmdSelect = new OleDbCommand(srcQuery, srcConn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
            da.Fill(ds, sheetname);
            srcConn.Close();
            return ds.Tables[0];
        }
        catch (Exception)
        {

            throw;
        }
    }
    static String[] GetExcelSheetNames(string excelFile)
    {
        OleDbConnection objConn = null;
        System.Data.DataTable dt = null;
        try
        {
            // Connection String. Change the excel file to the file you  
            // will search.  
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
            // Create connection object by using the preceding connection string. objConn = new OleDbConnection(connString);  
            // Mở kết nối đến CSDL  
            objConn = new OleDbConnection(connString);
            objConn.Open();
            // Lấy về dữ liệu   
            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                return null;
            }
            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;
            // Add the sheet name to the string array.  
            foreach (DataRow row in dt.Rows)
            {
                excelSheets[i] = (row["TABLE_NAME"].ToString());
                i++;
            }
            return excelSheets;
        }
        catch
        {
            return null;
        }
        finally
        {
            // Clean up.  
            if (objConn != null)
            {
                objConn.Close();
                objConn.Dispose();
            }
            if (dt != null)
            {
                dt.Dispose();
            }
        }
    }
    public void ExportToExcel(string pFileName, string pData)
    {
        try
        {
            StreamWriter Writer = new StreamWriter(pFileName, false, System.Text.Encoding.UTF8);
            Writer.Write(pData);
            Writer.Close();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void ExCell()
    {
        try
        {
            
        }
        catch (Exception)
        {
            throw;
        }
    }
    public List<string> ReadFile(string pPath)
    {
        try
        {
            List<string> lstStr = new List<string>();
            StreamReader rd = new StreamReader(pPath);
            while (rd.Peek() != -1)
            {
                lstStr.Add(rd.ReadLine());
            }
            rd.Close();
            return lstStr;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public string ReadTextFile(string pPath)
    {
        try
        {
            try
            {             
                StreamReader rd = new StreamReader(pPath);
                return rd.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool WriteToFile(string pPath, string pText)
    {
        try
        {
            FileStream fStr = new FileStream(pPath, FileMode.Append, FileAccess.Write);
            TextWriter wrt = new StreamWriter(fStr);
            wrt.WriteLine(pText);
            wrt.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool WriteXml(string pPath, DataSet pDs)
    {
        try
        {
            FileStream fStr = new FileStream(pPath, FileMode.Append, FileAccess.Write);
            TextWriter wrt = new StreamWriter(fStr);
            pDs.WriteXml(wrt);
            wrt.Close();
            return true;
        }
        catch
        {
            throw;
        }
    }
    public DataSet ReadXml(string pPath)
    {
        try
        {
            FileStream fStr = new FileStream(pPath, FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fStr);
            DataSet ds = new DataSet();
            ds.ReadXml(rd);
            rd.Close();
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void WriteErrorCommandLog(string pText)
    {
        try
        {            
            WriteErrorLogs(pText, "CommandErrors");
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void WriteSystemErrorLog(string pText)
    {
        try
        {            
            WriteErrorLogs(pText, "SystemErrors");
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void WriteErrorLogs(string pText, string pFolder)
    {
        try
        {            
            string strLog = "";
            strLog += "=================== " + DateTime.Now.ToString() + " =================== \n";
            strLog += pText;
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ErrorLogs\" + pFolder + @"\E_" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
            WriteToFile(strPath, strLog);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void WriteExecLogs(string pFileName, DataSet pDs, string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ExecLogs\" + pFolder + @"\" + pFileName + ".xml";
            WriteXml(strPath, pDs);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataTable ReadExecLogs(string pFileName, string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ExecLogs\" + pFolder + @"\" + pFileName;
            return ReadXml(strPath).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public List<string> ReadErrorLogs(string pFileName, string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ErrorLogs\" + pFolder + @"\" + pFileName;
            return ReadFile(strPath);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public string[] Getfile(string pPath)
    {
        try
        {
            return Directory.GetFiles(pPath);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public string[] GetListErrorLogs(string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ErrorLogs\" + pFolder;
            return Getfile(strPath);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public string[] GetListExecLogs(string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\ExecLogs\" + pFolder;
            return Getfile(strPath);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public string[] GetListFolder(string pFolder)
    {
        try
        {
            string strPath = ConfigurationManager.AppSettings["LogsPath"];
            strPath += @"\" + pFolder;
            return Directory.GetDirectories(strPath);
        }
        catch (Exception)
        {
            throw;
        }
    }
}