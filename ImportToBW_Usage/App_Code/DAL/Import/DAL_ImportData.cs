using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.Configuration;

public class DAL_ImportData : DAL_ERPTW_GenericDataAccess
{
   
    
	public DAL_ImportData()
	{
	
	}
    string ok="";
    string hu = "";
    string k = "";
    string ih = "";
    string ul = "";
    Excel.Application oXL;
    Excel.Workbook oWB;
    Excel.Worksheet oSheet;
    Excel.Range oRng;
    public DataSet LayDanhSachData()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from xtbwyl2";
        return Select(cmd);
    }
    public int XoaDuLieu(string XieXing, string SheHao, string BWBH)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete xtbwyl1 where XieXing=@XieXing and SheHao=@SheHao and BWBH=@BWBH ";
            cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("BWBH", BWBH, SqlDbType.VarChar));
          
            return ExecuteNonQuery(cmd);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet DemSoLuongRecordInsert(string userid, DateTime UserDate)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select USERID from xtbwyl1 where USERDATE=@USERDATE and USERID=@USERID ";
            cmd.Parameters.Add(CreateParameter("USERID", userid, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.DateTime));
            return Select(cmd);
        }
        catch (Exception)
        {

            throw;
        }

    }
    public DataSet LayDanhSachDataByCondition(DateTime? fromDate, DateTime? toDate,string id,string UserID)
    {
        try
        {
             //SqlCommand cmd = new SqlCommand();
             //cmd.CommandText = "select * from xtbwyl2 where BWBH=ISNULL(@BWBH,BWBH) ";
             //cmd.CommandText +=" or xtbwyl2.USERDATE between @fromDate and @toDate";
             //cmd.Parameters.Add(CreateParameter("fromDate", fromDate, SqlDbType.DateTime));
             //cmd.Parameters.Add(CreateParameter("toDate", toDate, SqlDbType.DateTime));
             //cmd.Parameters.Add(CreateParameter("BWBH", id, SqlDbType.VarChar));
             //cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
             //return Select(cmd);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1 where USERID=@USERID or USERDATE between @fromDate and @toDate";
            cmd.CommandText += " order by XTCC asc";
            cmd.Parameters.Add(CreateParameter("fromDate", fromDate, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("toDate", toDate, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];

            string abc = "";
           
            foreach (DataRow drw in dt.Rows)
            {

                abc += ", MAX(case XTCC when '" + drw["XTCC"].ToString() + "' then CLSL else 0 end)'" + drw["XTCC"].ToString() + "'";
                
            }
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select XieXing as '鞋型',SheHao as '色號',BWBH as '部位編號/名稱'";
            cmd1.CommandText += abc;
            cmd1.CommandText += " from xtbwyl1  where BWBH=ISNULL(@BWBH,BWBH) or xtbwyl1.USERDATE between @fromDate and @toDate";
            cmd1.CommandText += " group by XieXing,SheHao,BWBH";
            cmd1.Parameters.Add(CreateParameter("fromDate", fromDate, SqlDbType.DateTime));
            cmd1.Parameters.Add(CreateParameter("toDate", toDate, SqlDbType.DateTime));
            cmd1.Parameters.Add(CreateParameter("BWBH", id, SqlDbType.VarChar));
            cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            return Select(cmd1);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet LayDanhSachTheoNgay(DateTime userdate,string UserID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1 where USERID=@USERID and USERDATE=@USERDATE";
            cmd.CommandText += " order by XTCC asc";
            cmd.Parameters.Add(CreateParameter("USERDATE", userdate, SqlDbType.DateTime));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
           // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];
            
             string abc ="";
            List<string> list = new List<string>();
            foreach (DataRow drw in dt.Rows)
            {

                abc += ", MAX(case XTCC when '" + drw["XTCC"].ToString() + "' then CLSL else 0 end)'" + drw["XTCC"].ToString() + "'";
                list.Add(abc);
            }
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select XieXing as '鞋型',SheHao as '色號',BWBH as '部位編號/名稱'";
            cmd1.CommandText += abc;
            cmd1.CommandText += " from xtbwyl1 where USERID=@USERID and USERDATE=@USERDATE";
            cmd1.CommandText += " group by XieXing,SheHao,BWBH";
            cmd1.Parameters.Add(CreateParameter("USERDATE", userdate, SqlDbType.DateTime));
            cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            return Select(cmd1);
            /////////
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from xtbwyl2 where USERID=@USERID and USERDATE=@USERDATE";
            //cmd.CommandText += "order by XieXing,SheHao,BWBH asc";
            //cmd.Parameters.Add(CreateParameter("USERDATE", userdate, SqlDbType.DateTime));
            //cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));

            //DataTable dt = Select(cmd).Tables[0];
            //int colIndex = 1;

        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataTable DocFileExcel(string excelFile, string SheetName, string Extension)
    {
        #region abc
        //try
        //{

        //    string srcConnString = "";
        //    switch (Extension)
        //    {
        //        case ".xlsx":
        //            srcConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES;""";
        //            break;
        //        case ".xls": //Excel 97-03
        //            srcConnString = @" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES""";
        //            break;
        //    }

        //    string srcQuery = "Select * from [" + SheetName + "]";
        //    OleDbConnection srcConn = new OleDbConnection(srcConnString);
        //    srcConn.Open();
        //    OleDbCommand objCmdSelect = new OleDbCommand(srcQuery, srcConn);
        //    DataSet ds = new DataSet();
        //    OleDbDataAdapter da = new OleDbDataAdapter(objCmdSelect);
        //    da.Fill(ds, SheetName);
        //    srcConn.Close();
        //    return ds.Tables[0];
        //}
        //catch (Exception)
        //{
        //    throw;
        //}
        #endregion 
        try
        {

            string srcConnString = "";
            switch (Extension)
            {
                case ".xlsx":
                    srcConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES;""";
                    break;
                case ".xls": //Excel 97-03
                    srcConnString = @" Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFile + @";Extended Properties=""Excel 8.0;HDR=YES""";
                    break;
            }
            //Excel.Application ExcelApp = new Excel.Application();
            //ExcelApp.Visible = false;
            ////String WorkbookPath = System.IO.Path.GetFullPath(Server.MapPath("~/ly_erp-Y1001-A0-01.xls"));
            //Excel.Workbook ExcelWorkbook = ExcelApp.Workbooks.Open(excelFile, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Excel.Worksheet Sheet = (Excel.Worksheet)ExcelWorkbook.Sheets[1];
            string srcQuery = "Select * from [" + SheetName + "]";
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
    public string GetProcessOwner(int processId)
    {
        string query = "Select * From Win32_Process Where ProcessID = " + processId;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        ManagementObjectCollection processList = searcher.Get();

        foreach (ManagementObject obj in processList)
        {
            string[] argList = new string[] { string.Empty, string.Empty };
            int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
            if (returnVal == 0)
            {
                return argList[1] + "\\" + argList[0];   // return DOMAIN\user
            }
        }
        return "NO OWNER";
    }
    public void KillProcessByNameAndUser(string ProcessName, string ProcessUserName, int HasStartedForHours)
    {
        Process[] foundProcesses = Process.GetProcessesByName(ProcessName);
        Console.WriteLine(foundProcesses.Length.ToString() + " processes found.");
        string strMessage = string.Empty;
        foreach (Process p in foundProcesses)
        {
            string UserName = GetProcessOwner(p.Id);
            strMessage = string.Format("Process Name: {0} | Process ID: {1} | User Name : {2} | StartTime {3}",
                                             p.ProcessName, p.Id.ToString(), UserName, p.StartTime.ToString());
            //Console.WriteLine(strMessage);
            bool TimeExpired = (p.StartTime.AddHours(HasStartedForHours) < DateTime.Now) || HasStartedForHours == 0;
            bool PrcoessUserName_Is_Matched = UserName.Equals(ProcessUserName);

            if ((ProcessUserName.ToLower() == "all" && TimeExpired) ||
                 PrcoessUserName_Is_Matched && TimeExpired)
            {
                p.Kill();
                //Console.WriteLine("Process ID " + p.Id.ToString() + " is killed.");
            }
        }
    }
    public DataTable LaySoLuong(string XieXing, string SheHao, string BWBH, string XTCC)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select CLSL from xtbwyl1 where XieXing=@XieXing and SheHao=@SheHao and BWBH=@BWBH and XTCC=@XTCC";
        cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("BWBH", BWBH, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("XTCC", XTCC, SqlDbType.VarChar));
        return Select(cmd).Tables[0];
    }
    public DataTable LaySize(string XieXing, string SheHao, string BWBH,string XTCC)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select CLSL from xtbwyl1 where XieXing=@XieXing and SheHao=@SheHao and BWBH=@BWBH  and XTCC=@XTCC";
        cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("BWBH", BWBH, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("XTCC", XTCC, SqlDbType.VarChar));
        return Select(cmd).Tables[0];
    }
    public void Import(List<string> lists,string excelFile, string SheetName, string Extension, string UserID, ref string Y1001_AO, ref string BWBH)
    {
        try
        {

            DataTable dt = GetExcel(excelFile, SheetName).Tables[0];


            if (dt.Rows.Count > 3)
            {
                Y1001_AO = dt.Rows[2][1].ToString().Trim();

                // string A_01 = dt.Rows[2][3].ToString();
                //string A_01 = A_01.Substring(A_01.IndexOf(':'));
                //string[] shehaosplit = dt.Rows[2][3].ToString().Split(':');
                //string A_01 = shehaosplit[1].Trim();
                //string[] listSheHao = A_01.Split('/');
               // BWBH = A_01;
                Hashtable _htbXTCC = new Hashtable();
                Hashtable _htb = new Hashtable();
                int J = 5;

                while (J < dt.Columns.Count)
                {
                    if (string.IsNullOrEmpty(dt.Rows[3][J].ToString().Trim()))
                    {
                        break;
                    }
                    else
                    {
                        string ab = dt.Rows[3][J].ToString().Trim();
                        if (ab == "AVERAGE" || ab == "")
                        {

                        }
                        else
                        {
                            _htbXTCC.Add("XTCC" + J, ab);
                        }
                       
                        J++;
                    }
                }
                for (int i = 4; i < dt.Rows.Count; i++)
                {

                    string Values = "";
                    string YN = "1";
                    DataRow drw = dt.Rows[i];
                    string BWBH1 = dt.Rows[i][0].ToString();
                    if (BWBH1 == "" || BWBH1.Length > 4)
                    {
                        //break;
                    }
                    else
                    {

                        foreach (string she in lists)
                        {
                            List<string> list = new List<string>();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "";
                           // cmd.CommandText = "delete from xtbwyl1 where XieXing =@XieXing and SheHao=@SheHao and BWBH=@BWBH ";
                            int K = 5;
                            BWBH = she;
                            ul = BWBH;
                            k = drw[0].ToString().Trim();
                            if (k == "126I")
                            {
                                string e = k;
                            }
                            foreach (DictionaryEntry entry in _htbXTCC)
                            {
                                string ah = "";
                                string IndexValue = i.ToString().Trim() + K.ToString().Trim();
                                ih = entry.Value.ToString();
                                decimal CLSL = 0;

                                try
                                {

                                    // CLSL = 0;
                                    CLSL = decimal.Parse(drw[K].ToString().Trim());
                                    ah = "delete from xtbwyl1 where XieXing =@XieXing and SheHao=@SheHao and BWBH=@BWBH and XTCC=@XTCC"+IndexValue+" ; INSERT INTO xtbwyl1(XieXing,SheHao,BWBH,XTCC,CLSL,USERID,USERDATE) VALUES(@XieXing,@SheHao,@BWBH,@XTCC" + IndexValue + ",@CLSL" + IndexValue + ",@USERID,@USERDATE)";
                                    list.Add(ah);

                                }
                                catch
                                {
                                   // DataTable ddd = LaySoLuong(Y1001_AO, she, drw[0].ToString(), entry.Value.ToString());
                                   //// string ah = ddd.Rows[0]["CLSL"].ToString();
                                    //try
                                    //{
                                    //    CLSL = decimal.Parse(dth.Rows[0]["CLSL"].ToString());
                                    //}
                                    //catch
                                    //{
                                    //    CLSL = 0;
                                    //}
                                    //CLSL = 0;
                                   // return;
                                }

                                cmd.Parameters.Add(CreateParameter("XTCC" + IndexValue, _htbXTCC["XTCC" + K].ToString()));
                                hu = CLSL.ToString();   
                                SqlParameter pra1 = new SqlParameter("CLSL" + IndexValue, SqlDbType.Decimal);
                                pra1.Size = 8;
                                pra1.Precision = 8;
                                pra1.Scale = 4;
                                pra1.Value = CLSL;
                                pra1.Direction = ParameterDirection.Input;
                                cmd.Parameters.Add(pra1);
                                K++;
                            }
                            foreach (string li in list)
                            {
                                Values += li;
                            }
                            cmd.CommandText += Values;
                            
                            cmd.Parameters.Add("XieXing", SqlDbType.VarChar, 15).Value = Y1001_AO;
                            cmd.Parameters.Add("SheHao", SqlDbType.VarChar, 5).Value = she;
                            cmd.Parameters.Add("BWBH", SqlDbType.VarChar, 5).Value = drw[0].ToString();
                            cmd.Parameters.Add("USERID", SqlDbType.VarChar, 15).Value = UserID;
                            cmd.Parameters.Add("USERDATE", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyyMMdd");
                            if (cmd.CommandText == "")
                            {
                            }
                            else
                            {
                               
                                ExecuteNonQuery(cmd);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            string y = hu;
            string h = ok;
            string m = ul;
            string lk = ih;
            string n = k;
            throw;
        }
    }
   
    public DataSet GetExcel(string fileName,string sheetName)
    {
       
        try
        {

            //  creat a Application object  @"D:\FilesImport\ly_erp-Y1001-A0-01.xls"
            oXL = new Excel.Application();

            //   get   WorkBook  object
            oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[sheetName];
            System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            DataRow dr;

            StringBuilder sb = new StringBuilder();
            int jValue = oSheet.UsedRange.Cells.Columns.Count;
            int iValue = oSheet.UsedRange.Cells.Rows.Count;

            for (int j = 1; j <= jValue; j++)
            {
                dt.Columns.Add("column" + j, System.Type.GetType("System.String"));
            }

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
        catch (Exception)
        {
            //return null;

            throw;
        }
        finally
        {
            oRng.Clear();
            GC.Collect();
            oWB.Close(false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            //oWB.Close();
            oXL.Quit();
            Marshal.ReleaseComObject(oRng);
            Marshal.ReleaseComObject(oWB);
            Marshal.ReleaseComObject(oSheet);
            Marshal.FinalReleaseComObject(oXL);
            oRng = null;
            oWB = null;
            oXL = null;
            oSheet = null;
            GC.GetTotalMemory(false);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.GetTotalMemory(true);
        }
    }
   
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception )
        {
            obj = null;
           
        }
        finally
        {
            GC.Collect();
        }

    }
    public void OpenFileExcel(string fileName)
    {
        Excel.Application oXL;
        Excel.Workbook oWB;
        try
        {
            oXL = new Excel.Application();
            oXL.Visible = true;
            //   get   WorkBook  object
            oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value);
            
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void CloseFileExcel()
    {
        
        //Process[] procs = Process.GetProcessesByName("EXCEL");
        //procs[0].Kill();
        //procs[0].WaitForExit();
        //foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
        //{
        //    if (process.MainModule.ModuleName.ToUpper().Equals("EXCEL.EXE"))
        //    {
        //        process.Kill();
        //        break;
        //    }
        //}
        //Process[] procs = Process.GetProcessesByName("EXCEL");
        //foreach (Process p in procs)
        //{
        //    int baseAdd = p.MainModule.BaseAddress.ToInt32();
        //    //oXL is Excel.ApplicationClass object
        //    if (baseAdd == oXL.Hinstance)
        //        p.Kill();
        //}
        //oWB.Close(true, Missing.Value, Missing.Value);
        //oXL.Quit();

        //releaseObject(oSheet);
        //releaseObject(oWB);
        //releaseObject(oXL);
        
    }

   
    public int UpdateData(string XieXing, string SheHao, string BWBH, string XTCC,string UserDate,string UserID,decimal CLSL)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "update xtbwyl1 set CLSL=@CLSL,USERDATE=@USERDATE,USERID=@USERID where XieXing=@XieXing and SheHao=@SheHao and BWBH=@BWBH and XTCC=@XTCC";
        cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("BWBH", BWBH, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("XTCC", XTCC, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("CLSL", CLSL, SqlDbType.Decimal));
        cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.VarChar));
        cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
        return ExecuteNonQuery(cmd);
    }
    public DataSet LayDanhSachDuLieuNhapVao(string XieXing, string SheHao)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1";
            cmd.CommandText += " WHERE  USERID=@USERID  and XieXing=@XieXing and BWBH=BWBH ";
            cmd.CommandText += " order by XTCC asc";

            // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];

            string abc = "";
            List<string> list = new List<string>();
            foreach (DataRow drw in dt.Rows)
            {

                abc += " , MAX(case XTCC when '" + drw["XTCC"].ToString() + "' then CLSL else 0 end)'" + drw["XTCC"].ToString() + "'";
                list.Add(abc);
            }
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT @XieXing as 'MODEL#',@SheHao as 'Color',BW.bwdh as 'Part#',BW.zwsm as 'Description',CL.cldh as 'Material#',CL.ywpm as 'Material description',CL.dwbh as 'Unit'";
            cmd1.CommandText += abc;
            cmd1.CommandText += " FROM xtbwyl1 XT";
            cmd1.CommandText += " LEFT JOIN xxzl XX ON XT.XieXing=XX.XieXing AND XX.SheHao=XT.SheHao";
            cmd1.CommandText += " LEFT JOIN XXZLS XS ON XT.XieXing=XS.XieXing AND XT.SheHao=XS.SheHao AND XT.BWBH=XS.BWBH";
            cmd1.CommandText += " LEFT JOIN bwzl BW  ON BW.bwdh=XT.BWBH";
            cmd1.CommandText += " LEFT JOIN clzl CL ON CL.cldh=XS.CLBH";
            cmd1.CommandText += " WHERE XT.XieXing=@XieXing AND XT.SheHao=@SheHao";
            cmd1.CommandText += " group by BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";

            cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            return Select(cmd1);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataSet LayDanhSachDuLieuTheoNgay(string UserDate, string UserID, string XieXing, string SheHao)
    {
        try
        {
           
            ///////////////////////////////////////////////////////////

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing and USERDATE=@USERDATE ";
            cmd.CommandText += " order by XTCC asc";
            cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.VarChar));
            // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];


            string abc = "";

            foreach (DataRow drw in dt.Rows)
            {

                string xtcc = drw["XTCC"].ToString();
                abc += " , MAX(case XT.XTCC when '" + xtcc + "' then XT.CLSL else 0 end)'" + xtcc + "'";

            }
            SqlCommand cmd1 = new SqlCommand();
            if (dt.Rows.Count > 0)
            {
                cmd1.CommandText = "SELECT @XieXing as 'MODEL#',XT.SheHao as 'Color',BW.bwdh as 'Part#',BW.zwsm as 'Description',CL.cldh as 'Material#',CL.ywpm as 'Material description',CL.dwbh as 'Unit'";
                cmd1.CommandText += abc;
                cmd1.CommandText += " FROM xtbwyl1 XT";
                cmd1.CommandText += " LEFT JOIN xxzl XX ON XT.XieXing=XX.XieXing AND XX.SheHao=XT.SheHao";
                cmd1.CommandText += " LEFT JOIN XXZLS XS ON XT.XieXing=XS.XieXing AND XT.SheHao=XS.SheHao AND XT.BWBH=XS.BWBH";
                cmd1.CommandText += " LEFT JOIN bwzl BW  ON BW.bwdh=XT.BWBH";
                cmd1.CommandText += " LEFT JOIN clzl CL ON CL.cldh=XS.CLBH";
                cmd1.CommandText += " WHERE  XT.USERID=@USERID and XT.XieXing=@XieXing ";
                cmd1.CommandText += " group by XT.SheHao, BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";

                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
                //cmd.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.VarChar));
            }
            else
            {
                cmd1.CommandText = "select DISTINCT convert(float,XTCC)";
                cmd1.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing  ";
                cmd1.CommandText += " order by convert(float,XTCC) asc";
                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                //cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
                
            }
            return Select(cmd1);
        }
        catch (Exception)
        {

            throw;

        }
    }
    public DataSet LayDanhSachDataByCondition1(string UserID, string XieXing, string SheHao)
    {
        try
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from xtbwyl2 where BWBH=ISNULL(@BWBH,BWBH) ";
            //cmd.CommandText +=" or xtbwyl2.USERDATE between @fromDate and @toDate";
            //cmd.Parameters.Add(CreateParameter("fromDate", fromDate, SqlDbType.DateTime));
            //cmd.Parameters.Add(CreateParameter("toDate", toDate, SqlDbType.DateTime));
            //cmd.Parameters.Add(CreateParameter("BWBH", id, SqlDbType.VarChar));
            //cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            //return Select(cmd);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing ";
            cmd.CommandText += " order by XTCC asc";
            cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];


            string abc = "";

            foreach (DataRow drw in dt.Rows)
            {

                string xtcc = drw["XTCC"].ToString();
                abc += " , MAX(case XT.XTCC when '" + xtcc + "' then XT.CLSL else 0 end)'" + xtcc + "'";

            }
            SqlCommand cmd1 = new SqlCommand();
            if (dt.Rows.Count > 0)
            {
                cmd1.CommandText = "SELECT @XieXing as 'MODEL#',XT.SheHao as 'Color',BW.bwdh as 'Part#',BW.zwsm as 'Description',CL.cldh as 'Material#',CL.ywpm as 'Material description',CL.dwbh as 'Unit'";
                cmd1.CommandText += abc;
                cmd1.CommandText += " FROM xtbwyl1 XT";
                cmd1.CommandText += " LEFT JOIN xxzl XX ON XT.XieXing=XX.XieXing AND XX.SheHao=XT.SheHao";
                cmd1.CommandText += " LEFT JOIN XXZLS XS ON XT.XieXing=XS.XieXing AND XT.SheHao=XS.SheHao AND XT.BWBH=XS.BWBH";
                cmd1.CommandText += " LEFT JOIN bwzl BW  ON BW.bwdh=XT.BWBH";
                cmd1.CommandText += " LEFT JOIN clzl CL ON CL.cldh=XS.CLBH";
                cmd1.CommandText += " WHERE XT.XieXing=@XieXing";
                cmd1.CommandText += " group by XT.SheHao, BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";

                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            }
            else
            {
                cmd1.CommandText = "select DISTINCT  XTCC";
                cmd1.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing and SheHao=@SheHao ";
                cmd1.CommandText += " order by XTCC asc";
                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            }
            return Select(cmd1);
            
            
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataSet LayDanhSachDataByCondition2(string UserID, string XieXing, string SheHao)
    {
        try
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "select * from xtbwyl2 where BWBH=ISNULL(@BWBH,BWBH) ";
            //cmd.CommandText +=" or xtbwyl2.USERDATE between @fromDate and @toDate";
            //cmd.Parameters.Add(CreateParameter("fromDate", fromDate, SqlDbType.DateTime));
            //cmd.Parameters.Add(CreateParameter("toDate", toDate, SqlDbType.DateTime));
            //cmd.Parameters.Add(CreateParameter("BWBH", id, SqlDbType.VarChar));
            //cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            //return Select(cmd);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT  XTCC";
            cmd.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing and SheHao=@SheHao ";
            cmd.CommandText += " order by XTCC asc";
            cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            cmd.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];


            string abc = "";

            foreach (DataRow drw in dt.Rows)
            {

                string xtcc = drw["XTCC"].ToString();
                abc += " , MAX(case XT.XTCC when '" + xtcc + "' then XT.CLSL else 0 end)'" + xtcc + "'";

            }
            SqlCommand cmd1 = new SqlCommand();
            if (dt.Rows.Count > 0)
            {
                cmd1.CommandText = "SELECT @XieXing as 'MODEL#',XT.SheHao as 'Color',BW.bwdh as 'Part#',BW.zwsm as 'Description',CL.cldh as 'Material#',CL.ywpm as 'Material description',CL.dwbh as 'Unit'";
                cmd1.CommandText += abc;
                cmd1.CommandText += " FROM xtbwyl1 XT";
                cmd1.CommandText += " LEFT JOIN xxzl XX ON XT.XieXing=XX.XieXing";
                cmd1.CommandText += " LEFT JOIN XXZLS XS ON XT.XieXing=XS.XieXing AND XT.BWBH=XS.BWBH";
                cmd1.CommandText += " LEFT JOIN bwzl BW  ON BW.bwdh=XT.BWBH";
                cmd1.CommandText += " LEFT JOIN clzl CL ON CL.cldh=XS.CLBH";
                cmd1.CommandText += " WHERE XT.XieXing=@XieXing AND XT.SheHao=@SheHao";
                cmd1.CommandText += " group by XT.SheHao, BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";

                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            }
            else
            {
                cmd1.CommandText = "select DISTINCT XTCC";
                cmd1.CommandText += " from xtbwyl1 where USERID=@USERID and XieXing=@XieXing and SheHao=@SheHao ";
                cmd1.CommandText += " order by XTCC asc";
                cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
                cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            }
            return Select(cmd1);


        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataSet DanhSachMaDay()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct XieXing from xtbwyl1";
            return Select(cmd);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataSet DanhSachMaMau()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct SheHao from xtbwyl1";
            return Select(cmd);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public  string[] GetXieXing(string prefixText, int count, string contextKey)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ERP1"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        // Try to use parameterized inline query/sp to protect sql injection
        SqlCommand cmd = new SqlCommand("SELECT TOP " + count + " XieXing FROM xtbwyl1 WHERE XieXing LIKE '" + prefixText + "%'", conn);
        SqlDataReader oReader;
        conn.Open();
        List<string> CompletionSet = new List<string>();
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (oReader.Read())
            CompletionSet.Add(oReader["XieXing"].ToString());
        return CompletionSet.ToArray();
    }
    public  string[] GetSheHao(string prefixText, int count, string contextKey)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ERP1"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        // Try to use parameterized inline query/sp to protect sql injection
        SqlCommand cmd = new SqlCommand("SELECT TOP " + count + " SheHao FROM xtbwyl1 WHERE SheHao LIKE '" + prefixText + "%'", conn);
        SqlDataReader oReader;
        conn.Open();
        List<string> CompletionSet = new List<string>();
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (oReader.Read())
            CompletionSet.Add(oReader["XieXing"].ToString());
        return CompletionSet.ToArray();
    }
    public string[] GetChuoi(string input, int count)
    {
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ERP1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select top " + count + " shehao from xtbwyl1 where shehao like '" + input + "%'",conn);
            SqlDataReader reader;
            conn.Open();
            List<string> com = new List<string>();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                com.Add(reader["shehao"].ToString());
            }
            return com.ToArray();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    public DataTable TimMaMauTheoDangDay(string XieXing)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct SheHao from xxzl where XieXing=@XieXing";
            cmd.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            return Select(cmd).Tables[0];
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}