using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class WF_Login : System.Web.UI.Page
{
    BLL_BUsers bll = new BLL_BUsers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblThongBao.Text = "";
            if (Request.Cookies["UserID"] != null && Request.Cookies["Password"] != null)
            {
                txtUserID.Text = Request.Cookies["UserID"].Value;
                txtPassword.Attributes["Password"] = Request.Cookies["Password"].Value;
               
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string UserID = txtUserID.Text.Trim();
        string Password = txtPassword.Text.Trim();
        string Company = ConfigurationManager.AppSettings["Company"].ToString();
       
            DataTable dt = bll.GetUserLogin(UserID, Company, Password);
            if (dt.Rows.Count > 0)
            {
                Session["UserID"] = UserID;
                Session["Password"] = txtPassword.Text.Trim();
                if (checkRemember.Checked == true)
                {
                    Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                   
                }
                else
                {
                    Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                   
                }
                Response.Cookies["UserID"].Value = txtUserID.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                Response.Redirect("~/importData.aspx");
            }
            else
            {
                lblThongBao.Text = "User ID or password incorect, please enter again!";
            }
        
    }
    protected void btnForgotPass_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
}