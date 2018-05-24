using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.Share;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class MyCheckDetailMH : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        string capduyet;
        protected void Page_Load(object sender, EventArgs e)
        {
            int capduyet = 7;
            int capchunhiem = 9;
           // string languege = (string)Request["languege"];
            string languege = "lbl_VN";
            Session["languege"] = languege;
            string UserID = (string)Session["UserID"];
            string idcongty = Session["congty"].ToString();
            string pdno = Session["maphieu"].ToString();
           
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(6, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                HienThiDanhSachMuaHang();

                HienThi();
                btnBoQua.Visible = false;
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

                        andi.Visible = false;
                        andi1.Visible = false;
                    }
                }
                HienThiFileDinhKem();
                ShowAttactFile();
            }
            HienThiButon();
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx");
        }

        protected void btnContinues_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/ApproveUser/frmApproval.aspx");
        }

        protected void btnBoQua_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();
            Abcon kiemtra = AbconDAO.LayPhieuChuaDuyetTheoNguoiDuyet(maphieu, nguoiduyet, macongty);
            AbconDAO.CapNhatChiTietPhieuTheoNguoiDuyet(kiemtra, macongty);
            btnBoQua.Enabled = false;
            btnContinues.Enabled = false;
            btnHuy.Enabled = false;
            Response.Redirect("~/presentationLayer/ApproveUser/MyChechPDN.aspx");
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
        private void ShowAttactFile()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            //gvDetails.DataSource = db.ExecuteQuery<PDNLink>("select * from PDNLink where pdno='" + idphieu + "' and Gsbh='" + macongty + "' and Cancel='0'");
            gvDetails.DataSource = PDNLinkDAO.GetLinkAttactFileByPDNO(macongty, idphieu);
            gvDetails.DataBind();
        }
        private void HienThiFileDinhKem()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            List<PDNLink> list = PDNLinkBUS.GetLinkAttactFileByPDNO(macongty, idphieu);
            if (list.Count > 0)
            {
                divUpload2.Visible = true;
                //gvDetails.DataSource = db.ExecuteQuery<PDNLink>("select * from PDNLink where pdno='" + idphieu + "' and Gsbh='" + macongty + "' and Cancel='0'");
                gvDetails.DataSource = PDNLinkBUS.GetLinkAttactFileByPDNO(macongty, idphieu);
                gvDetails.DataBind();
            }
            else
            {

                divUpload2.Visible = false;
            }
        }
        public void HienThiDanhSachMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + idphieu + "' and b.GSBH='" + macongty + "'"));
            GridView1.DataSource = db.ExecuteQuery<BOfSupply>("select b.IDOfSupplies,b.OfSuppliesName,b.pdno,b.GSBH,b.BUnit,b.BNumber,b.BCommnent from  pdna p left join BOfSupplies b on p.pdno=b.pdno and p.GSBH=b.GSBH where b.pdno='" + idphieu + "' and b.GSBH='" + macongty + "'");

            GridView1.DataBind();

            //GridView1.DataSource = pnaDAO.LayPhieuMuaHang(idphieu, macongty);
            //GridView1.DataBind();

        }
        public void HienThiButon()
        {
            string macongty = Session["congty"].ToString();
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();
            Abcon kiemtra = AbconDAO.LayPhieuChuaDuyetTheoNguoiDuyet(maphieu, nguoiduyet, macongty);
            List<Abcon> CapDuyet = AbconDAO.QryBuocDuyet(maphieu, macongty, kiemtra.Abstep);
            if (CapDuyet.Count() > 1)
            {
                btnBoQua.Visible = true;
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    btnBoQua.Text = "Không Phải Trách Nhiệm Của Tôi";
                }
                else if (ngonngu == "lbl_TW")
                {
                    btnBoQua.Text = "不是我的责任";
                }
                else if (ngonngu == "lbl_EN")
                {
                    btnBoQua.Text = "It's not my responsibility!";
                }
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnContinues.Text = hasLanguege["btnContinues"].ToString();
            btnHuy.Text = hasLanguege["btnHuy"].ToString();
            //btnBoQua.Text = hasLanguege["btnBoQua"].ToString();
        }

        private void HienThiChiTiet()
        {
            string macongty = Session["congty"].ToString();
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();
            //string tenloaiphieu = Session["loaiphieu"].ToString();
            pdna list = pdnaBUS.LayNoiDungVanBanTheoIDPhieuIDNhanVien(maphieu, nguoiduyet, macongty);
            BDepartment bp = BDepartmentDAO.TimMaDonVi(list.pddepid, macongty);
            Session["mabophan"] = bp.ID;
            Session["bophan"] = bp.DepName;
            abill loaiphieu = abillBUS.SearchAbillByID(list.Abtype);
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;
            lblTieuDe.Text = list.mytitle + list.pdnsubject;
            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbldonvidenghi.Text = bp.DepName;
            lbSoPhieu.Text = maphieu;

            string dinhdang = list.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";

        }

        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();
            string manguoidung = Session["UserID"].ToString();

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and Auditor='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and Auditor='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu,macongty, true);
                BDepartment bp = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
                Session["mabophan"] = bp.ID;
                Session["bophan"] = bp.DepName;
                if (phieu == null)
                {
                    string noidung = Session["noidung"].ToString();
                    string ngaytao = Session["ngaytao"].ToString();
                    lbldonvidenghi.Text = bp.DepName;
                    lbSoPhieu.Text = idphieu;


                    DateTime date = DateTime.Now;
                    string dinhdang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }
                else
                {
                    //abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    //string tenloaiphieuVN = loaiphieu.abname;
                    //string tenloaiphieuTW = loaiphieu.abnameTW;

                    //lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = bp.DepName;
                    lbSoPhieu.Text = idphieu;
                    lblMucDichSuDung.Text = phieu.UseIntent;

                    string dinhdang = phieu.CFMDate0.ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }

            }
        }
        private void HienThi()
        {
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();


            string macongty = Session["congty"].ToString();
            pdna phieu = pdnaBUS.TimVanBanTheoMa(maphieu, macongty, true);
            Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);
            BDepartment timdonvi = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
            Session["mabophan"] = timdonvi.ID;
            Session["bophan"] = timdonvi.DepName;
            abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;

            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbldonvidenghi.Text = timdonvi.DepName;
            lbSoPhieu.Text = maphieu;
            lblMucDichSuDung.Text = phieu.UseIntent;

            string dinhdang = phieu.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";


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
                        if (capduyet == null)
                        {
                            Busers2 nguoiduyet2 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                            if (abcon.abrult == true && abcon.Yn == 1)
                            {
                                TextBox9.Text = nguoiduyet2.USERID;
                                Image1.Width = 100;
                                Image1.Height = 100;
                                Image1.ImageUrl = "~/ProcessSignature/MyPhoto8.ashx?USERID=" + TextBox9.Text;
                            }
                            else
                            {
                                if (abcon.Yn == 2)
                                {
                                    //Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                    //if (khongduyet != null)
                                    //{
                                    //    lblLyDo.Visible = true;
                                    //    lblLyDo.Text = khongduyet.lydokhongduyet;
                                    //}
                                    TextBox9.Text = "027276";
                                    Image1.Width = 100;
                                    Image1.Height = 100;
                                    Image1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox9.Text;
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
                                TextBox2.Text = nguoiduyet2.USERID;
                                ImageLevel2.Width = 100;
                                ImageLevel2.Height = 100;
                                ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhoto2.ashx?USERID=" + TextBox2.Text;
                            }
                            else
                            {
                                if (abcon.Yn == 2)
                                {
                                    //Abcon khongduyet = AbconDAO.LayPhieuKhongDuyetTheoNguoiDuyet(maphieu, abcon.Auditor, macongty);
                                    //if (khongduyet != null)
                                    //{
                                    //    lblLyDo.Visible = true;
                                    //    lblLyDo.Text = khongduyet.lydokhongduyet;
                                    //}
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
                        if (abcon.abrult == true && abcon.Yn == 2)
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

    }
}