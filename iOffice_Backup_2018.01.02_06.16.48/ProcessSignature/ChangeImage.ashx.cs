using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.ProcessSignature
{
    /// <summary>
    /// Summary description for ChangeImage
    /// </summary>
    public class ChangeImage : IHttpHandler
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
            //string macongty = "LTY";
            //HttpRequest req = context.Request;
            //// string categoryID = "1";
            //string categoryID = req.QueryString["USERID"].ToString();
            //// Get information about the specified category
           
            //var category = from c in db.Busers2s
            //               where c.USERID == categoryID && c.GSBH==macongty
            //               select c.signatue;
            //int len = category.First().Length;
            //// Output the binary data
            //// But first we need to strip out the OLE header
            //int OleHeaderLength = 78;
            //int strippedImageLength = len - OleHeaderLength;
            //byte[] imagdata = new byte[strippedImageLength];
            //Array.Copy(category.First().ToArray(), OleHeaderLength, imagdata, 0, strippedImageLength);
            //if ((imagdata) != null)
            //{
            //    MemoryStream m = new MemoryStream(imagdata);
            //    System.Drawing.Image image = System.Drawing.Image.FromStream(m);
            //    image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            //}
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