using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ETT_Condition
/// </summary>
public class ETT_Condition
{
    public ETT_Condition(string pName)
    {
        try
        {
            DBColumnName = pName;
            Value = null;
            GanGiaTriBanDau();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public ETT_Condition(string pName, object pValue)
    {
        try
        {
            DBColumnName = pName;
            Value = pValue;
            GanGiaTriBanDau();
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
            ConditionOperator = ETT_Operators.IsEqual;
            ConditionLogic = ETT_ConditionLogic.AND;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public string DBColumnName { get; set; }
    public SqlDbType DBDataType { get; set; }
    public object Value { get; set; }
    public string ConditionOperator { get; set; }
    public string ConditionLogic { get; set; }
}