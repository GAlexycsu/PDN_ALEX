using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ETT_Base
/// </summary>
public class ETT_Base
{
    public string _Message = "";
    public List<ETT_Field> _lstProperties;
    public List<string> _lstMessage;
    protected string _TableName;
    protected DAL_Base _dal;

    public ETT_Base()
    {

    }
    public virtual bool IsValid()
    {
        try
        {
            bool success = true;
            _lstMessage = new List<string>();
            foreach (ETT_Field ett in _lstProperties)
            {
                if (ett.IsValid == false)
                {
                    success = false;
                    _lstMessage.Add(ett.Message);
                }
            }
            return success;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Select()
    {
        try
        {
            List<ETT_Field> Conditions = new List<ETT_Field>();
            foreach (ETT_Field ett in _lstProperties)
            {
                if (ett.IsPrimaryKey)
                {
                    Conditions.Add(ett);
                }
            }
            DataTable dt = _dal.Select(_TableName, Conditions).Tables[_TableName];
            SetValue(dt);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Select(ETT_Field pEtt)
    {
        try
        {
            List<ETT_Field> Conditions = new List<ETT_Field>();
            Conditions.Add(pEtt);
            DataTable dt = _dal.Select(_TableName, Conditions).Tables[_TableName];
            SetValue(dt);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Select(int pID)
    {
        try
        {
            List<ETT_Field> Conditions = new List<ETT_Field>();
            ETT_Field ID = new ETT_Field("ID");
            ID.DBDataType = SqlDbType.Int;
            ID.Value = pID;
            Conditions.Add(ID);
            DataTable dt = _dal.Select(_TableName, Conditions).Tables[_TableName];
            SetValue(dt);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void SetValue(DataTable dt)
    {
        try
        {
            if (dt.Rows.Count > 0)
            {
                foreach (ETT_Field ett in _lstProperties)
                {
                    ett.SetValueNoValidation = dt.Rows[0][ett.DBColumnName];
                    ett.SetNewValueNoValidation = dt.Rows[0][ett.DBColumnName];
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Select(string pID)
    {
        try
        {
            int ID = 0;
            try
            {
                ID = int.Parse(pID);
                Select(ID);
            }
            catch
            {
                _lstMessage.Add("Incorrect ID");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void InsertScalar()
    {
        try
        {
            List<ETT_Field> Values = new List<ETT_Field>();
            foreach (ETT_Field ett in _lstProperties)
            {
                if (!ett.IsAutoIncrease)
                {
                    Values.Add(ett);
                }
            }
            object ID = _dal.InsertScalar(_TableName, Values);
            Select((int)ID);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual bool Insert()
    {
        try
        {
            _lstMessage = new List<string>();
            bool NotExists = true;
            foreach (ETT_Field properties in _lstProperties)
            {
                if (properties.IsUnique)
                {
                    List<ETT_Condition> lstCondition = new List<ETT_Condition>();
                    ETT_Condition EqualValue = new ETT_Condition(properties.DBColumnName);
                    EqualValue.Value = properties.Value;
                    lstCondition.Add(EqualValue);
                    if (Exists(lstCondition))
                    {
                        NotExists = false;
                        _lstMessage.Add("Exists " + properties.DisplayName + " = " + properties.Value.ToString());
                    }
                }
            }
            if (NotExists)
            {
                List<ETT_Field> Values = new List<ETT_Field>();
                foreach (ETT_Field ett in _lstProperties)
                {
                    if (!ett.IsAutoIncrease)
                    {
                        Values.Add(ett);
                    }
                }
                int effected = _dal.Insert(_TableName, Values);
                if (effected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Delete()
    {
        try
        {
            List<ETT_Field> Conditions = new List<ETT_Field>();
            foreach (ETT_Field ett in _lstProperties)
            {
                if (ett.IsPrimaryKey)
                {
                    Conditions.Add(ett);
                }
            }
            int effected = _dal.Delete(_TableName, Conditions);
            if (effected > 0)
            {
                foreach (ETT_Field ett in _lstProperties)
                {
                    ett.Value = new object();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual void Delete(int pID)
    {
        try
        {
            List<ETT_Field> Conditions = new List<ETT_Field>();
            ETT_Field ID = new ETT_Field("ID");
            ID.DBDataType = SqlDbType.Int;
            ID.Value = pID;
            Conditions.Add(ID);
            int effected = _dal.Delete(_TableName, Conditions);
            foreach (ETT_Field ett in _lstProperties)
            {
                ett.Value = new object();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual bool Update()
    {
        try
        {
            _lstMessage = new List<string>();
            bool NotExists = true;
            foreach (ETT_Field properties in _lstProperties)
            {
                if (properties.IsUnique)
                {

                    List<ETT_Condition> lstCondition = new List<ETT_Condition>();
                    ETT_Condition EqualValue = new ETT_Condition(properties.DBColumnName);
                    EqualValue.Value = properties.NewValue;
                    lstCondition.Add(EqualValue);

                    ETT_Condition NotEqualValue = new ETT_Condition(properties.DBColumnName);
                    NotEqualValue.Value = properties.Value;
                    NotEqualValue.ConditionOperator = ETT_Operators.IsNotEqual;
                    lstCondition.Add(NotEqualValue);

                    if (Exists(lstCondition))
                    {
                        NotExists = false;
                        _lstMessage.Add("Exists " + properties.DisplayName + " = " + properties.NewValue.ToString());
                    }
                }
            }

            if (NotExists)
            {
                List<ETT_Field> Conditions = new List<ETT_Field>();
                foreach (ETT_Field ett in _lstProperties)
                {
                    if (ett.IsPrimaryKey)
                    {
                        Conditions.Add(ett);
                    }
                }
                List<ETT_Field> Values = new List<ETT_Field>();
                foreach (ETT_Field ett in _lstProperties)
                {
                    if ((!ett.IsAutoIncrease) && (!ett.IsPrimaryKey))
                    {
                        Values.Add(ett);
                    }
                }
                int effected = _dal.Update(_TableName, Values, Conditions);
                if (effected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool Exists(List<ETT_Condition> pConditions)
    {
        try
        {
            DataTable dt = _dal.Select(_TableName, pConditions).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public bool Save(bool pIsInsert)
    {
        try
        {
            if (IsValid())
            {
                if (pIsInsert)
                {
                    return Insert();
                }
                else
                {
                    return Update();
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}