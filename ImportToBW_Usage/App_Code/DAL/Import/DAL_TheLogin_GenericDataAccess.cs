using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DAL_TheLogin_GenericDataAccess
/// </summary>
public class DAL_TheLogin_GenericDataAccess:DAL_SQL_GenericDataAccess
{
	public DAL_TheLogin_GenericDataAccess()
	{
        _strConnectionName = "TheLogin";
	}
    protected SqlParameter Para(string pName, object pValue)
    {
        try
        {
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@" + pName;
            para.Value = pValue;

            return para;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected SqlParameter Para(string pName, object pValue, SqlDbType pDBtype)
    {
        try
        {
            SqlParameter para = Para(pName, pValue);
            para.SqlDbType = pDBtype;

            return para;
        }
        catch (Exception)
        {
            throw;
        }
    }
}