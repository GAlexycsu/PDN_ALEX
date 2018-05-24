using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DAL_Busers
/// </summary>
public class DAL_Busers:DAL_ERP_GenericDataAccess
{
	public DAL_Busers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetUserByID(string UserID, string Company)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Busers2 where USERID=@USERID and GSBH=@GSBH";
            cmd.Parameters.Add(CreateParameter("USERID", UserID));
            cmd.Parameters.Add(CreateParameter("GSBH", Company));
            return Select(cmd).Tables[0];
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataTable GetUserLogin(string UserID, string Company, string Password)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Busers2 where USERID=@USERID and GSBH=@GSBH and PWD=@PWD";
            cmd.Parameters.Add(CreateParameter("USERID", UserID));
            cmd.Parameters.Add(CreateParameter("GSBH", Company));
            cmd.Parameters.Add(CreateParameter("PWD", Password));
            return Select(cmd).Tables[0];
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    
}