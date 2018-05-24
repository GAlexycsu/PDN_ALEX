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
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class phieumuahangND : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                HienThi();
            }
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
        }
        private void HienThi()
        {
            string nguoiduyet = Session["user"].ToString();
            string maphieu = Session["maphieu"].ToString();
            string bophan = Session["bophan"].ToString();
            string tenloaiphieu = Session["tenloaiphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string madonvi = Session["mabophan"].ToString();
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, nguoiduyet, macongty);
            Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);
            Abcon lydokhongduyet = AbconDAO.LayPhieuKhongDuyetTheoPhieu(madonvi, chitietduyet.Abtype, macongty, maphieu);
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

            lbBoPhan.Text = bophan;
            lbSoPhieu.Text = maphieu;
            lbNoiDung.Text = chitietduyet.pdmemovn;
            
            //lbNgay.Text = chitietduyet.CFMDate0.ToString();
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
                            TextBox1.Text = nguoiduyet1.USERID;
                            ImageLevel1.Width = 100;
                            ImageLevel1.Height = 100;
                            ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhoto1.ashx?USERID=" + TextBox1.Text;
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
                                TextBox1.Text = "027276";
                                ImageLevel1.Width = 100;
                                ImageLevel1.Height = 100;
                                ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox1.Text;
                            }
                            else
                            {
                                ImageLevel1.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 7)
                    {
                        Busers2 nguoiduyet2 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox2.Text = nguoiduyet2.USERID;
                            ImageLevel2.Width = 100;
                            ImageLevel2.Height = 100;
                            ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhoto2.ashx?USERID=" + TextBox2.Text;
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
                                TextBox2.Text = "027276";
                                ImageLevel2.Width = 100;
                                ImageLevel2.Height = 100;
                                ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox2.Text;
                            }
                            else
                            {
                                ImageLevel2.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 9)
                    {
                        Busers2 nguoiduyet3 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet3.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox3.Text = nguoiduyet3.USERID;
                            ImageLevel3.Width = 100;
                            ImageLevel3.Height = 100;
                            ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhoto3.ashx?USERID=" + TextBox3.Text;
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
                                TextBox3.Text = "027276";
                                ImageLevel3.Width = 100;
                                ImageLevel3.Height = 100;
                                ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox3.Text;
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
                            TextBox4.Text = nguoiduyet4.USERID;
                            ImageLevel4.Width = 100;
                            ImageLevel4.Height = 100;
                            ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhoto4.ashx?USERID=" + TextBox4.Text;
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
                                TextBox4.Text = "027276";
                                ImageLevel4.Width = 100;
                                ImageLevel4.Height = 100;
                                ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox4.Text;
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
                            TextBox5.Text = nguoiduyet5.USERID;
                            ImageLevel5.Width = 100;
                            ImageLevel5.Height = 100;
                            ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhoto5.ashx?USERID=" + TextBox5.Text;
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
                                TextBox5.Text = "027276";
                                ImageLevel5.Width = 100;
                                ImageLevel5.Height = 100;
                                ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox5.Text;
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
                            TextBox6.Text = nguoiduyet6.USERID;
                            ImageLevel6.Width = 100;
                            ImageLevel6.Height = 100;
                            ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhoto6.ashx?USERID=" + TextBox6.Text;
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
                                TextBox6.Text = "027276";
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
                            TextBox7.Text = nguoiduyet7.USERID;
                            ImageLevel7.Width = 100;
                            ImageLevel7.Height = 100;
                            ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhoto7.ashx?USERID=" + TextBox7.Text;
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
                                TextBox7.Text = "027276";
                                ImageLevel7.Width = 100;
                                ImageLevel7.Height = 100;
                                ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox7.Text;
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
            string ngaytao = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
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

            //TrangThaiDuyetDAO.XoaTrangThaiDuyet(trangthai.IDTrangThai);

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
                maphieumoi = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            pdna timphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + timphieu.pdno.ToString() + "'and GSBH='" + timphieu.GSBH.ToString() + "' and CFMID0='" + timphieu.CFMID0.ToString() + "'"));
            pdna phieub = new pdna();
            phieub.pdno = maphieumoi;
            phieub.YN = 5;
            phieub.GSBH = macongty;
            phieub.dagui = false;
            phieub.bixoa = false;
            phieub.CFMDate0 = DateTime.Parse(ngaytao);
            phieub.CFMDate1 = null;
            phieub.CFMDate2 = null;
            phieub.CFMDate4 = null;
            phieub.IdnguoiDich = null;
            phieub.trangthaidich = false;
            phieub.NoiDungDich = null;
            phieub.LevelDoing = 1;
            phieub.CFMID0 = manguoidung;
            phieub.Abtype = timphieu.Abtype;
            phieub.ABC = timphieu.ABC;
            phieub.mytitle = timphieu.mytitle;
            phieub.pddepid = timphieu.pddepid;
            phieub.pdmemovn = timphieu.pdmemovn;
            phieub.oldpdno = timphieu.pdno;
            pnaDAO.InsertPDNA(phieub);
            //pnaDAO.CapNhatPhieuBiHuy(phieub);
            //db.ExecuteCommand("update pdna set GSBH='" + phieub.GSBH.ToString() + "',NoiDungDich=N'" + phieub.NoiDungDich.ToString() + "',CFMDate1='" + phieub.CFMDate1 + "',trangthaidich='" + phieub.trangthaidich.Value + "',CFMDate0=N'" + phieub.CFMDate0 + "',CFMDate2=N'" + phieub.CFMDate2 + "',bixoa='" + phieub.bixoa.Value + "',dagui='" + phieub.dagui.Value + "',YN='" + int.Parse(phieub.YN.ToString()) + "',LevelDoing='" + int.Parse(phieub.LevelDoing.ToString()) + "',IdnguoiDich=N'" + phieub.IdnguoiDich.ToString() + "' where pdno=N'" + phieub.pdno.ToString() + "' ");
            // db.ExecuteCommand("update pdna set GSBH='" + phieub.GSBH.ToString() + "',NoiDungDich=N'" + phieub.NoiDungDich.ToString() + "',trangthaidich='" + phieub.trangthaidich.Value + "',CFMDate0=N'" + phieub.CFMDate0 + "',bixoa='" + phieub.bixoa.Value + "',dagui='" + phieub.dagui.Value + "',YN='" + int.Parse(phieub.YN.ToString()) + "',LevelDoing='" + int.Parse(phieub.LevelDoing.ToString()) + "',IdnguoiDich=N'" + phieub.IdnguoiDich.ToString() + "' where pdno=N'" + phieub.pdno.ToString() + "' ");
            //db.CapNhatPhieuDaBiHuy(phieub.pdno, phieub.GSBH, phieub.dagui, phieub.bixoa, phieub.YN, phieub.NoiDungDich, phieub.IdnguoiDich, phieub.trangthaidich, phieub.CFMDate1, phieub.CFMDate0, phieub.CFMDate2, phieub.CFMDate4, phieub.ABC, phieub.LevelDoing);
            Response.Redirect("frmDanhsachphieumoikhoitao.aspx");
        }
    }
}