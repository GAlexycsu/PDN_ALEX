using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iOffice.DTO;
namespace iOffice.Share
{
    public class Data
    {
        iOfficeDataContext db = new iOfficeDataContext();
        public Data()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        // ham dang nhap
        public String getusername(string id)
        {

            //st_GetidResult user = sdata.st_Getid(id).FirstOrDefault();
           // var list=from q in db.Busers.Where(q=>q.USERID==id).FirstOrDefault();
            GetIDUserResult user = db.GetIDUser(id).FirstOrDefault();
            return user.USERNAME;

        }
        public String getadmin(string id)
        {

            GetIDUserApprovalResult userapp = db.GetIDUserApproval(id).FirstOrDefault();
            return userapp.USERNAME;
        }
    }
}