using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ETT_Field
/// </summary>
public class ETT_Field
{

    CommonFunction _cmmFuction = new CommonFunction();

    private string _DBColumnName;
    private string _DisplayName;
    private object _value;
    private SqlDbType _DBDataType;
    private bool _isPrimaryKey;
    private bool _isForeignKey;
    private int _maxLength;
    private int _minLength;
    private object _maxValue;
    private object _minValue;
    private ETT_SystemDataType _sysDataType;
    private bool _isValid;
    private string _message;
    private object _defaultValue;
    private bool _isNullable;
    private bool _isAutoIncrease;
    private bool _isUnique;
    private object _NewValue;

    private void GanGiaTriBanDau()
    {
        try
        {
            _sysDataType = new ETT_SystemDataType();
            _sysDataType = ETT_SystemDataType.String;
            _isForeignKey = false;
            _isPrimaryKey = false;
            _isNullable = true;
            _isValid = true;
            _message = "";
            _defaultValue = new object();
            _value = new object();
            _DBDataType = new SqlDbType();
            _DBDataType = SqlDbType.NVarChar;
            _isAutoIncrease = false;
            _minLength = -1;
            _maxLength = -1;
            _isUnique = false;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public ETT_Field(string pName)
    {
        try
        {
            GanGiaTriBanDau();
            _DBColumnName = pName;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public ETT_Field(string pName, object pValue)
    {
        try
        {
            GanGiaTriBanDau();
            _DBColumnName = pName;
            _value = pValue;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public bool IsNullable
    {
        get { return _isNullable; }
        set { _isNullable = value; }
    }

    public bool IsAutoIncrease
    {
        get { return _isAutoIncrease; }
        set { _isAutoIncrease = value; }
    }

    public object DefaultValue
    {
        get { return _defaultValue; }
        set { _defaultValue = value; }
    }

    public string Tostring()
    {
        try
        {
            return _value.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Message
    {
        get { return _message; }
    }

    public bool IsValid
    {
        get { return _isValid; }
    }

    public ETT_SystemDataType SysDataType
    {
        get { return _sysDataType; }
        set { _sysDataType = value; }
    }

    public int MinLength
    {
        get { return _minLength; }
        set { _minLength = value; }
    }

    public int MaxLength
    {
        get { return _maxLength; }
        set { _maxLength = value; }
    }

    public bool IsForeignKey
    {
        get { return _isForeignKey; }
        set { _isForeignKey = value; }
    }

    public bool IsPrimaryKey
    {
        get { return _isPrimaryKey; }
        set { _isPrimaryKey = value; }
    }

    public object Value
    {
        get { return _value; }
        set
        {
            _value = value;
            ValuesValidation(ref _value);
        }
    }

    public object SetValueNoValidation
    {        
        set
        {
            _value = value;           
        }
    }

    public object SetNewValueNoValidation
    {
        set
        {
            _NewValue = value;
        }
    }

    public object NewValue
    {
        get { return _NewValue; }
        set
        {
            _NewValue = value;
            ValuesValidation(ref _NewValue);
        }
    }

    public SqlDbType DBDataType
    {
        get { return _DBDataType; }
        set { _DBDataType = value; }
    }

    public string DBColumnName
    {
        get { return _DBColumnName; }
        set { _DBColumnName = value; }
    }

    public object MaxValue
    {
        get { return _maxValue; }
        set { _maxValue = value; }
    }

    public object MinValue
    {
        get { return _minValue; }
        set { _minValue = value; }
    }

    public string DisplayName
    {
        get { return _DisplayName; }
        set { _DisplayName = value; }
    }

    public bool IsUnique
    {
        get { return _isUnique; }
        set { _isUnique = value; }
    }

    private void ValuesValidation(ref object pValue)
    {
        try
        {
            _isValid = true;
            _message = "";
            if (_cmmFuction.IsNullOrEmpty(pValue))
            {
                if (!_cmmFuction.IsNullOrEmpty(_defaultValue))
                {
                    pValue = _defaultValue;
                }
                else if (!_isAutoIncrease && !_isNullable)
                {
                    _isValid = false;
                    _message = "'" + _DisplayName + "' is required.";
                }
            }
            else
            {
                string strError = "";
                switch (_sysDataType)
                {
                    case ETT_SystemDataType.Bool:
                        _isValid = _cmmFuction.IsBool(pValue);
                        strError = "bool ";
                        break;
                    case ETT_SystemDataType.Int:
                        _isValid = _cmmFuction.IsInterger(pValue);
                        strError = "int ";
                        if (_isValid)
                        {
                            if (!_cmmFuction.IsNullOrEmpty(_minValue))
                            {
                                if ((int)pValue < (int)_minValue)
                                {
                                    _isValid = false;
                                    strError += "MinValue ";
                                }
                            }
                            if (!_cmmFuction.IsNullOrEmpty(_maxValue))
                            {
                                if ((int)pValue > (int)_maxValue)
                                {
                                    _isValid = false;
                                    strError += "MaxValue ";
                                }
                            }
                        }
                        break;
                    case ETT_SystemDataType.Double:
                        _isValid = _cmmFuction.IsDouble(pValue);
                        strError = "double ";
                        if (_isValid)
                        {
                            if (!_cmmFuction.IsNullOrEmpty(_minValue))
                            {
                                if ((double)pValue < (double)_minValue)
                                {
                                    _isValid = false;
                                    strError += "MinValue ";
                                }
                            }
                            if (!_cmmFuction.IsNullOrEmpty(_maxValue))
                            {
                                if ((double)pValue > (double)_maxValue)
                                {
                                    _isValid = false;
                                    strError += "MaxValue ";
                                }
                            }
                        }
                        break;
                    case ETT_SystemDataType.DateTime:
                        _isValid = _cmmFuction.IsDateTime(pValue);
                        strError = "DateTime ";
                        if (_isValid)
                        {
                            if (!_cmmFuction.IsNullOrEmpty(_minValue))
                            {
                                if ((DateTime)pValue < (DateTime)_minValue)
                                {
                                    _isValid = false;
                                    strError += "MinValue ";
                                }
                            }
                            if (!_cmmFuction.IsNullOrEmpty(_maxValue))
                            {
                                if ((DateTime)pValue > (DateTime)_maxValue)
                                {
                                    _isValid = false;
                                    strError += "MaxValue ";
                                }
                            }
                        }
                        break;
                }
                if (IsValid)
                {
                    if (_minLength > -1)
                    {
                        if (pValue.ToString().Length < _minLength)
                        {
                            _isValid = false;
                            strError += "MinLength ";
                        }
                    }
                    if (_maxLength > -1)
                    {
                        if (pValue.ToString().Length > _maxLength)
                        {
                            _isValid = false;
                            strError += "MaxLength ";
                        }
                    }
                }
                if (!_isValid)
                {
                    _message = "'" + _DisplayName + "' was input incorrect data." + "(" + strError + ")";
                }
            }
        }
        catch (Exception)
        {           
            throw;
        }
    }

}