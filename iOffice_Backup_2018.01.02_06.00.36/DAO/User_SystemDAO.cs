using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using iOffice.DTO;
using System.Text;
using System.Security.Cryptography;
namespace iOffice.DAO
{
    public class User_SystemDAO
    {
       static iOfficeDataContext db = new iOfficeDataContext();
       public static Users_System KiemTraUSer(string pUserID, int pSystemID, string pSessionID)
       {
           try
           {
               var list = db.Users_Systems.Where(p => p.SystemID == pSystemID && p.UserID == pUserID && p.SessionID == pSessionID);
               return list.SingleOrDefault();
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public static bool CapNhatID(string pUserID, int pSystemID, string pSessionID)
       {
           try
           {
               Users_System user = new Users_System();
               user.SystemID = pSystemID;
               user.UserID = pUserID;
               user.SessionID = pSessionID;
               db.SubmitChanges();
               return true;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}