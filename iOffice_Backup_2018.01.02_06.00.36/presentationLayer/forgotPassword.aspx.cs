using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace iOffice.presentationLayer
{
    public partial class forgotPassword : System.Web.UI.Page
    {
        BLL_TheLogib _bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string UserID = txtUser.Text.Trim();
            string pass = _bll.CreateRandomPassword();
            //string email=txtEmail.Text.Trim();
            string noidung1 = "- Notify : " + UserID + " requirement forgot security code" + "\n";

            string emailto = "khanh@footgear.com.vn";
            DataTable dtUser = _bll.CheckUser(UserID);
            if (dtUser.Rows.Count > 0)
            {

                string email = dtUser.Rows[0]["SEmail"].ToString();
                // string link = "<a href=\"http://portal.footgear.com.vn/ConfirmPass.aspx" + "?UserID=" + "" + UserID + "" + "&pass=" + "" + pass + "" + "&email=" + "" + email+ "\"> Xác nhận</a>" + "<br />";
                //string link = "<a href=\"http://localhost:7671/ConfirmPass.aspx" + "?UserID=" + "" + UserID + "" + "&pass=" + "" + pass + "" + "&email=" + "" + email + "\"> Xác nhận</a>" + "<br />";
                string AcctiveCode = _bll.CalculateMD5Hash(UserID + "TheLogin" + pass);

                noidung1 += "New Password: " + pass;
                bool sentMail = _bll.SendMailss(email, emailto, "[Notify] requirement forget security code", noidung1);
                if (sentMail)
                {
                    bool update = _bll.UpdatePassword(UserID, AcctiveCode);
                    if (update)
                    {
                        lblThongBao.Text = "Sent Successfully";
                    }
                }
                else
                {
                    lblThongBao.Text = "Sent Failed";
                }

            }
            else
            {
                lblThongBao.Text = "Incorect username , please enter again!";
            }
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}