using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

    public class GernericDataAccess
    {
        protected string _strConnectionName = "TheLogiS";
        public GernericDataAccess()
        { }
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
                WriteLogfile(pCmd);
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
                WriteLogfile(pCmd);
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
                WriteLogfile(pCmd);
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
                WriteLogfile(pCmd);
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
        private void WriteLogfile(SqlCommand pCmd)
        {
            try
            {
                //BLL_File bllFile = new BLL_File();
                //string strLogs = "";
                //SqlCommand cmd = pCmd.Clone();
                //strLogs += "CommandText: \n";
                //strLogs += cmd.CommandText + "\n";
                //strLogs += "Parameters: \n";
                //if (!CommonFunction.IsNullOrEmpty(cmd.Parameters))
                //{
                //    foreach (SqlParameter para in cmd.Parameters)
                //    {
                //        strLogs += para.ParameterName + " as " + para.SqlDbType.ToString() + " = " + para.Value.ToString() + "\n";
                //    }
                //}
                //bllFile.WriteErrorCommandLog(strLogs);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected SqlParameter CreateParameter(string pName, object pValue)
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

        protected SqlParameter CreateParameter(string pName, object pValue, SqlDbType pDBtype)
        {
            try
            {
                SqlParameter para = CreateParameter(pName, pValue);
                para.SqlDbType = pDBtype;

                return para;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected SqlParameter CreateParameter(string pName, object pValue, SqlDbType pDBtype, bool pNullable)
        {
            try
            {
                SqlParameter para = CreateParameter(pName, pValue);
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
        protected SqlParameter CreateParameter(string pName, object pValue, bool pNullable)
        {
            try
            {
                SqlParameter para = CreateParameter(pName, pValue);
                if (IsNullOrEmpty(pValue) && pNullable)
                {
                    para.Value = DBNull.Value;
                }
                para.IsNullable = pNullable;
                return para;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsNullOrEmpty(object obj)
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
        public bool IsDateTime(object obj)
        {
            try
            {
                DateTime A = DateTime.Parse(obj.ToString());
                return true;
            }
            catch { return false; }
        }
        public bool IsInterger(object obj)
        {
            try
            {
                int A = int.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsDouble(object obj)
        {
            try
            {
                double A = double.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsBool(object obj)
        {
            try
            {
                bool A = bool.Parse(obj.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
