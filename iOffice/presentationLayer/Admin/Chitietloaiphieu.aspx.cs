using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class Chitietloaiphieu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idct = int.Parse(Session["mact"].ToString());
                int nhom = int.Parse(Session["nhom"].ToString());
                txtNhom.Text = nhom.ToString();
                string maloaiphieu = Session["maloaiphieu"].ToString();
                HienThiChucVu();
                HienThiDonVi();
                HienThiDropLoaiNguoiKy();
                txtNgayBatDau.Text = DateTime.Today.ToString("dd-MM-yyyy");
                //DateTime ngaykt = new DateTime();
                //ngaykt = DateTime.Parse(txtNgayKT.Text);
            }
            //txtNgayBatDau.Text = DateTime.Today.ToString("dd-mm-yyyy");
           
            HienThiDanhSach();
           
        }
        private void HienThiDropLoaiNguoiKy()
        {
            DropDownNguoiKy.DataSource = LoaiNguoiKyBUS.LayDanhSachLoaiNguoiKy();
            DropDownNguoiKy.DataValueField = "IdLoaiNguoiKy";
            DropDownNguoiKy.DataTextField = "TenLoai";
            DropDownNguoiKy.DataBind();
        }

        private void HienThiDanhSach()
        {
            GridView1.DataSource = ChiTietLoaiPhieuBUS.LayDanhSachChiTietLoaiPhieu();
            GridView1.DataBind();
        }
        private void HienThiChucVu()
        {
            DropDownChucvu.DataSource = ChucVuBUS.Laydanhsachchucvu();
            DropDownChucvu.DataValueField = "IDChucVu";
            DropDownChucvu.DataTextField = "TenChucVu";
            DropDownChucvu.DataBind();
        }
        private void HienThiDonVi()
        {
            DropDownBoPhan.DataSource = BDepartmentBUS.DanhSachBoPhan();
            DropDownBoPhan.DataValueField = "ID";
            DropDownBoPhan.DataTextField = "DepName";
            DropDownBoPhan.DataBind();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string mabophan=DropDownBoPhan.SelectedValue.ToString();
            string macongty = DropCty.SelectedValue.ToString();
           // string machuquan="CQDV";
             int idct = int.Parse(Session["mact"].ToString());
            string machucvu = DropDownChucvu.SelectedValue.ToString();
           string maloaiphieu = Session["maloaiphieu"].ToString();
           string maloainguoi =DropDownNguoiKy.SelectedValue.ToString();
           DateTime ngaybatdau = DateTime.Parse(txtNgayBatDau.Text.ToString());
            //string chuquan = idchuquandv.USERID;
           if (cbThongQua.Checked == true)
           {
               string machuquan = "CQDV";
               Busers2 idchuquandv = UserDAO.LayNguoiChuQuanDuyetTheoBoPhan(mabophan, machuquan, macongty);
               if (DropDownNguoiKy.SelectedValue.Equals("2"))
               {
                   
                   ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                   chitiet.IDChiTiet = idct;
                   chitiet.GSBH = macongty;
                   chitiet.IDChucVu = machucvu;
                   chitiet.NgayBatdau = ngaybatdau;
                   chitiet.IDNguoiKy = machucvu;
                   chitiet.DonViThongQua = mabophan;
                   chitiet.IDLoaiNguoiKy =int.Parse(maloainguoi);
                   ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
               }
               else
               {
                   if (DropDownNguoiKy.SelectedValue.Equals("3"))
                   {
                       //Buser laychucvu = UserBUS.LayNguoiDuyetTheoChucVu(machucvu, macongty);
                       ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                       chitiet.IDChiTiet = idct;
                       chitiet.GSBH = macongty;
                       chitiet.IDChucVu = machucvu;
                       chitiet.NgayBatdau = ngaybatdau;
                       chitiet.IDNguoiKy = machucvu;
                       chitiet.DonViThongQua = mabophan;
                       chitiet.IDLoaiNguoiKy = int.Parse(maloainguoi);
                       ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
                   }
                   else
                   {
                       if (DropDownNguoiKy.SelectedValue.Equals("4"))
                       {
                           Busers2 laynguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(txtNguoicodinh.Text, macongty);
                           ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                           chitiet.IDChiTiet = idct;
                           chitiet.GSBH = macongty;
                            chitiet.IDChucVu = laynguoiduyet.IDChucVu;
                          // chitiet.abtype = maloaiphieu;
                           chitiet.NgayBatdau = ngaybatdau;
                           chitiet.DonViThongQua = mabophan;
                           chitiet.IDNguoiKy = txtNguoicodinh.Text;
                           chitiet.IDLoaiNguoiKy = int.Parse(maloainguoi);
                           ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
                       }
                   }
               }
           }
           else
           {
               if (DropDownNguoiKy.SelectedValue.Equals("2"))
               {

                   ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                   chitiet.IDChiTiet = idct;
                   chitiet.GSBH = macongty;
                   chitiet.IDChucVu = machucvu;
                  
                   chitiet.IDNguoiKy = machucvu;
                   chitiet.NgayBatdau = ngaybatdau;
                   chitiet.IDLoaiNguoiKy = int.Parse(maloainguoi);
                   ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
               }
               else
               {
                   if (DropDownNguoiKy.SelectedValue.Equals("3"))
                   {
                       //Buser laychucvu = UserBUS.LayNguoiDuyetTheoChucVu(machucvu, macongty);
                       ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                       chitiet.IDChiTiet = idct;
                       chitiet.GSBH = macongty;
                       chitiet.IDChucVu = machucvu;
                       chitiet.NgayBatdau = ngaybatdau;
                       chitiet.IDNguoiKy = machucvu;

                       chitiet.IDLoaiNguoiKy = int.Parse(maloainguoi);
                       ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
                   }
                   else
                   {
                       if (DropDownNguoiKy.SelectedValue.Equals("4"))
                       {
                           Busers2 laynguoiduyet = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(txtNguoicodinh.Text, macongty);
                           ChiTietLoaiPhieu chitiet = new ChiTietLoaiPhieu();
                           chitiet.IDChiTiet = idct;
                           chitiet.GSBH = macongty;
                           chitiet.IDChucVu = laynguoiduyet.IDChucVu;
                           // chitiet.abtype = maloaiphieu;
                           chitiet.NgayBatdau = ngaybatdau;
                           chitiet.IDNguoiKy = txtNguoicodinh.Text;
                           chitiet.IDLoaiNguoiKy = int.Parse(maloainguoi);
                           ChiTietLoaiPhieuBUS.ThemChiTietLoaiPhieu(chitiet);
                       }
                   }
               }
           }
           HienThiDanhSach();
           DropDownBoPhan.Enabled = true;
           DropDownNguoiKy.Enabled = true;
           Response.Redirect("Chitietloaiky.aspx");
        }

        protected void cbThongQua_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbThongQua.Checked == true)
            //{
            //    DropDownChucvu.Enabled = true;
            //    DropDownBoPhan.Enabled = true;
            //    DropDownNguoiKy.Enabled = true;

            //}
            //else
            //{
            //    DropDownBoPhan.Enabled = false;
            //    DropDownNguoiKy.Enabled = false;
            //}
        }

        protected void DropDownNguoiKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DropDownNguoiKy.SelectedValue.Equals("CV"))
            //{
            //    DropDownChucvu.Enabled = true;
            //}
            //else
            //{
            //    if (DropDownNguoiKy.SelectedValue.Equals("NCD"))
            //    {
            //        txtNguoicodinh.Enabled = true;
            //    }
            //    else
            //    {
            //        if (DropDownNguoiKy.SelectedValue.Equals("NCD"))
            //        {
            //            string macongty=DropCty.SelectedValue.ToString();
            //            Buser nguoicodinh = UserBUS.LayNguoiDuyetTheoMaNguoiDuyet(txtNguoicodinh.Text, macongty);
            //            lbNguoiCoDinh.Text = nguoicodinh.USERNAME;
            //        }
            //    }
            //}
        }

        protected void btnQuaylai_Click(object sender, EventArgs e)
        {
            Response.Redirect("Chitietloaiky.aspx");
        }
    }
}