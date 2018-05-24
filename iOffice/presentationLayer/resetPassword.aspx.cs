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
    public partial class resetPassword : System.Web.UI.Page
    {
        BLL_TheLogib _bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string UserID = txtUser.Text.Trim();
            string pass = _bll.CreateRandomPassword();
            string noidung1 = "- Chào - 你好: " + UserID + "\n";
            noidung1 += "- Mã bảo mật của bạn đã được hệ thống xử lý - 系统正在处理您的保密编号." + "\n";
            noidung1 += "- Mã bảo mật của bạn là - 您的系统登入保密编号是: " + pass + "\n";
            noidung1 += "- Bạn hãy thay đổi lại Mã bảo mật để an toàn cho tài khoản trong lần đăng nhập lần sau bằng Mã bảo mật trên" + "\n";
            noidung1 += "- 为保密您的账号，请输入以上保密编号" + "\n";
            string email = "khanh@footgear.com.vn";
            DataTable dtUser = _bll.CheckUser(UserID);
            if (dtUser.Rows.Count > 0)
            {

                string emailto = dtUser.Rows[0]["SEmail"].ToString();

                string AcctiveCode = _bll.CalculateMD5Hash(UserID + "TheLogin" + pass);
                bool Update = _bll.UpdatePassword(UserID, AcctiveCode);
                if (Update)
                {

                    bool sentMail = _bll.SendMailss(email, emailto, "[Notify] requirement forget security code", noidung1);
                    if (sentMail)
                    {
                        lblThongBao.Text = "Sent Successfully";
                    }
                    else
                    {
                        lblThongBao.Text = "Sent Failed";
                    }
                }
            }
            else
            {
                lblThongBao.Text = "Incorect username , please enter again!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/pageMain2.aspx");
        }
    }
}