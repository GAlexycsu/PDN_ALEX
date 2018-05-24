﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.Share;
namespace iOffice.presentationLayer
{
    public partial class frmDoiMatKhau : LanguegeBus
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
           string macongty= Session["congty"].ToString();
           string manguoidung = Session["user"].ToString();
           txtUserID.Text = manguoidung;
           DropCongTy.SelectedValue = macongty;
           string strNgonngu = (string)Session["languege"];
           if (strNgonngu != null)
           {
               LayngonNgu(11, strNgonngu);
           }
           else
           {
               Response.Redirect("http://portal.footgear.com.vn");
           }
            GanNgonNguVaoConTrol();
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
           // Buser nv = Until.uNhanVien;
            string macongty=DropCongTy.SelectedValue.ToString();
            if (txtPassNew.Text.Length < 6 && txtConfirmPass.Text.Length < 6)
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    lbThongBao.Text = "Độ dài của mật khẩu phải lớn hơn 6 ký tự";
                }
                else if (ngonngu == "lbl_TW")
                {
                    lbThongBao.Text = "密码的长度必须大于6个字符";
                }
                else if (ngonngu == "lbl_EN")
                {
                    lbThongBao.Text = " The password must be greater than six characters!";
                }
               

                return;
            }
            if (txtPassNew.Text != txtConfirmPass.Text)
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    lbThongBao.Text = "Mật khẩu và xác nhận mật khẩu không trùng nhau, vui lòng nhập lại";
                }
                else if (ngonngu == "lbl_TW")
                {
                    lbThongBao.Text = "密码和确认密码不匹配，请重新输入!";
                }
                else if (ngonngu == "lbl_EN")
                {
                    lbThongBao.Text = " Password and confirm password do not match, Please re-enter!";
                }
               
                return;
            }

           
                try
                {
                    Busers2 nv = UserBUS.KiemTraDangNhap(txtUserID.Text, txtPassOld.Text, macongty, true);
                    
                    if (nv != null)
                    {
                        if (UserBUS.ThayDoiMatKhau(txtUserID.Text, txtPassOld.Text, txtPassNew.Text,macongty, true))
                        {
                            //Program.client.WriteFileLog(Program.ipClient + "\t" + Util.uNhanVien.HoTen + "\tThay đổi mật khẩu\t\tThành công.");
                            

                            string ngonngu = Session["languege"].ToString();
                            if (ngonngu == "lbl_VN")
                            {
                                lblthongbaothanhcong.Text = "Thay đổi mật khẩu thành công";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lblthongbaothanhcong.Text = "成功修改密码!";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lblthongbaothanhcong.Text = " Change the password successfully";
                            }
               
                        }
                        else
                        {
                           
                            string ngonngu = Session["languege"].ToString();
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBao.Text = "Không thể thay đổi được mật khẩu";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBao.Text = "不能更改密码!";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBao.Text = " Cannot change is a password";
                            }
                            return;
                        }
                    }
                    else
                    {
                        Busers2 timnv = UserDAO.TimNhanVienTheoMa(txtUserID.Text, macongty);
                        if (timnv == null)
                        {
                            
                            string ngonngu = Session["languege"].ToString();
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBao.Text = "Sai Tên đăng nhập, mật khẩu hoặc công ty";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBao.Text = "公司名称，登入名称，密码有错误";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBao.Text = " Wrong login name, password, or company";
                            }
                        }
                        else
                        {

                            string ngonngu = Session["languege"].ToString();
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBao.Text = "Sai Tên đăng nhập, mật khẩu hoặc công ty";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBao.Text = "公司名称，登入名称，密码有错误";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBao.Text = " Wrong login name, password, or company";
                            }
                        }
                        return;
                    }
                }
                
                catch (Exception)
                {
                    // Khong biet lam gi
                }
           
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {

            
            string user = (string)Session["user"];

            string cty = (string)Session["congty"];
            if (user == null)
            {
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            else
            {
                Busers2 nguoidung = UserDAO.TimNhanVienTheoMa(user, cty);
                if (nguoidung != null && nguoidung.Admin == true)
                {
                    Response.Redirect("~/presentationLayer/Admin/frmAddUsers.aspx");
                }
                else
                {
                    if (nguoidung != null && nguoidung.isSep == true)
                    {
                        Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
                    }
                    else
                    {
                        if (nguoidung.BADEPID == "VTY0501D")
                        {
                            Response.Redirect("~/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/presentationLayer/Users/Home.aspx");
                        }
                    }
                }
            }
           
        }
        public override void GanNgonNguVaoConTrol()
        {
            try
            {
                btnChangePass.Text = hasLanguege["btnChangePass"].ToString();
                btnHuy.Text = hasLanguege["btnHuy"].ToString();
                
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}