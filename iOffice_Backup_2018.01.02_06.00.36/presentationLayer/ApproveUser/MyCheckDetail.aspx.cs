using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class MyCheckDetail : System.Web.UI.Page
    {
        string capduyet;
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            int capduyet = 7;
            int capchunhiem = 9;
            //string languege = (string)Request["languege"];
            string UserID = (string)Session["UserID"];
            //string idcongty = (string)Request["GSBH"];
            //string pdno = (string)Request["pdno"];
            string idcongty = "LTY";
            string pdno = Session["maphieu"].ToString();
            
                //Session["languege"] = languege;
                Session["congty"] = idcongty;
                //Session["UserID"] = UserID;
                Session["maphieu"] = pdno;
                //Abcon kiemtra = AbconDAO.TimMaPhieuTheoNguoiDuyet(pdno, UserID, idcongty);
                //if (kiemtra != null)
                //{
                //    if (kiemtra.abtype == "PDN2")
                //    {
                //        Response.Redirect("phieumuahang.aspx");
                //    }
                //    else
                //    {
                //        Response.Redirect("frmDetails2.aspx");
                //    }
                //}
            

            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                //LayngonNgu(6);
                //GanNgonNguVaoConTrol();
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                HienThiChiTiet();
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
            Response.Redirect("~/presentationLayer/ApproveUser/MyCheckPDN.aspx");
        }

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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
        private void HienThiFileDinhKem()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            List<PDNLink> list = PDNLinkBUS.GetLinkAttactFileByPDNO(macongty, idphieu);
            if (list.Count > 0)
            {
                divUpload2.Visible = true;
                gvDetails.DataSource = db.ExecuteQuery<PDNLink>("select * from PDNLink where pdno='" + idphieu + "' and Gsbh='" + macongty + "' and Cancel='0'");
                gvDetails.DataBind();
            }
            else
            {

                divUpload2.Visible = false;
            }
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
                //string ngonngu = Session["languege"].ToString();
                string ngonngu = "lbl_VN";
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
        private void HienThiChiTiet()
        {
            string macongty = Session["congty"].ToString();
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();

            pdna list = pdnaBUS.LayNoiDungVanBanTheoIDPhieuIDNhanVien(maphieu, nguoiduyet, macongty);
            abill loaiphieu = abillBUS.SearchAbillByID(list.Abtype);
            BDepartment bp = BDepartmentDAO.TimMaDonVi(list.pddepid, macongty);
            aABC douutien = ABCDAO.TimDoUuTien(int.Parse(list.ABC.ToString()));
            if (douutien != null)
            {
                lblDoUutien.Text = douutien.NameABC + "-" + douutien.NameABCTW;
            }
            Session["mabophan"] = bp.ID;
            Session["bophan"] = bp.DepName;
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;
            Session["loaiphieu"] = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            lbBoPhan.Text = bp.DepName;
            lbSoPhieu.Text = maphieu;
            lbNoiDung.Text = list.pdmemovn;
            lblTieuDe.Text = list.mytitle + "-" + list.pdnsubject;
            lbNoidungdich.Text = list.NoiDungDich;
            string dinhdang = list.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";

        }
        private void HienThi()
        {
            string nguoiduyet = Session["UserID"].ToString();
            string maphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();
            //string loaiphieu = Session["loaiphieu"].ToString();
            string macongty = Session["congty"].ToString();
            pdna phieu = pdnaBUS.TimVanBanTheoMa(maphieu, macongty, true);
            Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);
            BDepartment bp = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
            Session["mabophan"] = bp.ID;
            Session["bophan"] = bp.DepName;
            lbBoPhan.Text = bp.DepName;
            lbSoPhieu.Text = maphieu;
            lbNoiDung.Text = phieu.pdmemovn;
            lbNoidungdich.Text = phieu.NoiDungDich;
            //lbLoaiPhieu.Text = loaiphieu;
            // lbNgay.Text = phieu.CFMDate0.ToString();
            string dinhdang = phieu.CFMDate0.ToString();
            string ngay = dinhdang.Substring(3, 2);
            string thang = dinhdang.Substring(0, 2);
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