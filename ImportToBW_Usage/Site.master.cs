using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string manguoidung = (string)Session["UserID"];
            if (manguoidung == null)
            {
                Response.Redirect("WF_Login.aspx");
            }
            else
            {
                lblName.Text = manguoidung;
            }

        }
    }
    protected void LinkHome_Click(object sender, EventArgs e)
    {
        string UserID = (string)Session["UserID"];
        if (UserID != null)
        {
            Response.Redirect("importData.aspx");
        }
    }
}
