using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for BLL_Base
/// </summary>
public class BLL_Base
{
    protected DAL_Base _dalBase;
    public BLL_Base()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public virtual DataSet Search(ETT_SearchCondition pSearchCondition)
    {
        try
        {
            return Select(pSearchCondition.ListCondition);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(string pTableName, List<ETT_Field> pConditions)
    {
        try
        {
            return _dalBase.Select(pTableName, pConditions);
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
            return _dalBase.Select(pTableName, pConditions);
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
            return _dalBase.Select(pStoredProcedurceName, pParameters);
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
            return _dalBase.Insert(pTableName, pValues);
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
            return _dalBase.Delete(pTableName, pConditions);
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
            return _dalBase.Update(pTableName, pValues, pConditions);
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
            return _dalBase.InsertScalar(pTableName, pValues);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public DataSet Select(List<ETT_Field> pConditions)
    {
        try
        {
            return _dalBase.Select(pConditions);
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
            return _dalBase.Select(pConditions);
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
            return _dalBase.Insert(pValues);
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
            return _dalBase.Update(pValues, pConditions);
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
            return _dalBase.Delete(pConditions);
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
            return _dalBase.InsertScalar(pValues);
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
            return _dalBase.GetDataForDropDownList(pTableName, pTextField, pValueField);
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
            return _dalBase.GetDataForDropDownList(pTableName, pTextField, pValueField, pConditions);
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
            return _dalBase.GetDataForDropDownList(pTextField, pValueField);
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
            return _dalBase.GetDataForDropDownList(pTextField, pValueField, pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownListWithEmptyItem(DropDownList pDDL, string pTextField, string pValueField)
    {
        try
        {
            FillDropDownList(pDDL, pTextField, pValueField);
            pDDL.Items.Insert(0, "");
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownListWithEmptyItem(DropDownList pDDL)
    {
        try
        {
            FillDropDownListWithEmptyItem(pDDL, "Name", "ID");
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownListWithEmptyItem(DropDownList pDDL, string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            FillDropDownList(pDDL, pTextField, pValueField, pConditions);
            pDDL.Items.Insert(0, "");
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownListWithEmptyItem(DropDownList pDDL, List<ETT_Field> pConditions)
    {
        try
        {
            FillDropDownListWithEmptyItem(pDDL, "Name", "ID", pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownList(DropDownList pDDL, List<ETT_Field> pConditions)
    {
        try
        {
            FillDropDownList(pDDL, "Name", "ID", pConditions);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownList(DropDownList pDDL, string pTextField, string pValueField, List<ETT_Field> pConditions)
    {
        try
        {
            pDDL.DataSource = GetDataForDropDownList(pTextField, pValueField, pConditions);
            pDDL.DataTextField = pTextField;
            pDDL.DataValueField = pValueField;
            pDDL.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownList(DropDownList pDDL, string pTextField, string pValueField)
    {
        try
        {
            pDDL.DataSource = GetDataForDropDownList(pTextField, pValueField);
            pDDL.DataTextField = pTextField;
            pDDL.DataValueField = pValueField;
            pDDL.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void FillDropDownList(DropDownList pDDL)
    {
        try
        {
            FillDropDownList(pDDL, "Name", "ID");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
