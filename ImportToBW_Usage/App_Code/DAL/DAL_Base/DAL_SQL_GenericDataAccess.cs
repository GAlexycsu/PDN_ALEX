using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for DAL_HRM_GenericDataAccess
/// </summary>
public class DAL_SQL_GenericDataAccess
{
    protected string _strConnectionName = "";
    public DAL_SQL_GenericDataAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private SqlConnection Conn()
    {
        try
        {
            SqlConnection Cnn = new SqlConnection();
            Cnn.ConnectionString = ConfigurationManager.ConnectionStrings[_strConnectionName].ToString();
            return Cnn;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected DataSet Select(SqlCommand pCmd)
    {
        try
        {
            pCmd.Connection = Conn();
            if (pCmd.Connection.State == ConnectionState.Closed)
            {
                pCmd.Connection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = pCmd;
            da.Fill(ds);
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (pCmd.Connection.State == ConnectionState.Open)
            {
                pCmd.Connection.Close();
            }
        }
    }
    protected DataSet Select(SqlCommand pCmd, string pTableName)
    {
        try
        {
            pCmd.Connection = Conn();
            if (pCmd.Connection.State == ConnectionState.Closed)
            {
                pCmd.Connection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = pCmd;
            da.Fill(ds, pTableName);
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (pCmd.Connection.State == ConnectionState.Open)
            {
                pCmd.Connection.Close();
            }
        }
    }
    protected int ExecuteNonQuery(SqlCommand pCmd)
    {
        try
        {
            pCmd.Connection = Conn();
            if (pCmd.Connection.State == ConnectionState.Closed)
            {
                pCmd.Connection.Open();
            }
            return pCmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (pCmd.Connection.State == ConnectionState.Open)
            {
                pCmd.Connection.Close();
            }
        }
    }
    protected object ExecuteScalar(SqlCommand pCmd)
    {
        try
        {
            pCmd.Connection = Conn();
            if (pCmd.Connection.State == ConnectionState.Closed)
            {
                pCmd.Connection.Open();
            }
            return pCmd.ExecuteScalar();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (pCmd.Connection.State == ConnectionState.Open)
            {
                pCmd.Connection.Close();
            }
        }
    }
}