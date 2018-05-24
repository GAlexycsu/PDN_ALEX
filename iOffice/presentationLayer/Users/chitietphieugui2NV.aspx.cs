using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.Share;
using iOffice.BUS;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class chitietphieugui2NV : System.Web.UI.Page
    {
        int STT = 1;
        static iOfficeDataContext db = new iOfficeDataContext();
        string capduyet;
        dalPDNLink dal = new dalPDNLink();
        abconDAL dalP = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string UserID = (string)Session["user"];
                if (UserID == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                btnHideComment.Visible = false;

                btnHuy.Enabled = false;
                btnHuy.Attributes.Add("opacity", "0.3");
                divUpload2.Visible = false;
                HienThi();
                HienThiDanhSachMuaHang();
                HienThiThongTinBiHuy();
                KiemTraTruocKhiXoa();
                ShowFileDinhKem();
            }
            
        }
        private void ShowFileDinhKem()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dal.QryFileDinhKem(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                divUpload2.Visible = true;
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
            }
            else
            {
                divUpload2.Visible = false;
            }
        }
        private void HienThiThongTinBiHuy()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
            if (phieu != null)
            {
                string sophieucu = phieu.pdno;
                Label1Sophieucu.Visible = true;
                Label2cophieucu.Visible = true;

                Session["sophieucu"] = sophieucu;
                Label2cophieucu.Text = phieu.pdno;
            }
            else
            {
                Label1Sophieucu.Visible = false;
                Label2cophieucu.Visible = false;
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        private void HienThi()
        {
            string nguoiduyet = Session["user"].ToString();
            string maphieu = Session["maphieu"].ToString();


            string macongty = Session["congty"].ToString();
           
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, nguoiduyet, macongty);
            BDepartment timbophan = BDepartmentDAO.TimMaDonVi(chitietduyet.pddepid, macongty);
            Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);
            Abcon lydokhongduyet = AbconDAO.LayPhieuKhongDuyetTheoPhieu(timbophan.ID, chitietduyet.Abtype, macongty, maphieu);
            if (lydokhongduyet == null)
            {
                lblLyDo.Visible = false;
                lblNhanLyDo.Visible = false;
            }
            else
            {
                lblLyDo.Visible = true;
                lblNhanLyDo.Visible = true;
                lblLyDo.Text = lydokhongduyet.lydokhongduyet;
            }
            Abcon timphieuchuaduyet = AbconDAO.TimPhieuChuaDuyet(maphieu, macongty);
            if (timphieuchuaduyet != null)
            {

                btnHuy.Enabled = true;
                btnHuy.Attributes.Add("opacity", "100");
            }
            else
            {
                btnHuy.Enabled = false;
                btnHuy.Attributes.Add("opacity", "0.3");
            }
            abill loaiphieu = abillBUS.SearchAbillByID(chitietduyet.Abtype);
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;
            lblTieuDe.Text = chitietduyet.mytitle + chitietduyet.pdnsubject;
            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbldonvidenghi.Text = timbophan.DepName;
            lbSoPhieu.Text = maphieu;
            lblMucDichSuDung.Text = chitietduyet.UseIntent;
            txtSoPhieu.Text = maphieu.ToString().Trim();
            // lbNgay.Text = chitietduyet.CFMDate0.ToString();
            string dinhdang = chitietduyet.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            //Abcon abcon6 = AbconBUS.LaymaVanBanTheoCapDuyet6(maphieu, 6);
            List<Abcon> listchitietxetduyet = AbconBUS.QryChiTietXetDuyetTheoIdVanBan(maphieu, true);
            // Abcon captruoc = AbconBUS.LayCapDuyetTruocCuaNhanVienTheoVanBan(Until.uNhanVien.USERID, maphieu);

            Busers2 user0 = AbconBUS.LayMaNguoiTaoTheoIDVanBan(maphieu, macongty);
            {
                if (user0 != null)
                {
                    TextBox1.Text = user0.USERID;
                    ImageLevel0.Width = 100;
                    ImageLevel0.Height = 100;
                    ImageLevel0.ImageUrl = "~/MyPhoto.ashx?USERID=" + TextBox1.Text;

                }
                else
                {
                    ImageLevel0.ImageUrl = null;
                }
            }
            //Abcon caphientai = AbconBUS.LayCapDuyetHienTaiCuaNhanVienTheoVanBan(Until.uNhanVien.USERID, maphieu);
              foreach (Abcon abcon in listchitietxetduyet)
            {
                if (abcon == null)
                {
                    ImageLevel1.ImageUrl = null;
                    ImageLevel2.ImageUrl = null;
                    ImageLevel3.ImageUrl = null;
                    ImageLevel4.ImageUrl = null;
                    ImageLevel5.ImageUrl = null;
                    ImageLevel6.ImageUrl = null;

                    return;
                }
                else
                {
                    List<Abcon> lstChiTietXetDuyet1 = AbconBUS.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(maphieu, macongty);
                    int max = (from ct1 in lstChiTietXetDuyet1
                               select ct1.Abstep).Max();

                    if (abcon.IDCapDuyet == 5 || abcon.IDCapDuyet == 6)
                    {
                        Busers2 nguoiduyet1 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        //ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet6.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox2.Text = nguoiduyet1.USERID;
                            ImageLevel1.Width = 100;
                            ImageLevel1.Height = 100;
                            ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhoto1.ashx?USERID=" + TextBox2.Text;
                            
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                TextBox2.Text = nguoiduyet1.USERID;
                                txtKhongDuyet.Text = "027276";
                                ImageLevel1.Width = 100;
                                ImageLevel1.Height = 100;
                                ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                            }
                            else
                            {
                                ImageLevel1.ImageUrl = null;
                                    
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 7)
                    {
                        if (capduyet == null)
                        {
                            Busers2 nguoiduyet2 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                            if (abcon.abrult == true && abcon.Yn == 1)
                            {
                                
                                TextBox3.Text = nguoiduyet2.USERID;
                                Image1.Width = 100;
                                Image1.Height = 100;
                                Image1.ImageUrl = "~/ProcessSignature/MyPhoto8.ashx?USERID=" + TextBox3.Text;
                            }
                            else
                            {
                                if (abcon.Yn == 2)
                                {
                                    Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                    if (khongduyet != null)
                                    {
                                        lblLyDo.Visible = true;
                                        lblLyDo.Text = khongduyet.lydokhongduyet;
                                    }
                                    
                                    TextBox3.Text = nguoiduyet2.USERID;
                                    txtKhongDuyet.Text = "027276";
                                    Image1.Width = 100;
                                    Image1.Height = 100;
                                    Image1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                                }
                                else
                                {
                                    Image1.ImageUrl = null;
                                        
                                }
                            }
                            capduyet = abcon.IDCapDuyet.ToString();
                        }
                        else
                        {
                            Busers2 nguoiduyet2 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                            if (abcon.abrult == true && abcon.Yn == 1)
                            {
                                    
                                TextBox4.Text = nguoiduyet2.USERID;
                                ImageLevel2.Width = 100;
                                ImageLevel2.Height = 100;
                                ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhoto2.ashx?USERID=" + TextBox4.Text;
                            }
                            else
                            {
                                if (abcon.Yn == 2)
                                {
                                    Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                    if (khongduyet != null)
                                    {
                                        lblLyDo.Visible = true;
                                        lblLyDo.Text = khongduyet.lydokhongduyet;
                                    }
                                    
                                    txtKhongDuyet.Text = "027276";
                                    TextBox4.Text = nguoiduyet2.USERID;
                                    ImageLevel2.Width = 100;
                                    ImageLevel2.Height = 100;
                                    ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                                }
                                else
                                {
                                    ImageLevel2.ImageUrl = null;
                                        
                                }
                            }
                        }

                    }
                    if (abcon.IDCapDuyet == 9)
                    {
                        Busers2 nguoiduyet3 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet3.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                                
                            TextBox5.Text = nguoiduyet3.USERID;
                            ImageLevel3.Width = 100;
                            ImageLevel3.Height = 100;
                            ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhoto3.ashx?USERID=" + TextBox5.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                    
                                TextBox5.Text = nguoiduyet3.USERID;
                                txtKhongDuyet.Text = "027276";
                                ImageLevel3.Width = 100;
                                ImageLevel3.Height = 100;
                                ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                            }
                            else
                            {
                                ImageLevel3.ImageUrl = null;
                                    
                            }
                        }

                    }
                    if (abcon.IDCapDuyet == 13)
                    {
                        Busers2 nguoiduyet4 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet4.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                                
                            TextBox6.Text = nguoiduyet4.USERID;
                            ImageLevel4.Width = 100;
                            ImageLevel4.Height = 100;
                            ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhoto4.ashx?USERID=" + TextBox6.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                 TextBox6.Text = nguoiduyet4.USERID;
                                txtKhongDuyet.Text = "027276";
                                ImageLevel4.Width = 100;
                                ImageLevel4.Height = 100;
                                ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                            }
                            else
                            {
                                ImageLevel4.ImageUrl = null;
                                    
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 15 || abcon.IDCapDuyet == 14)
                    {
                        Busers2 nguoiduyet5 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet5.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            
                            TextBox7.Text = nguoiduyet5.USERID;
                            ImageLevel5.Width = 100;
                            ImageLevel5.Height = 100;
                            ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhoto5.ashx?USERID=" + TextBox7.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                    
                                txtKhongDuyet.Text = "027276";
                                 TextBox7.Text = nguoiduyet5.USERID;
                                ImageLevel5.Width = 100;
                                ImageLevel5.Height = 100;
                                ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                            }
                            else
                            {
                                ImageLevel5.ImageUrl = null;
                                    
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 16)
                    {
                        Busers2 nguoiduyet6 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet6.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                                
                            TextBox8.Text = nguoiduyet6.USERID;
                            ImageLevel6.Width = 100;
                            ImageLevel6.Height = 100;
                            ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhoto6.ashx?USERID=" + TextBox8.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                 TextBox8.Text = nguoiduyet6.USERID;
                                txtKhongDuyet.Text = "027276";
                                ImageLevel6.Width = 100;
                                ImageLevel6.Height = 100;
                                ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;

                            }
                            else
                            {
                                ImageLevel6.ImageUrl = null;
                                    
                            }
                        }
                    }

                    else if (abcon.IDCapDuyet == 17)
                    {
                        Busers2 nguoiduyet7 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet7.IDChucVu, macongty);

                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                                
                            TextBox9.Text = nguoiduyet7.USERID;
                            ImageLevel7.Width = 100;
                            ImageLevel7.Height = 100;
                            ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhoto7.ashx?USERID=" + TextBox9.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                    
                                TextBox9.Text = nguoiduyet7.USERID;
                                txtKhongDuyet.Text = "027276";
                                ImageLevel7.Width = 100;
                                ImageLevel7.Height = 100;
                                ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + txtKhongDuyet.Text;
                            }
                            else
                            {
                                ImageLevel7.ImageUrl = null;
                                    
                            }
                        }
                    }


                }
            }
        }
        public void HienThiDanhSachMuaHang()
        {
            dalPDN dal = new dalPDN();
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count < 6)
                {
                    DataRow dr = dt.NewRow();
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    DataRow dr3 = dt.NewRow();
                    DataRow dr4 = dt.NewRow();
                    DataRow dr5 = dt.NewRow();
                    DataRow dr6 = dt.NewRow();
                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    //dt.Rows.Add(dr3);
                    //dt.Rows.Add(dr4);
                    
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }
        private void KiemTraTruocKhiXoa()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            int buocduyet = 1; int capduyet = 1;
            Abcon kiemtra = AbconBUS.KiemTraPhieu(maphieu, macongty, capduyet, buocduyet);
            if (kiemtra.abrult == true && kiemtra.Yn == 1)
            {
                btnHuy.Visible = false;
            }
            else
            {
                btnHuy.Visible = true;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    btnHuy.Text = "Hủy Phiếu Đã Gửi";
                    btnBack.Text = "Trở Về";
                }
                else
                {
                    if (ngonngu == "lbl_TW")
                    {
                        btnHuy.Text = "删除已寄出档案";
                        btnBack.Text = "背部";
                    }
                    else
                    {
                        btnHuy.Text = "Cancel";
                        btnBack.Text = "背部";
                    }
                }
            }
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            PDNSheetFlowBUS.XoaPDNSheetFlowBiHuy(maphieu, macongty);
          
            AbconDAO.XoaPhieuBiHuy(maphieu, macongty);
            TrangThaiDuyetDAO.XoaTrangThaiDuyetBiXoa(maphieu, macongty);
            pnaDAO.CapNhatPhieuGuiBiHuy(maphieu, macongty);
            Response.Redirect("DanhsachphieumoikhoitaoNV.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
            string ktTroVe = (string)Session["ktTroVe"];
            if (ktTroVe == null)
            {
                Response.Redirect("DanhsachvanbandaguiNV.aspx");
            }
            else
            {
                Response.Redirect("MyDocusNV.aspx");
            }
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = gvDetails.DataKeys[grdRow.RowIndex].Value.ToString();

            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void btnShowComment_Click(object sender, EventArgs e)
        {
            divComment.Visible = true;
            HienThiComment();
            btnShowComment.Visible = false;
            btnHideComment.Visible = true;
        }
        public void HienThiComment()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = "LTY";
            Session["congty"] = macongty;
            DataTable dt = dalP.DanhSachComment(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                gridComment.DataSource = dt;
                gridComment.DataBind();
            }
        }

        protected void btnHideComment_Click(object sender, EventArgs e)
        {
            divComment.Visible = false;
            btnHideComment.Visible = false;
            btnShowComment.Visible = true;
        }

        protected void gridComment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string congty = Session["congty"].ToString();
            Label lblCreate = (Label)gridComment.Rows[e.RowIndex].FindControl("lblCreater");
            TextBox txtComment = (TextBox)gridComment.Rows[e.RowIndex].FindControl("txtAnswer");
            Label lblAuditor = (Label)gridComment.Rows[e.RowIndex].FindControl("lblAuditor");
            dalP.CapNhatTraLoi(maphieu, congty, lblCreate.Text.Trim(), lblAuditor.Text.Trim(), txtComment.Text);
            gridComment.EditIndex = -1;
            HienThiComment();
        }

        protected void gridComment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridComment.EditIndex = e.NewEditIndex;
            HienThiComment();
        }

        protected void gridComment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridComment.EditIndex = -1;
            HienThiComment();
        }
    }
}