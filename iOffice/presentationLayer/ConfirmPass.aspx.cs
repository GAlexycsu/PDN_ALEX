using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace iOffice.presentationLayer
{
    public partial class ConfirmPass : System.Web.UI.Page
    {
        BLL_TheLogib _bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string UserID = (string)Request["UserID"];

                string pass = (string)Request["pass"];

                string emailto = (string)Request["pass"];
                string noidung1 = "- Chào - 你好: " + UserID + "\n";
                noidung1 += "- Mã bảo mật của bạn đã được hệ thống xử lý - 系统正在处理您的保密编号." + "\n";
                noidung1 += "- Mã bảo mật của bạn là - 您的系统登入保密编号是: " + pass + "\n";
                noidung1 += "- Bạn hãy thay đổi lại Mã bảo mật để an toàn cho tài khoản trong lần đăng nhập lần sau bằng Mã bảo mật trên" + "\n";
                noidung1 += "- 为保密您的账号，请输入以上保密编号" + "\n";
              
                string AcctiveCode = _bll.CalculateMD5Hash(UserID + "TheLogin" + pass);
                bool Update = _bll.UpdatePassword(UserID, AcctiveCode);
                if (Update)
                {

                }
            }
        }
    }
}