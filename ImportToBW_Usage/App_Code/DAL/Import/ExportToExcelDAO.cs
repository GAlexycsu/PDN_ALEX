using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ExportToExcelDAO
/// </summary>
public class ExportToExcelDAO : DAL_ERP_GenericDataAccess
{
	public ExportToExcelDAO()
	{
		
	}
    public DataSet LayDanhSachDuLieuNhapVao(string XieXing, string SheHao)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT XTCC";
            cmd.CommandText += " from xtbwyl2";
            cmd.CommandText += " order by XTCC asc";
            
           // return Select(cmd);
            DataTable dt = Select(cmd).Tables[0];
            
             string abc ="";
            List<string> list = new List<string>();
            foreach (DataRow drw in dt.Rows)
            {

                abc += " , MAX(case XTCC when '" + drw["XTCC"].ToString() + "' then CLSL else 0 end)'" + drw["XTCC"].ToString() + "'";
                list.Add(abc);
            }
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";
            cmd1.CommandText += abc;
            cmd1.CommandText += " FROM xtbwyl2 XT";
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
    public DataSet LayDanhSachDuLieuTheoNgay(string XieXing, string SheHao,DateTime UserDate,string UserID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select DISTINCT XTCC";
            cmd.CommandText += " from xtbwyl2";
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
            cmd1.CommandText = "SELECT BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";
            cmd1.CommandText += abc;
            cmd1.CommandText += " FROM xtbwyl2 XT";
            cmd1.CommandText += " LEFT JOIN xxzl XX ON XT.XieXing=XX.XieXing AND XX.SheHao=XT.SheHao";
            cmd1.CommandText += " LEFT JOIN XXZLS XS ON XT.XieXing=XS.XieXing AND XT.SheHao=XS.SheHao AND XT.BWBH=XS.BWBH";
            cmd1.CommandText += " LEFT JOIN bwzl BW  ON BW.bwdh=XT.BWBH";
            cmd1.CommandText += " LEFT JOIN clzl CL ON CL.cldh=XS.CLBH";
            cmd1.CommandText += " WHERE XT.XieXing=@XieXing AND XT.SheHao=@SheHao and XT.USERID=@USERID and XT.USERDATE=@USERDATE";
            cmd1.CommandText += " group by BW.bwdh,BW.zwsm,CL.cldh,CL.ywpm,CL.dwbh";

            cmd1.Parameters.Add(CreateParameter("XieXing", XieXing, SqlDbType.VarChar));
            cmd1.Parameters.Add(CreateParameter("SheHao", SheHao, SqlDbType.VarChar));
            cmd1.Parameters.Add(CreateParameter("USERID", UserID, SqlDbType.VarChar));
            cmd1.Parameters.Add(CreateParameter("USERDATE", UserDate, SqlDbType.VarChar));
            return Select(cmd1);
        }
        catch (Exception)
        {

            throw;
        }
    }
}