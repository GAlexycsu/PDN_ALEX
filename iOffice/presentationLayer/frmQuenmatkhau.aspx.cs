using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using iOffice.Share;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using System.Configuration;
namespace iOffice.presentationLayer
{
    public partial class frmQuenmatkhau : LanguegeBus
    {
        public bool flag = false;
        private Busers2 nv = null;
        string alink = ConfigurationManager.AppSettings["SetupLink"].ToString();
        string linkWebPortal = ConfigurationManager.AppSettings["WebPortal"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

             //Response.Redirect("~/presentationLayer/frmQuenmatkhau.aspx");
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://" + linkWebPortal + "/");
                }
            }

            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(16, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
        }

        public override void GanNgonNguVaoConTrol()
        {
            btnnHuy.Text = hasLanguege["btnnHuy"].ToString();
            btnSendMail.Text = hasLanguege["btnSendMail"].ToString();
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
        //private void luachon()
        //{
        //    try
        //    {
        //        string manguoidung = Session["user"].ToString();
        //        if (flag == true)
        //        {
        //           // this.Context = "Quên mã bảo mật";
        //            txtUserID.Text = manguoidung;
        //            txtUserID.ReadOnly = true;
        //            txtEmail.Focus();
        //        }
        //        else
        //        {
        //            //      this.Text = "Quên Mật Khẩu";
        //            txtUserID.ReadOnly = false;
        //            txtEmail.ReadOnly = false;
        //            txtUserID.Focus();
        //        }
        //    }
            
        //    catch (Exception)
        //    {
        //        // Khong biet lam gi
        //    }
        //}

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string ngonngu = Session["languege"].ToString();
                string macongty = DropCongTy.SelectedValue.ToString();
                nv = UserDAO.NVQuenMatKhau(txtUserID.Text, txtEmail.Text,macongty, true);
                if (nv != null)
                {
                    String noidung1 = "Chào: " + nv.USERNAME + "\n";
                    noidung1 = "Mã bảo mật của bạn đã được hệ thống xử lý.\n";
                    noidung1 += "- Mã bảo mật của bạn là: " + nv.PWD + "\n";
                    noidung1 += "Bạn hãy thay đổi lại Mã bảo mật để an toàn cho tài khoản trong lần đăng nhập lần sau bằng Mã bảo mật trên";

                    String noidung2 = "你好: " + nv.USERNAME + "\n";
                    noidung2 += "系统正在处理您的保密编号.";
                    noidung2 += "- 您的系统登入保密编号是: " + nv.PWD + "\n";
                    noidung2 += "为保密您的账号，请输入以上保密编号";

                    String noidung3 = "Hello: " + nv.USERNAME + "\n";
                    noidung3 = "Your security code has been processing system.";
                    noidung3 += "- Your Security Code is: " + nv.PWD + "\n";
                    noidung3 += "You change your security code again to the safety of the account in security code";

                    if (isValidEmail(txtEmail.Text) == false)
                    {
                        if (ngonngu == "lbl_VN")
                        {
                            lbThongBao2.Text = "Email nhập không đúng định dạng";
                        }
                        else if (ngonngu == "lbl_TW")
                        {
                            lbThongBao2.Text = "邮箱地址不正确。请重新输入";
                        }
                        else if (ngonngu == "lbl_EN")
                        {
                            lbThongBao2.Text = "Email is invalid";
                        }
                    }
                    if (isValidEmail(txtEmail.Text) == true)
                    {



                        if (nv == null)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBao2.Text = "Công ty,tên đăng nhập hoặc Email nhập không đúng. Vui lòng nhập lại";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBao2.Text = "公司名称，登入名称，密码有错误";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBao2.Text = "Company, User ID or Email is invalid";
                            }

                        }
                        else
                        {


                            if (ngonngu == "lbl_VN")
                            {
                                Until.SendMailss(txtEmail.Text, "[Thông báo]Yêu cầu quên Mật khẩu", noidung1, null);
                                lbThongBao2.Text = "Mã bảo mật đã được gởi về Email của bạn, vui lòng kiểm tra Email";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                Until.SendMailss(txtEmail.Text, "[Notify] requirement forget security code", noidung2, null);
                                lbThongBao2.Text = "保密编号已经寄到您的邮箱，请检查邮箱";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                Until.SendMailss(txtEmail.Text, "[Notify] requirement forget security code", noidung3, null);
                                lbThongBao2.Text = "Password has been sent to your email, please check email";
                            }

                        }
                    }
                }
                else
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao2.Text = "Công ty,tên đăng nhập hoặc Email nhập không đúng. Vui lòng nhập lại";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao2.Text = "公司名称，登入名称，密码有错误";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao2.Text = "Company, User ID or Email is invalid";
                    }
                }
            }
           
            catch (Exception)
            {
                // Khong biet lam gi
                throw;
            }

          
        }
        public bool kiemtradulieu()
        {
            return kiemtranhapEmail() &&  kiemtraTextMaNV();
        }
        public bool kiemtraTextMaNV()
        {
            if (txtUserID.Text.Trim() == null)
            {
                txtUserID.Focus();
                return false;
            }
            return true;
        }
        public bool kiemtranhapEmail()
        {
            if (txtEmail.Text.Trim() == null)
            {
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        protected void btnnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://portal.footgear.com.vn/");
        }
    }
}