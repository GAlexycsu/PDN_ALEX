using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
namespace iOffice.SiteMater
{
    public partial class MasterPage2 : System.Web.UI.MasterPage
    {
        userDAL dalUser = new userDAL();
        string macongty = ConfigurationManager.AppSettings["Congty"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string UserID = (string)Session["UserID"];
                if (UserID == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    DataTable dtUs = dalUser.TimNhanVienTheoMa(macongty, UserID);
                    if (dtUs.Rows.Count > 0)
                    {
                        lblNhanVien.Text = dtUs.Rows[0]["USERNAME"].ToString();
                    }
                }
            }
        }

        protected void linkMyProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("WF_Projectm.aspx");
        }

        protected void linkProjectShare_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectShareByUser.aspx");
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain3.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("maphieu");
            Session.Remove("ktmaphieu");
            Session.Remove("congty");
            Session.Remove("user");
            Session.Remove("UserID");
            //string langue = Session["languege"].ToString();
            //Response.Redirect("http://portal.footgear.com.vn/?biennho="+langue);
            //Response.Redirect("http://"+linkWebPortal+"/");
            //  Response.Redirect("Default");
            Response.Redirect("~/presentationLayer/Default.aspx");
        }
    }
}