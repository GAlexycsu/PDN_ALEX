using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    public partial class ShowComentByAuditor1 : System.Web.UI.Page
    {
        string str = "";
        abconDAL dal = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                str = Request.Headers["Action"].ToString();
                switch (str)
                {
                    case "HienThiCommentTheoNguoiDuyet":
                        HienThiCommentTheoNguoiDuyet();
                        break;
                    default:
                        Response.Write("No Comment");
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void HienThiCommentTheoNguoiDuyet()
        {
            string macongty = "LTY";
            string manguoiduyet = Request.Headers["Auditor"].ToString();
            string pdno = Request.Headers["pdno"].ToString();
            DataTable dt = dal.LayComentTheoNguoiDuyet(manguoiduyet, macongty, pdno);
            if (dt.Rows.Count > 0)
            {
                lblComment.Text = dt.Rows[0]["lydokhongduyet"].ToString();
            }
            else
            {
                lblComment.Text = "No Comment";
            }

        }
    }
    
}