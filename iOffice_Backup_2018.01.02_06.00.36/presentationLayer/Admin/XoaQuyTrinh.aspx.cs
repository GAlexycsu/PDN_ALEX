using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
namespace iOffice.presentationLayer.Admin
{
    public partial class XoaQuyTrinh : System.Web.UI.Page
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
            }
            string str = Request.QueryString.Get("IDQuyTrinh");
            int idquytrinh = int.Parse(str);
            QPDNFlow quytrinh = db.QPDNFlows.Where(p => p.IDQuyTrinh == idquytrinh).FirstOrDefault();
            db.QPDNFlows.DeleteOnSubmit(quytrinh);
            db.SubmitChanges();
            Response.Redirect("FQPDNFlow.aspx");
        }
    }
}