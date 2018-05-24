using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ETT_SqlCommand
/// </summary>
public class ETT_SqlCommand
{
    CommonFunction _cmmFuntion = new CommonFunction();
    public ETT_SqlCommand()
    {

    }
    public virtual SqlCommand CreateConditionForCommand(string pCommandText, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = pCommandText + " WHERE 1 = 1 ";
            foreach (ETT_Field ett in pConditions)
            {
                string paraName = "";
                cmd.Parameters.Add(CreateParemeter(ett, paraIndex++, ref paraName));
                cmd.CommandText += " AND " + ett.DBColumnName + " = " + paraName;
            }
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandSelect(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + pTableName + " WHERE 1 = 1 ";
            foreach (ETT_Field ett in pConditions)
            {
                string paraName = "";
                cmd.Parameters.Add(CreateParemeter(ett, paraIndex++, ref paraName));
                cmd.CommandText += " AND " + ett.DBColumnName + " = " + paraName;
            }

            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandSelect(string pTableName, List<ETT_Condition> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + pTableName + " WHERE 1 = 1 ";
            foreach (ETT_Condition ett in pConditions)
            {
                string paraName = "";
                cmd.Parameters.Add(CreateParemeter(ett, paraIndex++, ref paraName));
                cmd.CommandText += " " + ett.ConditionLogic + " " + ett.DBColumnName + " " + ett.ConditionOperator + " " + paraName;
            }
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandInsert(string pTableName, List<ETT_Field> pValues)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            string strField = "";
            string strValue = "";
            foreach (ETT_Field ett in pValues)
            {
                string paraName = "";
                cmd.Parameters.Add(CreateParemeter(ett, paraIndex++, ref paraName));
                strField += "," + ett.DBColumnName;
                strValue += "," + paraName;
            }
            cmd.CommandText = "INSERT INTO " + pTableName + "(" + strField.Substring(1) + ") VALUES(" + strValue.Substring(1) + ")";
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandInsertScalar(string pTableName, List<ETT_Field> pValues)
    {
        try
        {
            return new SqlCommand();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandUpdate(string pTableName, List<ETT_Field> pValues, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            string strUpdate = "";
            string strCondition = "";
            string paraName = "";
            foreach (ETT_Field ett_update in pValues)
            {
                cmd.Parameters.Add(CreateParemeterNewValue(ett_update, paraIndex++, ref paraName));
                strUpdate += ett_update.DBColumnName + " = " + paraName + " , ";
            }
            foreach (ETT_Field ett_condition in pConditions)
            {
                cmd.Parameters.Add(CreateParemeter(ett_condition, paraIndex++, ref paraName));
                strCondition += " AND " + ett_condition.DBColumnName + " = " + paraName;
            }
            cmd.CommandText = "UPDATE " + pTableName + " SET " + strUpdate.Substring(0, strUpdate.Length - 2) + " WHERE 1=1 " + strCondition;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateCommandDelete(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected SqlParameter CreateParemeter(ETT_Field pETT_Field, int pIndex, ref string pParaName)
    {
        try
        {
            pParaName = "@" + pETT_Field.DBColumnName + pIndex.ToString();
            SqlParameter para = CreateParameter(pParaName, pETT_Field.Value, pETT_Field.DBDataType);
            return para;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected SqlParameter CreateParemeter(ETT_Field pETT_Field)
    {
        try
        {
            SqlParameter para = CreateParameter(pETT_Field.DBColumnName, pETT_Field.Value, pETT_Field.DBDataType);
            return para;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected SqlParameter CreateParemeter(ETT_SqlParameter pPara)
    {
        try
        {
            SqlParameter para = CreateParameter("@" + pPara.Name, pPara.Value, pPara.DBDataType);
            return para;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected SqlParameter CreateParemeter(ETT_Condition pETT_Field, int pIndex, ref string pParaName)
    {
        try
        {
            pParaName = "@" + pETT_Field.DBColumnName + pIndex.ToString();
            SqlParameter para = CreateParameter(pParaName, pETT_Field.Value, pETT_Field.DBDataType);
            return para;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected SqlParameter CreateParemeterNewValue(ETT_Field pETT_Field, int pIndex, ref string pParaName)
    {
        try
        {
            pParaName = "@" + pETT_Field.DBColumnName + pIndex.ToString();
            SqlParameter para = CreateParameter(pParaName, pETT_Field.NewValue, pETT_Field.DBDataType);
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
            para.SqlDbType = pDBtype;
            return para;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateStoreProcedurceCommand(string pStoredProcedurceName, List<ETT_SqlParameter> pParameters)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = pStoredProcedurceName;
            foreach (ETT_SqlParameter para in pParameters)
            {
                cmd.Parameters.Add(CreateParemeter(para));
            }
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateStoreProcedurceCommand(string pStoredProcedurceName)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = pStoredProcedurceName;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreateTextCommand(string pCommandText, List<ETT_SqlParameter> pParameters)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = pCommandText;
            foreach (ETT_SqlParameter para in pParameters)
            {
                cmd.Parameters.Add(CreateParemeter(para));
            }
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreareCommandGetDatForDropDownList(string pTableName, string pTextField, string pValueField)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT " + pTextField + "," + pValueField + " FROM " + pTableName + " GROUP BY " + pTextField + "," + pValueField + " ORDER BY " + pTextField;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual SqlCommand CreareCommandGetDatForDropDownList(string pTableName, string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT " + pTextField + "," + pValueField + " FROM " + pTableName + " WHERE 1 = 1 ";
            foreach (ETT_Field ett in pConditions)
            {
                string paraName = "";
                cmd.Parameters.Add(CreateParemeter(ett, paraIndex++, ref paraName));
                cmd.CommandText += " AND " + ett.DBColumnName + " = " + paraName;
            }
            cmd.CommandText += " GROUP BY " + pTextField + "," + pValueField + " ORDER BY " + pTextField;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
}