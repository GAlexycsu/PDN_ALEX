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
namespace iOffice.presentationLayer.Users
{
    public partial class frmDetails2NV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        string capduyet;
        abconDAL dalP = new abconDAL();
        
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
                GanNgonNguVaoConTrol();
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                divComment.Visible = false;
                int capduyet = 7;
                int capchunhiem = 9;
                HienThi();
                Abcon timphieu = AbconDAO.LayPhieuKhongDuyetTheoNguoiTao(maphieu, manguoidung, macongty);
                pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
                if (phieu != null)
                {
                    pdna timsophieu = pnaDAO.TimVanBanTheoMa(phieu.oldpdno, macongty);
                    if (timsophieu != null)
                    {
                        string sophieucu = timsophieu.pdno;
                        Label1Sophieucu.Visible = true;
                        Label2cophieucu.Visible = true;
                        btnKhoiPhuc.Visible = true;
                        Session["sophieucu"] = sophieucu;
                        Label2cophieucu.Text = timsophieu.pdno;
                    }
                    else
                    {
                        Label1Sophieucu.Visible = false;
                        Label2cophieucu.Visible = false;
                      //  btnKhoiPhuc.Visible = false;
                    }
                }
                else
                {
                    Label1Sophieucu.Visible = false;
                    Label2cophieucu.Visible = false;
                    btnKhoiPhuc.Visible = false;
                }
                if (timphieu == null)
                {
                    btnKhoiPhuc.Visible = false;
                    lblLyDo.Visible = false;
                    lblNhanLyDo.Visible = false;
                }
                else
                {
                    btnKhoiPhuc.Visible = true;
                    lblLyDo.Visible = true;
                    lblNhanLyDo.Visible = true;
                   
                }
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
        public override void GanNgonNguVaoConTrol()
        {
            btnKhoiPhuc.Text = hasLanguege["btnKhoiPhuc"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        private void HienThi()
        {
           // string nguoiduyet = Session["user"].ToString();
            string maphieu = Session["maphieu"].ToString();
           
           // string tenloaiphieu = Session["tenloaiphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            //string madonvi = Session["mabophan"].ToString();
            //var list = pdnaBUS.LayNoiDungVanBanTheoIDPhieuIDNhanVien(maphieu, nguoiduyet);
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, manguoidung, macongty);
            Busers2 users = UserBUS.TimNhanVienTheoMa(manguoidung, macongty);
            BDepartment timbophan = BDepartmentDAO.TimMaDonVi(chitietduyet.pddepid, macongty);
            Abcon lydokhongduyet = AbconDAO.LayPhieuKhongDuyetTheoPhieu(timbophan.ID, chitietduyet.Abtype, macongty, maphieu);
            abill loaiphieu = abillBUS.SearchAbillByID(chitietduyet.Abtype);
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;

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
            txtSoPhieu.Text = maphieu.ToString().Trim();
            lbBoPhan.Text = timbophan.DepName;
            lbSoPhieu.Text = maphieu;
            lbNoiDung.Text = chitietduyet.pdmemovn;
            LbNoiDungDich.Text = chitietduyet.NoiDungDich;
            lblTieuDe.Text = chitietduyet.mytitle+chitietduyet.pdnsubject;
            string dinhdang = chitietduyet.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            
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

        protected void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            DateTime date = DateTime.Now;
           // string ngaytao = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
            //List<Abcon> DSphieu = AbconDAO.QryChiTietPhieuTheoPhieuKhongDuocDuyet(maphieu, macongty, manguoidung);
            //foreach (Abcon phieu in DSphieu)
            //{
            //    AbconDAO.XoaChiTietTheoSoPhieu(phieu.IDCT);
            //}
            //List<VanBanDen> DsVanBanden = VanBanDenDAO.QryVanBanDen(maphieu, macongty);
            //foreach (VanBanDen vanban in DsVanBanden)
            //{
            //    VanBanDenDAO.XoaVanBanDen(vanban.id);
            //}
            //List<PDNSheetFlow> DsChitiet = PDNSheetFlowDAO.QryPDNSheetFlowTheoPhieu(maphieu, macongty);
            //foreach (PDNSheetFlow chitiet in DsChitiet)
            //{
            //    PDNSheetFlowDAO.XoaPDNSheetFlow(chitiet.Id);
            //}
            //ABTrangThaiDuyet trangthai = TrangThaiDuyetDAO.TimKiemMaVanTheoTrangThaiDuyet(maphieu, macongty);
           
            //    TrangThaiDuyetDAO.XoaTrangThaiDuyet(trangthai.IDTrangThai);
            //string dem = (pdnaBUS.DemSoLuongVanBan() + 1).ToString();
            //string maphieumoi = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMMdd") + "00" + dem;
            string maphieumoi = "";
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();

            if (dt.Rows.Count != 0 && aa != "")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieumoi = dem;
            }
            else
            {
                maphieumoi = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM")+"00" + 1;
            }
            pdna timphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + timphieu.pdno.ToString() + "'and GSBH='" + timphieu.GSBH.ToString() + "' and CFMID0='" + timphieu.CFMID0.ToString() + "'"));
            pdna phieub = new pdna();
            phieub.pdno = maphieumoi;
            phieub.YN = 5;
            phieub.GSBH = macongty;
            phieub.dagui = false;
            phieub.bixoa = false;
            phieub.CFMDate0 = DateTime.Today;
            phieub.CFMDate1 =null;
            phieub.CFMDate2 = null;
            phieub.CFMDate4 = null;
            phieub.IdnguoiDich = null;
            phieub.trangthaidich = false;
            phieub.NoiDungDich = null;
            phieub.LevelDoing = 0;
            phieub.CFMID0 = manguoidung;
            phieub.Abtype = timphieu.Abtype;
            phieub.ABC = timphieu.ABC;
            phieub.mytitle = timphieu.mytitle;
            phieub.pddepid = timphieu.pddepid;
            phieub.pdmemovn = timphieu.pdmemovn;
            phieub.oldpdno = timphieu.pdno;
            //pnaDAO.CapNhatPhieuBiHuy(phieub);
            //db.ExecuteCommand("update pdna set GSBH='" + phieub.GSBH.ToString() + "',NoiDungDich=N'" + phieub.NoiDungDich.ToString() + "',CFMDate1='" + phieub.CFMDate1 + "',trangthaidich='" + phieub.trangthaidich.Value + "',CFMDate0=N'" + phieub.CFMDate0 + "',CFMDate2=N'" + phieub.CFMDate2 + "',bixoa='" + phieub.bixoa.Value + "',dagui='" + phieub.dagui.Value + "',YN='" + int.Parse(phieub.YN.ToString()) + "',LevelDoing='" + int.Parse(phieub.LevelDoing.ToString()) + "',IdnguoiDich=N'" + phieub.IdnguoiDich.ToString() + "' where pdno=N'" + phieub.pdno.ToString() + "' ");
          // db.ExecuteCommand("update pdna set GSBH='" + phieub.GSBH.ToString() + "',NoiDungDich=N'" + phieub.NoiDungDich.ToString() + "',trangthaidich='" + phieub.trangthaidich.Value + "',CFMDate0=N'" + phieub.CFMDate0 + "',bixoa='" + phieub.bixoa.Value + "',dagui='" + phieub.dagui.Value + "',YN='" + int.Parse(phieub.YN.ToString()) + "',LevelDoing='" + int.Parse(phieub.LevelDoing.ToString()) + "',IdnguoiDich=N'" + phieub.IdnguoiDich.ToString() + "' where pdno=N'" + phieub.pdno.ToString() + "' ");
           // db.CapNhatPhieuDaBiHuy(phieub.pdno, phieub.GSBH, phieub.dagui, phieub.bixoa, phieub.YN, phieub.NoiDungDich, phieub.IdnguoiDich, phieub.trangthaidich, phieub.CFMDate1, phieub.CFMDate0, phieub.CFMDate2, phieub.CFMDate4, phieub.ABC, phieub.LevelDoing);
           // pnaDAO.InsertPDNA(phieub);
            db.pdnas.InsertOnSubmit(phieub);
            db.SubmitChanges();
            Response.Redirect("DanhsachphieumoikhoitaoNV.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieudaduyetNV.aspx");
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
    }
}