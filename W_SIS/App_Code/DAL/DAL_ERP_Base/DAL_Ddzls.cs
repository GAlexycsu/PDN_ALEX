using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL_Ddzls 
/// </summary>
public class DAL_Ddzls : DAL_ERP_GenericDataAccess
{
//public DAL_Ddzls()
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
             cmd.CommandText = "   select * from Ddzls ";
             cmd.CommandText += "  where DDBH=isnull(@ID,'') ";
             cmd.CommandText += "  order by DDBH ";

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
            cmd.CommandText = " delete from Ddzls ";
            cmd.CommandText += " where DDBH=@ID ";

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
        cmd.CommandText = " insert into Ddzls(DDBH)";
        cmd.CommandText += " select distinct   @ID ";
        cmd.CommandText += " from Ddzls A  ";
        cmd.CommandText += " where not exists (select * from Ddzls B where  B.DDBH=@ID )";

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
        cmd.CommandText = "  Update Ddzls ";
        
        cmd.CommandText += " set LineNum=@FID, ";
        cmd.CommandText += "  CC=@FNA, ";
        cmd.CommandText += "  Quantity=@VN, ";
        cmd.CommandText += "  Quantity1=@EN, ";
        cmd.CommandText += "  Quantity2=@CH, ";
        cmd.CommandText += "  Userid=@UI, ";
        cmd.CommandText += "  Userdate=@UD, ";
        cmd.CommandText += "  MTDJ=@ST, ";
        cmd.CommandText += "  Iprice=@SM, ";
        cmd.CommandText += "  Cprice=@DB, ";
        cmd.CommandText += "  Price=@FN ";
        cmd.CommandText += "   ";
        cmd.CommandText += " where DDBH=@ID ";

        cmd.Parameters.Add(Para("ID", pID, SqlDbType.VarChar));
        cmd.Parameters.Add(Para("FID", pFID, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("FNA", pFNA, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("VN", pVN, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("EN", pEN, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("CH", pCH, SqlDbType.NVarChar));
        cmd.Parameters.Add(Para("UI", pUI, SqlDbType.VarChar));
        cmd.Parameters.Add(Para("UD", pUD, SqlDbType.DateTime));
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