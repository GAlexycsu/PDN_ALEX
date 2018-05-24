using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.Share;

namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmApproval : LanguegeBus
    {
        public string m_IdVanBanHienHanh;

        dalPDN dalpdn = new dalPDN();
        abconDAL dalAbcon = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn/");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(7, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
               
               
                btnDetails.Visible = false;
               
            }
            
           
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnAccep.Text = hasLanguege["btnAccep"].ToString();
            btnCancel.Text = hasLanguege["btnCancel"].ToString();
            btnDetails.Text = hasLanguege["btnDetails"].ToString();
            rdApproval.Text = hasLanguege["rdApproval"].ToString();
            rdNotApproval.Text = hasLanguege["rdNotApproval"].ToString();
            btnPause.Text = hasLanguege["btnPause"].ToString();
            rdNotYetAroval.Text = hasLanguege["rdNotYetAroval"].ToString();
        }
       
        protected void btnAccep_Click(object sender, EventArgs e)
        {
            try
            {
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                string ngonngu=Session["languege"].ToString();
                string manguoidung = Session["user"].ToString();
                Busers2 KiemTraMatKhau=UserDAO.KiemTraMatKhauXetDuyetCuaNguoiDuyet(manguoidung,macongty,libraly.Encryption(txtSecure.Text));
                if(KiemTraMatKhau==null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao.Text = "Mật khẩu là không chính xác";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao.Text = "密码不正确";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao.Text = "The password is incorrect";
                    }
                }
                else
                {
                Busers2 user = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
                //string abc = libraly.Encryption(txtSecure.Text);
                if (user != null && libraly.Encryption(txtSecure.Text).Equals(user.Password2))
                {
                    bool duyet = (rdApproval.Checked) ? true : ((rdNotApproval.Checked) ? false : true);
                    string ghichu = txtComment.Text;
                    //Task temp = Task.Factory.StartNew(() => Until.XetDuyet(maphieu, Until.uNhanVien, duyet, ghichu));
                    //{
                    //    if (temp != null)
                    //    {
                    //        lbThongBao.Text = "Approval success";

                    //    }
                    //}

                    //  temp.RunSynchronously();
                    //Task temp = Task.Factory.StartNew(() => Until.XetDuyet(maphieu, Until.uNhanVien, duyet, ghichu));
                    Until.XetDuyet(maphieu, user, duyet, ghichu,macongty);
                    // kiem tra : lay chi tiet theo nguoi duyet neu   nguoi.abresult==true  di qua trang khac nguoc lai khong xet duyet
                    Abcon chitietduyet = AbconBUS.LayChiTietXetDuyetTheoNhanVienDuyet(maphieu, manguoidung);
                  
                    if (chitietduyet == null)
                    {
                        return;
                    }
                    else
                    {
                        if (chitietduyet.abrult == true)
                        {
                            if (ngonngu == "lbl_VN")
                            {
                                lbThongBao.Text = "Bạn đã xét duyệt thành công";
                            }
                            else if (ngonngu == "lbl_TW")
                            {
                                lbThongBao.Text = "审核成功";
                            }
                            else if (ngonngu == "lbl_EN")
                            {
                                lbThongBao.Text = "Approval Success!";
                            }
                            if (chitietduyet.abtype == "PDN2")
                            {
                                Response.Redirect("phieumuahangD.aspx");
                            }
                            else
                            {
                                Response.Redirect("frmDetails2D.aspx");
                            }
                        }
                        else
                        {
                            if (chitietduyet.Yn == 2)
                            {
                                if (ngonngu == "lbl_VN")
                                {
                                    lbThongBao.Text = "Bạn đã không xét duyệt phiếu này";
                                }
                                else if (ngonngu == "lbl_TW")
                                {
                                    lbThongBao.Text = "本单未审核";
                                }
                                else if (ngonngu == "lbl_EN")
                                {
                                    lbThongBao.Text = "Not Approval ";
                                }
                                if (chitietduyet.abtype == "PDN2")
                                {
                                    Response.Redirect("phieumuahangD.aspx");
                                }
                                else
                                {
                                    Response.Redirect("frmDetails2D.aspx");
                                }
                            }
                        }

                    }
                }
               }
              //  Response.Redirect("frmDetails2.aspx");
            }
            catch (Exception ex)
            {
                lbthongbaoLoi.Text = "loi" + ex.Message;
            }
           // Response.Redirect("frmDetails2.aspx");
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            string maloaiphieu = (string)Session["maloaiphieu"];
            if (maloaiphieu != null && maloaiphieu == "PDN2")
            {
                Response.Redirect("phieumuahangD.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2D.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachVanBanDen.aspx");
        }

        protected void rdNotYetAroval_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNotYetAroval.Checked == true)
            {
                btnAccep.Enabled = false;
                btnCancel.Enabled = false;
                btnCancel.Attributes.CssStyle.Add("opacity", "0.5");
                btnAccep.Attributes.CssStyle.Add("opacity", "0.5");
            }
            else
            {
                btnAccep.Enabled = true;
                btnCancel.Enabled = true;
                btnCancel.Attributes.CssStyle.Add("opacity", "100");
                btnAccep.Attributes.CssStyle.Add("opacity", "100");
            }
        }

        protected void btnPause_Click(object sender, EventArgs e)
        {
            btnAccep.Enabled = false;
            btnCancel.Enabled = false;
            btnCancel.Attributes.CssStyle.Add("opacity", "0.5");
            btnAccep.Attributes.CssStyle.Add("opacity", "0.5");
            int Yn = 12;
            string macongty = Session["congty"].ToString();
            string maphieu = Session["maphieu"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            try
            {
                dalpdn.CapNhatPhanHoiCuaNguoiDuyetTheoPhieu(maphieu, macongty, txtComment.Text.Trim(),manguoidung, Yn);
                dalAbcon.CapNhatYKienPhanHoi(maphieu, macongty, Yn, manguoidung, txtComment.Text.Trim());
                if (ngonngu == "lbl_VN")
                {
                    lbThongBao.Text = " Gửi ý kiến  thành công";
                }
                Response.Redirect("DanhSachVanBanDen.aspx");
            }
            catch
            {
                if (ngonngu == "lbl_VN")
                {
                    lbThongBao.Text = " Gửi ý kiến Không thành công";
                }
            }
        }
    }
}