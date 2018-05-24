using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public class ClassGenera
    {
        public static string _strConnectName = "ERP";
    
        public static SqlConnection Connect()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings[_strConnectName].ToString();
                return con;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataSet selex(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = Connect();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public static DataSet selex(SqlCommand pCmd, string pTableName)
        {
            try
            {
                pCmd.Connection = Connect();
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
        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = Connect();
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public static SqlParameter Para(string pName, object pValues)
        {
            try
            {
                SqlParameter papa = new SqlParameter();
                papa.ParameterName = "@" + pName;
                papa.Value = pValues;
                return papa;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static SqlParameter Para(string pName, object pValues, SqlDbType pDBType)
        {
            try
            {
                SqlParameter papa = new SqlParameter();
                papa.ParameterName = "@" + pName;
                papa.Value = pValues;
                papa.SqlDbType = pDBType;
                return papa;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static SqlParameter Para(string pName, object pValue, SqlDbType pDBtype, bool pNullable)
        {
            try
            {
                SqlParameter para = Para(pName, pValue);
                if (IsNullOrEmpty(pValue) && pNullable)
                {
                    para.Value = DBNull.Value;
                }
                para.IsNullable = pNullable;
                para.SqlDbType = pDBtype;

                return para;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool IsNullOrEmpty(object obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return true;
            }
        }
    }
}