using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.DTO;
using iOffice.Share;
using iOffice.BUS;
using iOffice.DAO;

namespace iOffice.presentationLayer.ApproveUser
{
    public partial class phieumuahangD : LanguegeBus
    {
        string capduyet;
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        abconDAL dalP = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
           
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(3,strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {

                GanNgonNguVaoConTrol();
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                int capduyet = 7;
                int capchunhiem = 9;

                divComment.Visible = false;

                HienThi();
                HienThiDanhSachMuaHang();
                


               
                List<Abcon> danhsach = AbconDAO.QryPhieuCoCungCapDuyet(maphieu, macongty, capduyet);
                if (danhsach.Count() != 0)
                {
                    if (danhsach.Count() == 1)
                    {

                        ImageLevel2.Visible = false;

                        andi.Visible = false;
                        andi1.Visible = false;
                    }
                    else
                    {

                        ImageLevel2.Visible = true;

                        andi.Visible = true;
                        andi1.Visible = true;
                    }
                }
                List<Abcon> danhsachphieu = AbconDAO.QryPhieuCoCungCapDuyet(maphieu, macongty, capchunhiem);
                if (danhsachphieu.Count == 0)
                {
                    chunhiem.Visible = false;
                    chunhiem1.Visible = false;
                }
                else
                {
                    chunhiem.Visible = true;
                    chunhiem1.Visible = true;
                }
            }
        }
        public void HienThiDanhSachMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            DataRow drw = dt.NewRow();
            DataRow drw1 = dt.NewRow();
            DataRow drw2 = dt.NewRow();
            DataRow drw3 = dt.NewRow();
            DataRow drw4 = dt.NewRow();
            DataRow drw5 = dt.NewRow();

            if (dt.Rows.Count != 0 && dt.Rows.Count < 6)
            {
                dt.Rows.Add(drw);
                dt.Rows.Add(drw1);
                dt.Rows.Add(drw2);
                dt.Rows.Add(drw3);
                dt.Rows.Add(drw4);
                dt.Rows.Add(drw5);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        private void HienThi()
        {
            string nguoiduyet = Session["user"].ToString();
            string maphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();

            //string madonvi = Session["mabophan"].ToString();
            string macongty = Session["congty"].ToString();
           // pdna phieu = pdnaBUS.TimVanBanTheoMa(maphieu, macongty, true);
            DataTable dt = dal.TimPhieuTheoMaPhieu(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                string madonvi = dt.Rows[0]["pddepid"].ToString();
                string maloaip = dt.Rows[0]["Abtype"].ToString();
                int dout = int.Parse(dt.Rows[0]["ABC"].ToString());
                pdna phieucu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
                Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);
                BDepartment bp = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                Session["bophan"] = bp.DepName;
                Session["mabophan"] = bp.ID;
                Abcon lydokhongduyet = AbconDAO.LayPhieuKhongDuyetTheoPhieu(madonvi, maloaip, macongty, maphieu);
                abill loaiphieu = abillBUS.SearchAbillByID(maloaip);
                aABC douutien = ABCDAO.TimDoUuTien(dout);
                if (douutien != null)
                {
                    lblDoUutien.Text = douutien.NameABC + "-" + douutien.NameABCTW;
                }
                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;
                if (phieucu == null)
                {
                    idofPhieuCu.Visible = false;
                }
                else
                {
                    idofPhieuCu.Visible = true;
                }
                lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
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
                lblTieuDe.Text = dt.Rows[0]["mytitle"].ToString() + "-" + dt.Rows[0]["pdnsubject"].ToString();
                // string ngay = DateTime.Parse(phieu.CFMDate0.ToShortDateString()).ToString("dd/MM/yyyy");
                txtSoPhieu.Text = maphieu.ToString().Trim();
                string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                string thang = dinhdang.Substring(3, 2);
                string ngay = dinhdang.Substring(0, 2);
                string nam = dinhdang.Substring(6, 4);
                lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                lbldonvidenghi.Text = bp.DepName;
                lbSoPhieu.Text = maphieu;
                lblMucDichSuDung.Text = dt.Rows[0]["UseIntent"].ToString();
            }
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
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachVanBanDen.aspx");
        }

        protected void btnShowComment_Click(object sender, EventArgs e)
        {
            divComment.Visible = true;
            HienThiComment();
            btnShowComment.Visible = false;
            btnHideComment.Visible = true;
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
            Label lblAuditor = (Label)gridComment.Rows[e.RowIndex].FindControl("lblAuditor");
            TextBox txtComment = (TextBox)gridComment.Rows[e.RowIndex].FindControl("txtEditComment");
            dalP.CapNhatComment(maphieu, congty, lblAuditor.Text.Trim(), txtComment.Text);
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

        protected void gridComment_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string userid = Session["user"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    Label ln = (Label)e.Row.FindControl("lblAuditor") as Label;
                    LinkButton lin = (LinkButton)e.Row.FindControl("linkEditComment") as LinkButton;
                    if (ln.Text.Trim() == userid)
                    {
                        lin.Enabled = true;
                        e.Row.BackColor = System.Drawing.Color.Beige;
                        lin.Attributes.CssStyle.Add("opacity", "100");
                    }
                    else
                    {
                        lin.Enabled = false;
                        lin.Attributes.CssStyle.Add("opacity", "0.5");
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}