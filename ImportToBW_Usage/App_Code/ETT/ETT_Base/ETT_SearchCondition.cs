using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ETT_SearchCondition
/// </summary>
public class ETT_SearchCondition
{	
    private List<ETT_Field> _ListCondition;

    public List<ETT_Field> ListCondition
    {
        get { return _ListCondition; }
        set { _ListCondition = value; }
    }

    CommonFunction _cmm = new CommonFunction();

    public ETT_SearchCondition()
    {
        _ListCondition = new List<ETT_Field>();
    }

    public void Add(ETT_Field pETT)
    {
        try
        {
            _ListCondition.Add(pETT);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(ETT_Field pETT, bool NotAddEmpty)
    {
        try
        {
            if (NotAddEmpty)
            {
                if (!_cmm.IsNullOrEmpty(pETT.Value))
                {
                    _ListCondition.Add(pETT);
                }
            }
            else
            {
                _ListCondition.Add(pETT);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(ETT_Field pETT, object pValue, bool NotAddEmpty)
    {
        try
        {
            if (NotAddEmpty)
            {
                if (!_cmm.IsNullOrEmpty(pValue))
                {
                    pETT.Value = pValue;
                    _ListCondition.Add(pETT);
                }
            }
            else
            {
                pETT.Value = pValue;
                _ListCondition.Add(pETT);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Add(ETT_Field pETT, object pValue)
    {
        try
        {
            Add(pETT, pValue, true);
        }
        catch (Exception)
        {
            throw;
        }
    }
}