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

    public partial class frmchitietphieu1 : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        string capduyet;
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(39, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
               
                int capduyet = 7;
                int capchunhiem = 9;

                Abcon timphieu = AbconDAO.LayPhieuKhongDuyetTheoNguoiTao(maphieu, manguoidung, macongty);

                if (timphieu == null)
                {

                    lblLyDo.Visible = false;
                    lblNhanLyDo.Visible = false;
                }
                else
                {

                    lblLyDo.Visible = true;
                    lblNhanLyDo.Visible = true;
                    GanNgonNguVaoConTrol();
                }
                HienThi();
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
                
                HienThiDanhSachMuaHang();


            }
           
        }
        public void HienThiDanhSachMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            if (dt.Rows.Count != 0 && dt.Rows.Count < 6)
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
                dt.Rows.Add(dr3);
                dt.Rows.Add(dr4);
                dt.Rows.Add(dr5);
                dt.Rows.Add(dr6);
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

            string maphieucu = Session["sophieucu"].ToString();

            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();

            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieucu, manguoidung, macongty);
            BDepartment timbophan = BDepartmentDAO.TimMaDonVi(chitietduyet.pddepid, macongty);
            Busers2 users = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
            Abcon lydokhongduyet = AbconDAO.LayPhieuKhongDuyetTheoPhieu(timbophan.ID, chitietduyet.Abtype, macongty, maphieucu);
            abill loaiphieu = abillBUS.SearchAbillByID(chitietduyet.Abtype);

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
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;

            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbldonvidenghi.Text = timbophan.DepName;
            lbSoPhieu.Text = maphieucu;
            txtSoPhieu.Text = maphieucu.ToString().Trim();
            //lbNgay.Text = chitietduyet.CFMDate0.ToString();
            string dinhdang = chitietduyet.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            //Abcon abcon6 = AbconBUS.LaymaVanBanTheoCapDuyet6(maphieu, 6);
            List<Abcon> listchitietxetduyet = AbconBUS.QryChiTietXetDuyetTheoIdVanBan(maphieucu, true);
            // Abcon captruoc = AbconBUS.LayCapDuyetTruocCuaNhanVienTheoVanBan(Until.uNhanVien.USERID, maphieu);

            Busers2 user0 = AbconBUS.LayMaNguoiTaoTheoIDVanBan(maphieucu, macongty);
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
                    List<Abcon> lstChiTietXetDuyet1 = AbconBUS.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(maphieucu, macongty);
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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                TextBox2.Text = "027276";
                                ImageLevel1.Width = 100;
                                ImageLevel1.Height = 100;
                                ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox2.Text;
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
                                    Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                    if (khongduyet != null)
                                    {
                                        lblLyDo.Visible = true;
                                        lblLyDo.Text = khongduyet.lydokhongduyet;
                                    }
                                    
                                    TextBox3.Text = "027276";
                                    Image1.Width = 100;
                                    Image1.Height = 100;
                                    Image1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox3.Text;
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
                                    Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                    if (khongduyet != null)
                                    {
                                        lblLyDo.Visible = true;
                                        lblLyDo.Text = khongduyet.lydokhongduyet;
                                    }
                                        
                                    TextBox4.Text = "027276";
                                    ImageLevel2.Width = 100;
                                    ImageLevel2.Height = 100;
                                    ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox4.Text;
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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                TextBox5.Text = "027276";
                                ImageLevel3.Width = 100;
                                ImageLevel3.Height = 100;
                                ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox5.Text;
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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                TextBox6.Text = "027276";
                                ImageLevel4.Width = 100;
                                ImageLevel4.Height = 100;
                                ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox6.Text;
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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                    
                                TextBox7.Text = "027276";
                                ImageLevel5.Width = 100;
                                ImageLevel5.Height = 100;
                                ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox7.Text;
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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                    
                                TextBox8.Text = "027276";
                                ImageLevel6.Width = 100;
                                ImageLevel6.Height = 100;
                                ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox6.Text;

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
                                Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieucu, abcon.Auditor, macongty);
                                if (khongduyet != null)
                                {
                                    lblLyDo.Visible = true;
                                    lblLyDo.Text = khongduyet.lydokhongduyet;
                                }
                                
                                TextBox9.Text = "027276";
                                ImageLevel7.Width = 100;
                                ImageLevel7.Height = 100;
                                ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox9.Text;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmView.aspx");
        }
    }
}