using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using System.Data;
using System.Configuration;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class feedback : System.Web.UI.Page
    {
        static iOfficeDataContext db=new iOfficeDataContext();
        userDAL dal = new userDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  Div2.Visible = true;
                HienThiDiv();
               
            }
            
        }
       
        private void HienThiDiv()
        {
            if (RadioSendCreater.Checked == true)
            {
                Div2.Visible = true;
                Div1.Visible = false;
            }
            else
            {
                if (RadioSendTranslator.Checked == true)
                {
                    Div2.Visible = false;
                    Div1.Visible = true;
                    HienThiNguoiDich();
                }
            }
        }
        private void HienThiNguoiDich()
        {
           
            string ngonngu = Session["languege"].ToString();
            //DropDownNguoiDich.DataSource = NguoiDichDAO.QryNguoiDich();
            //DropDownNguoiDich.DataValueField = "USERID";
            string congty = Session["congty"].ToString();
            string donvi=ConfigurationManager.AppSettings["DepartIDPD"].ToString();
            DataTable dt = dal.QryNguoiDich(congty, donvi);
            if (dt.Rows.Count > 0)
            {
                DropDownNguoiDich.DataSource = dt;
                DropDownNguoiDich.DataValueField = "USERID";
                if (ngonngu == "lbl_VN")
                {
                    DropDownNguoiDich.DataTextField = "USERNAME";
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDownNguoiDich.DataTextField = "USERNAMETW";
                }
            }
            DropDownNguoiDich.DataBind();
        }
        protected void RadioSendCreater_CheckedChanged(object sender, EventArgs e)
        {
            HienThiDiv();
            HienThiThongTin();
        }
        private void HienThiThongTin()
        {
            if (RadioSendTranslator.Checked == true)
            {
                string ngonngu = Session["languege"].ToString();
                DropDownNguoiDich.DataSource = NguoiDichDAO.QryNguoiDich();
                DropDownNguoiDich.DataValueField = "USERID";

                if (ngonngu == "lbl_VN")
                {
                    DropDownNguoiDich.DataTextField = "TenNguoiDich";
                }
                else if (ngonngu == "lbl_TW")
                {
                    DropDownNguoiDich.DataTextField = "TenNguoiDichTiengHoa";
                }
                else if (ngonngu == "lbl_EN")
                {
                    DropDownNguoiDich.DataTextField = "TenNguoiDich";
                }
                DropDownNguoiDich.DataBind();

                
            }
            else
            {
                string manguoitao = Session["manguoitao"].ToString();
                string congty = Session["congty"].ToString();
                Busers2 nhanvientao = UserBUS.TimMaNhanVienTaoPhieu(manguoitao, congty);
                if (nhanvientao != null)
                {
                    txtEmail.Text = nhanvientao.EMAIL;
                    txtUser.Text = nhanvientao.USERNAME;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
               // string maloai = Session["loaiphieu"].ToString();
                string phieu = Session["maphieu"].ToString();
              
                string idnguoidich=DropDownNguoiDich.SelectedValue.ToString();
                string congty = Session["congty"].ToString();
                string user = Session["user"].ToString();


                pdna kiemtra = pnaDAO.TimVanBanTheoMa(phieu, congty);
            
                    if ( kiemtra!=null && kiemtra.trangthaidich == false && kiemtra.YN==6)
                    {
                        //string ngonngu = Session["languege"].ToString();
                        //if (ngonngu == "lbl_VN")
                        //{
                        //    LbThongBao.Text = "Phiếu đã được gửi đến người dịch";
                        //}
                        //else if (ngonngu == "lbl_TW")
                        //{
                        //    LbThongBao.Text = "资料已经转送翻译成中文（越文）。请巡查名单";
                        //}
                        //else if (ngonngu == "lbl_EN")
                        //{
                        //    LbThongBao.Text = "Phiếu đã được gửi đến người dịch";
                        //}
                    }
                    else
                    {
                        pdna phieun = new pdna();
                        phieun.GSBH = congty;
                        phieun.pdno = phieu;
                       
                        phieun.trangthaidich = false;
                       
                        db.CapNhaPhieuGuiNguoiKhacDich(phieun.pdno,phieun.GSBH,idnguoidich,phieun.trangthaidich);
                    }
                
               // pdna layvanban = pdnaBUS.LayVanBanDaGuiDenNguoiDuyetTheoNGuoiTrinhDuyet(phieu, manguoiduyet, congty);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieu + "'and GSBH='" + congty + "' and CFMID0='" + idnguoidich + "'"));
                    var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieu + "'and GSBH='" + congty + "' and CFMID0='" + idnguoidich + "'");
                if (list == null)
                {
                    //LbThongBao.Text = "Lỗi không thể gửi được đến người cần dịch. Xin liên hệ bộ phận IT";
                    string ngonngu = Session["languege"].ToString();
                    if (ngonngu == "lbl_VN")
                    {
                        LbThongBao.Text = "Lỗi không thể gửi được đến người cần dịch. Xin liên hệ bộ phận IT";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        LbThongBao.Text = "Error! ";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        LbThongBao.Text = "Error can not be sent to people who need services. Please contact the IT department";
                    }
                }
                else
                {
                    Busers2 nhanvientao = UserDAO.TimNhanVienTheoMa(user, congty);
                    Busers2 nhanviendich = UserBUS.TimMaNhanVienDich(idnguoidich, congty);
                    if (nhanvientao != null && nhanviendich != null)
                    {
                        string ngonngu = Session["languege"].ToString();
                        String noidung2 = "Chào anh/chị. Tôi có 1 phiếu nhờ anh/chị dịch giúp với";
                        noidung2 += "- Mã văn bản: " + kiemtra.pdno + "\n";
                        noidung2 += "- Tiêu đề: " + kiemtra.mytitle + "\n";

                        noidung2 += "- Ngày tạo: " + kiemtra.CFMDate0.Value.ToShortDateString() + "\n";
                        noidung2 += "- Người nhờ dịch: " + nhanvientao.USERNAME + "\n";
                        //noidung2 += "Click on link " + "http://192.168.11.8/pdn/presentationLayer/NguoiDich/danhsachphieuchuadich.aspx";
                        Until.SendMailNguoiDich(nhanvientao.EMAIL, nhanviendich.EMAIL, "[Ty Hung-eOffice] Thông báo có phiếu cần dịch ", noidung2,nhanviendich.USERID,congty,ngonngu);
                        
                        
                        if (ngonngu == "lbl_VN")
                        {
                            LbThongBao.Text = "Phiếu đã được gửi đến người dịch";
                        }
                        else if (ngonngu == "lbl_TW")
                        {
                            LbThongBao.Text = "资料已经转送翻译成中文（越文）。请巡查名单";
                        }
                        else if (ngonngu == "lbl_EN")
                        {
                            LbThongBao.Text = "Phiếu đã được gửi đến người dịch";
                        }
                    }
                   
                }
                Button1.Enabled = false;
                Button1.Attributes.CssStyle.Add("opacity", "0.5");
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string congty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string manguoitao = Session["manguoitao"].ToString();
            string maphieu = Session["maphieu"].ToString();
            String noidung2 = "Chào anh/chị. Có thông tin mới";
            noidung2 += "- Mã văn bản: " + maphieu + "\n";
            noidung2 += "- Tiêu đề: " + txtTile.Text + "\n";

            noidung2 += "- Nội dung: " + txtComment.Text + "\n";
           
            Busers2 nhanvientao = UserBUS.TimMaNhanVienTaoPhieu(manguoitao, congty);
            Busers2 nhanviendich = UserBUS.TimMaNhanVienDich(user, congty);
            Until.SendMailNguoiTao(nhanviendich.EMAIL, nhanvientao.EMAIL, "[Ty Hung-eOffice] Thông báo  ", noidung2);
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                LbThongBao.Text = "Sent successfully";
            }
            else if (ngonngu == "lbl_TW")
            {
                LbThongBao.Text = "Sent successfully";
            }
            else if (ngonngu == "lbl_EN")
            {
                LbThongBao.Text = "Sent successfully";
            }
            btnSendMail.Enabled = false;
            btnSendMail.Attributes.CssStyle.Add("opacity", "0.5");
        }

        protected void RadioSendTranslator_CheckedChanged(object sender, EventArgs e)
        {
            HienThiDiv();
        }

        protected void btnTroVe_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieuchuadichND.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieuchuadichND.aspx");
        }
    }
}