using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonFunction
/// </summary>
public class CommonFunction
{
	public CommonFunction()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public  bool IsNullOrEmpty(object obj)
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