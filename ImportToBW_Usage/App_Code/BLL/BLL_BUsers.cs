using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for BLL_BUsers
/// </summary>
public class BLL_BUsers
{
    DAL_Busers _dal = new DAL_Busers();
	public BLL_BUsers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetUserByID(string UserID, string Company)
    {
        try
        {
            return _dal.GetUserByID(UserID, Company);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public DataTable GetUserLogin(string UserID, string Company, string Password)
    {
        try
        {
            return _dal.GetUserLogin(UserID, Company, Password);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}