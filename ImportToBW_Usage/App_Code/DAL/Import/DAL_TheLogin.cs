using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DAL_TheLogin
/// </summary>
public class DAL_TheLogin:DAL_TheLogin_GenericDataAccess
{
	public DAL_TheLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable KiemTraID(string pUserID, string pSystemID, string pSessionID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText ="select COUNT(*) from Users_Systems";
            cmd.CommandText +=" where UserID=@UserID and SystemID=@SystemID and SessionID=@SessionID";
            cmd.Parameters.Add(Para("UserID", pUserID));
            cmd.Parameters.Add(Para("SystemID", pSystemID));
            cmd.Parameters.Add(Para("SessionID", pSessionID));
            return Select(cmd).Tables[0];
        }
        catch (Exception)
        {

            throw;
        }
    }
    public int CapNhatID(string pUserID, string pSystemID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Users_Systems set SessionID='' where UserID=@UserID and SystemID=@SystemID";
            cmd.Parameters.Add(Para("UserID", pUserID));
            cmd.Parameters.Add(Para("SystemID", pSystemID));
            return ExecuteNonQuery(cmd);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataTable GetUserByIDTheLogin(string UserID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from TheUsers where USERID=@USERID";
            cmd.Parameters.Add(Para("UserID", UserID));

            return Select(cmd).Tables[0];
        }
        catch (Exception)
        {

            throw;
        }
    }
}