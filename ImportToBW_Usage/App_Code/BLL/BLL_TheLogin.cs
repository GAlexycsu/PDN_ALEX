using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Summary description for BLL_TheLogin
/// </summary>
public class BLL_TheLogin
{
    DAL_TheLogin _dal = new DAL_TheLogin();
	public BLL_TheLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CalculateMD5Hash(string input)
    {
        try
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.Unicode.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public bool Actived(string pUserID, string pSystemID, string pSessionID)
    {
        try
        {
            string HashSessionID = CalculateMD5Hash(pSessionID);
            DataTable dt = _dal.KiemTraID(pUserID, pSystemID, HashSessionID);
            if (dt.Rows.Count > 0)
            {
                int Counted = (int)dt.Rows[0][0];
                if (Counted > 0)
                {
                    _dal.CapNhatID(pUserID, pSystemID);
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
    public DataTable GetUserByIDTheLogin(string UserID)
    {
        try
        {
            return _dal.GetUserByIDTheLogin(UserID);
        }
        catch (Exception)
        {

            throw;
        }
    }
}