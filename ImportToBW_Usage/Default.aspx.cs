using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = (string)Request["UID"];
            if (id == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            string company = ConfigurationManager.AppSettings["Company"].ToString();
            string ID = Request["ID"].ToString();
            string SID = Request["SID"].ToString();
            string UID = Request["UID"].ToString();
            BLL_TheLogin _bllLogin = new BLL_TheLogin();
            BLL_BUsers _bllBusers = new BLL_BUsers();
            bool Actived = _bllLogin.Actived(UID, SID, ID);
            if (Actived)
            {
                DataTable dt = _bllBusers.GetUserByID(UID, company);
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"] = UID;

                    Response.Redirect("~/importData.aspx");
                }
                else
                {

                    DataTable ddt = _bllLogin.GetUserByIDTheLogin(UID);
                    if (ddt.Rows.Count > 0)
                    {
                        Session["UserID"] = UID;
                        Response.Redirect("~/importData.aspx");
                    }
                    else
                    {
                        Response.Redirect("http://portal.footgear.com.vn/");
                    }
                }
            }
        }
        if (!IsPostBack)
        {

            Response.Redirect("~/importData.aspx");
        }
    }
}
