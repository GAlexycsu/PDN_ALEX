using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL_Base
/// </summary>
public class DAL_Base : DAL_SQL_GenericDataAccess
{
    protected string _TableName;
    protected ETT_SqlCommand cmd;
    public DAL_Base()
    {

    }
    public virtual DataSet Select(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Select(cmd.CreateCommandSelect(pTableName, pConditions), pTableName);
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(string pTableName, List<ETT_Condition> pConditions)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Select(cmd.CreateCommandSelect(pTableName, pConditions), pTableName);
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(string pStoredProcedurceName, List<ETT_SqlParameter> pParameters)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Select(cmd.CreateStoreProcedurceCommand(pStoredProcedurceName, pParameters));
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(string pStoredProcedurceName, List<ETT_SqlParameter> pParameters, string pTableName)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Select(cmd.CreateStoreProcedurceCommand(pStoredProcedurceName, pParameters), pTableName);
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(string pStoredProcedurceName)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Select(cmd.CreateStoreProcedurceCommand(pStoredProcedurceName));
            return ds;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Insert(string pTableName, List<ETT_Field> pValues)
    {
        try
        {
            int effected = 0;
            effected = ExecuteNonQuery(cmd.CreateCommandInsert(pTableName, pValues));
            return effected;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Delete(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            int effected = 0;
            effected = ExecuteNonQuery(cmd.CreateCommandDelete(pTableName, pConditions));
            return effected;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Update(string pTableName, List<ETT_Field> pValues, List<ETT_Field> pConditions)
    {
        try
        {
            int effected = 0;
            effected = ExecuteNonQuery(cmd.CreateCommandUpdate(pTableName, pValues, pConditions));
            return effected;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int ExecuteStoredProcedurce(string pStoredProcedurceName)
    {
        try
        {
            int effected = 0;
            effected = ExecuteNonQuery(cmd.CreateStoreProcedurceCommand(pStoredProcedurceName));
            return effected;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int ExecuteStoredProcedurce(string pStoredProcedurceName, List<ETT_SqlParameter> pParameters)
    {
        try
        {
            int effected = 0;
            effected = ExecuteNonQuery(cmd.CreateStoreProcedurceCommand(pStoredProcedurceName, pParameters));
            return effected;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public object InsertScalar(string pTableName, List<ETT_Field> pValues)
    {
        try
        {
            object obj = 0;
            obj = ExecuteScalar(cmd.CreateCommandInsertScalar(pTableName, pValues));
            return obj;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual DataSet Select(List<ETT_Field> pConditions)
    {
        try
        {
            return Select(_TableName, pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(List<ETT_Condition> pConditions)
    {
        try
        {
            return Select(_TableName, pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Insert(List<ETT_Field> pValues)
    {
        try
        {
            return Insert(_TableName, pValues);
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
            CommonFunction _cmmFuntion = new CommonFunction();
            SqlParameter para = new SqlParameter();
            para.ParameterName = pName;
            if (_cmmFuntion.IsNullOrEmpty(pValue))
            {
                para.Value = DBNull.Value;
            }
            else
            {
                para.Value = pValue;
            }
            //para.SqlDbType = pDBtype;
            return para;
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

            return CreateParameter(pName, pValue, SqlDbType.NVarChar);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Update(List<ETT_Field> pValues, List<ETT_Field> pConditions)
    {
        try
        {
            return Update(_TableName, pValues, pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public int Delete(List<ETT_Field> pConditions)
    {
        try
        {
            return Delete(_TableName, pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public object InsertScalar(List<ETT_Field> pValues)
    {
        try
        {
            return InsertScalar(_TableName, pValues);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual DataTable GetDataForDropDownList(string pTableName, string pTextField, string pValueField)
    {
        try
        {
            return Select(cmd.CreareCommandGetDatForDropDownList(pTableName, pTextField, pValueField)).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual DataTable GetDataForDropDownList(string pTableName, string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            return Select(cmd.CreareCommandGetDatForDropDownList(pTableName, pTextField, pValueField, pConditions)).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual DataTable GetDataForDropDownList(string pTextField, string pValueField)
    {
        try
        {
            return Select(cmd.CreareCommandGetDatForDropDownList(_TableName, pTextField, pValueField)).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual DataTable GetDataForDropDownList(string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            return Select(cmd.CreareCommandGetDatForDropDownList(_TableName, pTextField, pValueField, pConditions)).Tables[0];
        }
        catch (Exception)
        {
            throw;
        }
    }

}