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
    public partial class Default : System.Web.UI.Page
    {
        BLL_TheLogib _bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string abc = (string)Request["biennho"];
                //if (abc != null)
                //{
                //    Session["biennho"] = abc.ToString().Trim();
                //}
                //string member = (string)Session["biennho"];
                //if (member == null)
                //{
                //    DropDownLanguege.SelectedValue = "Default";
                //}
                //else
                //{
                //    DropDownLanguege.SelectedValue = member;
                //}

                if (Request.Cookies["UserID"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserID.Text = Request.Cookies["UserID"].Value;
                    txtPassword.Attributes["Password"] = Request.Cookies["Password"].Value;
                    DropDownLanguege.SelectedValue = Request.Cookies["DropLang"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                string ActiveCode = "";
                if (_bll.Login(txtUserID.Text, txtPassword.Text, ref ActiveCode))
                {
                    string ngonngu = DropDownLanguege.SelectedValue.ToString();
                    if (ngonngu == "Default")
                    {
                        Session["languege"] = "lbl_VN";
                    }
                    else
                    {
                        Session["languege"] = ngonngu;
                    }
                    Session["UserID"] = txtUserID.Text.Trim();
                    Session["ActiveCode"] = ActiveCode;
                    Session["user"] = txtUserID.Text.Trim();
                    Session["congty"] = "LTY";
                    //  Response.Redirect("MainPage.aspx");
                    if (checkRemember.Checked == true)
                    {
                        Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["DropLang"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["DropLang"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Cookies["UserID"].Value = txtUserID.Text.Trim();
                    Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                    Response.Cookies["DropLang"].Value = DropDownLanguege.SelectedValue;
                    Response.Redirect("pageMain3.aspx");
                }
                else
                {
                    cv.IsValid = false;
                    cv.ErrorMessage = ActiveCode; //"Login Failed!";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnForgotPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotPassword.aspx");
        }
    }
}