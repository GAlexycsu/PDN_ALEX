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
namespace iOffice.presentationLayer
{
    public partial class FrmQuenmatkhauxetduyet : LanguegeBus
    {
        private Busers2 nv = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDUser = (string)Request["UserID"];
            string cty = (string)Request["congty"];
            string lang = (string)Request["languege"];
            if (IDUser != null && cty != null && lang != null)
            {
                Session["UserID"] = IDUser;
                Session["user"] = IDUser;
                Session["congty"] = cty;
                Session["languege"] = lang;
            }
            string UserID = (string)Session["UserID"];
            string user = (string)Session["UserID"];
            if (user == null || UserID == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
           
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            txtUserID.Text = manguoidung;
            DropCongTy.SelectedValue = macongty;
            Busers2 nguoidung = UserDAO.TimNhanVienTheoMa(manguoidung, macongty);
            if (nguoidung != null)
            {
                txtEmail.Text = nguoidung.EMAIL;
            }
            else
            {
                return;
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(28, strNgonngu);
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

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string ngonngu = Session["languege"].ToString();
                string macongty = DropCongTy.SelectedValue.ToString();
                nv = UserDAO.NVQuenMatKhau(txtUserID.Text, txtEmail.Text,macongty, true);


                if (isValidEmail(txtEmail.Text) == false)
                {
                   
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao.Text = "Email nhập không đúng định dạng";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao.Text = "邮箱地址不正确。请重新输入";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao.Text = "Email is invalid";
                    }
                }
                if (isValidEmail(txtEmail.Text) == true)
                {

                    String noidung1 = "Chào: "+nv.USERNAME +"\n";
                    noidung1 = "Mã bảo mật của bạn đã được hệ thống xử lý.\n";
                    noidung1 += "- Mã bảo mật xét duyệt của bạn là: " + libraly.Decryption(nv.Password2.ToString()) + "\n";
                    noidung1 += "Bạn hãy thay đổi lại Mã bảo mật để an toàn cho tài khoản trong lần đăng nhập lần sau bằng Mã bảo mật trên";

                    String noidung2 = "你好: " + nv.USERNAME + "\n";
                    noidung2 += "系统正在处理您的保密编号.";
                    noidung2 += "- 您的审核保密编号是: " + libraly.Decryption(nv.Password2.ToString()) + "\n";
                    noidung2 += "为保密您的账号，请输入以上保密编号";

                    String noidung3 = "Hello: "+nv.USERNAME+"\n";
                    noidung3 = "Your security code has been processing system.";
                    noidung3 += "- Your Security Code is: " + libraly.Decryption(nv.Password2.ToString()) + "\n";
                    noidung3 += "You change your security code again to the safety of the account in security code";

                    if (nv == null)
                    {
                      
                        if (ngonngu == "lbl_VN")
                        {
                            lbThongBao.Text = "Công ty,tên đăng nhập hoặc Email nhập không đúng. Vui lòng nhập lại";
                        }
                        else if (ngonngu == "lbl_TW")
                        {
                            lbThongBao.Text = "公司名称，登入名称，密码有错误";
                        }
                        else if (ngonngu == "lbl_EN")
                        {
                            lbThongBao.Text = "Company, User ID or Email is invalid";
                        }
                    }
                    else
                    {


                        if (ngonngu == "lbl_VN")
                            {
                                 Until.SendMailss(txtEmail.Text, "[Thông báo]Yêu cầu quên Mật khẩu",noidung1 , null);
                                 lbThongBao2.Text="Mã bảo mật đã được gởi về Email của bạn, vui lòng kiểm tra Email";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                 Until.SendMailss(txtEmail.Text, "[Notify] requirement forget security code",noidung2 , null);
                                lbThongBao2.Text="保密编号已经寄到您的邮箱，请检查邮箱";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                 Until.SendMailss(txtEmail.Text, "[Notify] requirement forget security code", noidung3, null);
                                 lbThongBao2.Text = "Password has been sent to your email, please check email";
                            }

                        
                    }
                   
                }

            }

            catch (Exception)
            {
              // loi dau loi dau
                throw;
            }
            btnSendMail.Enabled = false;
        }

        protected void btnnHuy_Click(object sender, EventArgs e)
        {
            //string user = (string)Session["user"];

            //string cty = (string)Session["congty"];
            //if (user == null)
            //{
            //    Response.Redirect("http://portal.footgear.com.vn/");
            //}
            //else
            //{
            //    Busers2 nguoidung = UserDAO.TimNhanVienTheoMa(user, cty);
            //    if (nguoidung != null && nguoidung.Admin == true)
            //    {
            //        Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
            //    }
            //    else
            //    {
            //        if (nguoidung != null && nguoidung.isSep == true)
            //        {
            //            Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
            //        }
            //        else
            //        {
            //            if (nguoidung.BADEPID == "VTY0501D")
            //            {
            //                Response.Redirect("~/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx");
            //            }
            //            else
            //            {
            //                Response.Redirect("~/presentationLayer/Users/Home.aspx");
            //            }
            //        }
            //    }
            //}
            string UserID = Session["UserID"].ToString();
            string congty = Session["congty"].ToString();
            string languege = Session["languege"].ToString();
            //Response.Redirect("http://portal.footgear.com.vn/pageMain.aspx" + "?UserID=" + UserID + "&congty=" + congty + "&languege=" + languege);
            Response.Redirect("~/presentationLayer/pageMain2.aspx");
        }
    }
}