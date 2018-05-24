using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using iOffice.Share;
using iOffice.DTO;
namespace iOffice
{
    /// <summary>
    /// Summary description for MyPhoto
    /// </summary>
    public class MyPhoto : IHttpHandler
    {
      static  iOfficeDataContext db = new iOfficeDataContext();

        public void ProcessRequest(HttpContext context)
        {
            //string id = context.Request.QueryString["USERID"];
           // string str = Request.QueryString.Get("USERID");
            try
            {
                string id = context.Request.QueryString.Get("USERID");
                string macongty = "LTY";
                context.Response.ContentType = "image/jpeg";
                Stream strm = ShowEmpImage(id,macongty);
                byte[] buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);
                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }
            }
            catch (Exception)
            {
                
            }
        }
        public Stream ShowEmpImage(string id,string macongty)
        {
            try
            {
                var r = (from a in db.Busers2s where a.USERID == id && a.GSBH==macongty select a).First();
                return new MemoryStream(r.signatue.ToArray());
            }
            catch (Exception)
            {
                return null;
            }
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