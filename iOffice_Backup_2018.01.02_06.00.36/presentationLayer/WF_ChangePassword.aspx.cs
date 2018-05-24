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
    public partial class WF_ChangePassword : System.Web.UI.Page
    {
        BLL_TheLogib _bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UserID = (string)Session["UserID"];
                if (UserID == null)
                {
                    Response.Redirect("http://portal.footgear.com.vn/");
                }
                else
                {
                    txtUserName.Text = UserID;
                }
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string UserID = txtUserName.Text.Trim();
                string Pass = txtOldPass.Text.Trim();
                string pAcctiveCode = _bll.CalculateMD5Hash(UserID + "TheLogin" + Pass);
                string pAcctiveCode1 = _bll.CalculateMD5Hash(UserID + "TheLogin" + txtNewPass.Text.Trim());
                DataTable dt = _bll.CheckLogin(UserID, pAcctiveCode);
                if (dt.Rows.Count > 0)
                {
                    bool Update = _bll.UpdatePassword(UserID, pAcctiveCode1);
                    if (Update)
                    {
                        lblThongBao.Text = "Password changed Successfully";
                    }
                    else
                    {
                        lblThongBao.Text = "Password changed Failed";
                    }
                }
                else
                {
                    lblThongBao.Text = "Invalid Password Old";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain2.aspx");
        }
    }
}