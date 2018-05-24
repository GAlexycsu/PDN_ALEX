using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ETT_SqlParameter
/// </summary>
public class ETT_SqlParameter
{
    CommonFunction cmm = new CommonFunction();
    private object _value;
    public ETT_SqlParameter(string pName)
    {
        try
        {
            Name = pName;
            Value = null;
            GanGiaTriBanDau();
            
        }
        catch (Exception)
        {

            throw;
        }
    }
    public ETT_SqlParameter(string pName, object pValue)
    {
        try
        {
            Name = pName;
            Value = pValue;
            GanGiaTriBanDau();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public ETT_SqlParameter(string pName, object pValue, SqlDbType pDBType)
    {
        try
        {
            Name = pName;
            DBDataType = pDBType;
            Value = pValue;
            Nullable = false;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public ETT_SqlParameter(string pName, object pValue, SqlDbType pDBType, bool pNullable)
    {
        try
        {
            Name = pName;
            DBDataType = pDBType;
            Value = pValue;
            Nullable = pNullable;
        }
        catch (Exception)
        {
            throw;
        }
    }
    private void GanGiaTriBanDau()
    {
        try
        {
            DBDataType = SqlDbType.NVarChar;
            Nullable = false;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Name { get; set; }
    public bool Nullable { get; set; }
    public SqlDbType DBDataType { get; set; }
    public object Value
    {
        get { return _value; }
        set
        {
            if ((DBDataType.Equals(SqlDbType.DateTime)) && (cmm.IsNullOrEmpty(value)))
            {
                _value = null;
            }
            else
            {
                if ((Nullable) && (cmm.IsNullOrEmpty(value)))
                {
                    _value = DBNull.Value;
                }
                else
                {
                    _value = value;
                }
            }
        }
    }
    public System.Data.SqlClient.SqlParameter CreateSqlParameter()
    {
        try
        {
            CommonFunction _cmmFuntion = new CommonFunction();
            System.Data.SqlClient.SqlParameter para = new System.Data.SqlClient.SqlParameter();
            para.ParameterName = Name;
            if (_cmmFuntion.IsNullOrEmpty(Value))
            {
                para.Value = DBNull.Value;
            }
            else
            {
                para.Value = Value;
            }
            para.SqlDbType = DBDataType;
            return para;
        }
        catch (Exception)
        {
            throw;
        }
    }

}