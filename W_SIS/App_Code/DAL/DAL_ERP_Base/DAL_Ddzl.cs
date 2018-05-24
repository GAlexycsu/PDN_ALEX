using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL_Ddzl 
/// </summary>
public class DAL_Ddzl : DAL_ERP_GenericDataAccess
{
//public DAL_Ddzl()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
public DataTable Querys1(string pID, string pFID, string pFNA )
    {
        try
        {
            int ID = 0;
            if (string.IsNullOrEmpty(pID)) { }
            else
            {
                ID = int.Parse(pID.Trim());
            }
             SqlCommand cmd = new SqlCommand();
             cmd.CommandText = "   select * from Ddzl ";
             cmd.CommandText += "  where DDBH=(case when isnull(@ID,0)=0 then id else @ID end )  ";
             cmd.CommandText += "  and  isnull(Xiexing,'') like case when @FID='' then isnull(Xiexing,'') else '%'+ @FID +'%' end ";
             cmd.CommandText += "  and  isnull(shehao,'') like case when @FNA<>'' then '%'  +@FNA+ '%'  else isnull(shehao,'') end ";
             cmd.CommandText += "  order by Xiexing ";

             cmd.Parameters.Add(Para("ID", ID, SqlDbType.Int));
             cmd.Parameters.Add(Para("FID", pFID, SqlDbType.NVarChar));
             cmd.Parameters.Add(Para("FNA", pFNA, SqlDbType.NVarChar));

             return Select(cmd).Tables[0];
        }
        catch (Exception)
        {           
            throw;
        }
  
    }
public int delete(int pID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " delete from Ddzl ";
            cmd.CommandText += " where DDBH=@ID ";

            cmd.Parameters.Add(Para("ID", pID, SqlDbType.Int));
            return ExecuteNonQuery(cmd); 
        }
        catch (Exception)
        {
            
            throw;
        }
       

    }
public int Insert(int pID)
{
    try
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = " insert into Ddzl(DDBH)";
        cmd.CommandText += " select distinct   @ID ";
        cmd.CommandText += " from Ddzl A  ";
        cmd.CommandText += " where not exists (select * from Ddzl B where  B.DDBH=@ID )";

        cmd.Parameters.Add(Para("ID", pID, SqlDbType.Int));

        return ExecuteNonQuery(cmd);
    }
    catch (Exception)
    {       
        throw;
    }
   }

public int Update(int pID, string pFID, string pFNA, string pVN, string pEN, string pCH, string pUI
    , DateTime pUD, string pST, string pSM, string pDB, string pUs, string pFN)
{
    try
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "  Update Ddzl ";
        
        cmd.CommandText += " set Xiexing=@FID, ";
        cmd.CommandText += "  Shehao=@FNA, ";
        cmd.CommandText += "  Article=@VN, ";
        cmd.CommandText += "  KHBH=@EN, ";
        cmd.CommandText += "  KHPO=@CH, ";
        cmd.CommandText += "  Userid=@UI, ";
        cmd.CommandText += "  Userdate=@UD, ";
        cmd.CommandText += "  SHIPDATE=@ST, ";
        cmd.CommandText += "  CCGB=@SM, ";
        cmd.CommandText += "  Pairs=@DB ";
        cmd.CommandText += "  DDGB=@FN ";
        cmd.CommandText += "  Dest=@Us ";
        cmd.CommandText += " where DDBH=@ID ";

        cmd.Parameters.Add(Para("ID", pID, SqlDbType.Int));
        cmd.Parameters.Add(Para("FID", pFID, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("FNA", pFNA, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("VN", pVN, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("EN", pEN, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("CH", pCH, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("UI", pUI, SqlDbType.VarChar));
        //cmd.Parameters.Add(Para("UD", pUD, SqlDbType.DateTime));
        cmd.Parameters.Add(Para("ST", pST, SqlDbType.VarChar));
        cmd.Parameters.Add(Para("SM", pSM, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("DB", pDB, SqlDbType.VarChar));
        cmd.Parameters.Add(Para("Us", pUs, SqlDbType.VarChar));
        cmd.Parameters.Add(Para("FN", int.Parse(pFN), SqlDbType.Int));
        return ExecuteNonQuery(cmd);
    }
    catch (Exception) { throw; }
   
}
}