using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using iOffice.Share;
using iOffice.DTO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.ProcessSignature
{
    /// <summary>
    /// Summary description for MyPhoto8
    /// </summary>
    public class MyPhoto8 : IHttpHandler
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        userDAL dal = new userDAL();
        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString.Get("USERID");
            string macongty = "LTY";
            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowEmpImage(id, macongty);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }   
        }
        public Stream ShowEmpImage(string id, string macongty)
        {

            //var r = (from a in db.Busers2s where a.USERID == id && a.GSBH == macongty select a).First();
            //return new MemoryStream(r.signatue.ToArray());
            DataTable dt = dal.TimNhanVienTheoMa(macongty, id);
            Byte[] image = (Byte[])dt.Rows[0]["signatue"];
            return new MemoryStream(image);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}