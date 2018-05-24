using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace iOffice.presentationLayer
{
    public partial class ExportJob : System.Web.UI.Page
    {
        departDAL dal = new departDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = dal.GetDate1();
                string date = dt.Rows[0]["NgayThang"].ToString();
                DateTime a = DateTime.Parse(date.ToString());
                txtFromDate.Text = a.ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string UserID =(string)Session["UserID"];
            if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "" && UserID!=null)
            {

                Response.Redirect("WF_ReportT.aspx?Type=BaoCaoTuan&UserID=" + UserID + "&FromDate=" + txtFromDate.Text.Trim() + "&ToDate=" + txtToDate.Text.Trim());
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/pageMain3.aspx");
        }
    }
}