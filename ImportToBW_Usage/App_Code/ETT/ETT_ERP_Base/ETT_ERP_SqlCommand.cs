using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ETT_PCM_SqlCommand
/// </summary>
public class ETT_ERP_SqlCommand : ETT_SqlCommand
{
    public ETT_ERP_SqlCommand()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public override SqlCommand CreateCommandSelect(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + pTableName + " WHERE 0 = 0 ";
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
    public override SqlCommand CreateCommandSelect(string pTableName, List<ETT_Condition> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM " + pTableName + " WHERE 0 = 0 ";
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
    public override SqlCommand CreateCommandInsertScalar(string pTableName, List<ETT_Field> pValues)
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
            cmd.CommandText += "SELECT Max(ID) FROM " + pTableName;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public override SqlCommand CreateCommandUpdate(string pTableName, List<ETT_Field> pValues, List<ETT_Field> pConditions)
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
            cmd.CommandText = "UPDATE " + pTableName + " SET " + strUpdate.Substring(0, strUpdate.Length - 2) + " WHERE 1 = 1 " + strCondition;
            return cmd;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public override SqlCommand CreateCommandDelete(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            List<ETT_Field> pValues = new List<ETT_Field>();
            cmd.CommandText = "DELETE FROM " + pTableName + " WHERE 0 = 0";
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
    public override SqlCommand CreareCommandGetDatForDropDownList(string pTableName, string pTextField, string pValueField)
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
    public override SqlCommand CreareCommandGetDatForDropDownList(string pTableName, string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            int paraIndex = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT " + pTextField + "," + pValueField + " FROM " + pTableName + " WHERE 0 = 0 ";
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