using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.Share;
using iOffice.BUS;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class Details5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
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
            string loaiphieu = Session["loaiphieu"].ToString();
            string macongty = Session["congty"].ToString();

            var list = pdnaBUS.LayNoiDungVanBanTheoIDPhieuIDNhanVien(maphieu, nguoiduyet,macongty);
            Busers2 users = UserBUS.TimNhanVienTheoMa(nguoiduyet, macongty);


            lbBoPhan.Text = bophan;
            lbSoPhieu.Text = maphieu;
            lbNoiDung.Text = list.pdmemovn;
            lbLoaiPhieu.Text = loaiphieu;
            lbNgay.Text = list.CFMDate0.ToString();
            //Abcon abcon6 = AbconBUS.LaymaVanBanTheoCapDuyet6(maphieu, 6);
            List<Abcon> listchitietxetduyet = AbconBUS.QryChiTietXetDuyetTheoIdVanBan(maphieu, true);
            // Abcon captruoc = AbconBUS.LayCapDuyetTruocCuaNhanVienTheoVanBan(Until.uNhanVien.USERID, maphieu);

            Busers2 user0 = AbconBUS.LayMaNguoiTaoTheoIDVanBan(maphieu, macongty);
            {
                if (user0 != null)
                {
                    TextBox1.Text = user0.USERID;
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
                    //if (max == 5)
                    //{
                    //    ImageLevel1.Visible = false;

                    //}
                    //else
                    //{

                    //}
                    if (abcon.IDCapDuyet == 1)
                    {
                        Busers2 nguoiduyet1 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        //ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet6.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox1.Text = nguoiduyet1.USERID;
                            ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhoto1.ashx?USERID=" + TextBox1.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox1.Text = "027276";

                                ImageLevel1.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox1.Text;
                            }
                            else
                            {
                                ImageLevel1.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 2)
                    {
                        Busers2 nguoiduyet2 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox2.Text = nguoiduyet2.USERID;
                            ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhoto2.ashx?USERID=" + TextBox2.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox2.Text = "027276";

                                ImageLevel2.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox2.Text;
                            }
                            else
                            {
                                ImageLevel2.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 3)
                    {
                        Busers2 nguoiduyet3 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet3.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox3.Text = nguoiduyet3.USERID;
                            ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhoto3.ashx?USERID=" + TextBox3.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox3.Text = "027276";

                                ImageLevel3.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox3.Text;
                            }
                            else
                            {
                                ImageLevel3.ImageUrl = null;
                            }
                        }

                    }
                    if (abcon.IDCapDuyet == 4)
                    {
                        Busers2 nguoiduyet4 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet4.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox4.Text = nguoiduyet4.USERID;
                            ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhoto4.ashx?USERID=" + TextBox4.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox4.Text = "027276";

                                ImageLevel4.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox4.Text;
                            }
                            else
                            {
                                ImageLevel4.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 5)
                    {
                        Busers2 nguoiduyet5 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet5.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 2)
                        {
                            TextBox5.Text = nguoiduyet5.USERID;
                            ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhoto5.ashx?USERID=" + TextBox5.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox5.Text = "027276";

                                ImageLevel5.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox5.Text;
                            }
                            else
                            {
                                ImageLevel5.ImageUrl = null;
                            }
                        }
                    }
                    if (abcon.IDCapDuyet == 6)
                    {
                        Busers2 nguoiduyet6 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet6.IDChucVu, macongty);
                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox6.Text = nguoiduyet6.USERID;

                            ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhoto6.ashx?USERID=" + TextBox6.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox6.Text = "027276";

                                ImageLevel6.ImageUrl = "~/ProcessSignature/MyPhotoKhongDuyet.ashx?USERID=" + TextBox6.Text;

                            }
                            else
                            {
                                ImageLevel6.ImageUrl = null;
                            }
                        }
                    }

                    else if (abcon.IDCapDuyet == 7)
                    {
                        Busers2 nguoiduyet7 = UserBUS.TimNhanVienTheoMa(abcon.Auditor, macongty);
                        ChucVu chuc = ChucVuBUS.TimMaChucVu(nguoiduyet7.IDChucVu, macongty);

                        if (abcon.abrult == true && abcon.Yn == 1)
                        {
                            TextBox7.Text = nguoiduyet7.USERID;
                            ImageLevel7.ImageUrl = "~/ProcessSignature/MyPhoto7.ashx?USERID=" + TextBox7.Text;
                        }
                        else
                        {
                            if (abcon.Yn == 2)
                            {
                                TextBox7.Text = "027276";

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