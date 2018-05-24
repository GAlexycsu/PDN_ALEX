using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.BUS
{
    public class User_SystemBUS
    {
        User_SystemDAO _dll = new User_SystemDAO();
        public static string CalculateMD5Hash(string input)
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
        public static bool Actived(string pUserID, int pSystemID, string pSessionID)
        {
            try
            {
                string HashSessionID = CalculateMD5Hash(pSessionID);
                Users_System system = User_SystemDAO.KiemTraUSer(pUserID, pSystemID, HashSessionID);
                if (system != null)
                {
                    User_SystemDAO.CapNhatID(pUserID, pSystemID, pSessionID);
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
    }
}