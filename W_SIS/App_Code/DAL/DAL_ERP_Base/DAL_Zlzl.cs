using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL_Zlzl 
/// </summary>
public class DAL_Zlzl : DAL_ERP_GenericDataAccess
{
//public DAL_Zlzl()
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
             cmd.CommandText = "   select * from Zlzl ";
             cmd.CommandText += "  where ZLBH=isnull(Zlbh,'') ";
             cmd.CommandText += "  and  isnull(CQDH,'') like case when @FID='' then isnull(CQDH,'') else '%'+ @FID +'%' end ";
             cmd.CommandText += "  and  isnull(GSDH,'') like case when @FNA<>'' then '%'  +@FNA+ '%'  else isnull(GSDH,'') end ";
             cmd.CommandText += "  order by ZLBH ";

             cmd.Parameters.Add(Para("ID", ID, SqlDbType.VarChar));
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
            cmd.CommandText = " delete from Zlzl ";
            cmd.CommandText += " where ZLBH=@ID ";

            cmd.Parameters.Add(Para("ID", pID, SqlDbType.VarChar));
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
        cmd.CommandText = " insert into Zlzl(ZLBH)";
        cmd.CommandText += " select distinct   @ID ";
        cmd.CommandText += " from Zlzl A  ";
        cmd.CommandText += " where not exists (select * from Zlzl B where  B.ZLBH=@ID )";

        cmd.Parameters.Add(Para("ID", pID, SqlDbType.VarChar));

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
        cmd.CommandText = "  Update Zlzl ";
        
        cmd.CommandText += " set DDBH=@FID, ";
        cmd.CommandText += "  GSDH=@FNA, ";
        cmd.CommandText += "  CQDH=@VN, ";
        cmd.CommandText += "  CGBH=@EN, ";
        cmd.CommandText += "  trandate=@CH, ";
        cmd.CommandText += "  Userid=@UI, ";
        //cmd.CommandText += "  Userdate=@UD, ";
        cmd.CommandText += "  Transw=@ST, ";
        cmd.CommandText += "  ylbb=@SM, ";
        cmd.CommandText += "  SHQR=@DB ";
        cmd.CommandText += "  KDRQ=@FN ";
        cmd.CommandText += "  yn=@Us ";
        cmd.CommandText += " where ZLBH=@ID ";

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