using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.DTO;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmTaoPhieuND : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!Page.IsPostBack)
            {
                HienThiBoPhan();
                HienThiDropDonvi();
                HienThiLoaiPhieu();
            }
            //LayDuLieuNgonNgu();
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(1, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
           
        }
        private void HienThiDropDonvi()
        {
            string congty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            BDepartment bp = BDepartmentDAO.LayBoPhanTheoMaNguoiDuyet(user, congty);
            if (bp != null)
            {
                DropDonVi.SelectedValue = bp.ID;
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            try
            {
                btnTiepTu.Text = hasLanguege["btnTiepTu"].ToString();
                btnLuuTam.Text = hasLanguege["btnLuuTam"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void HienThiBoPhan()
        {
            string congty = Session["congty"].ToString();
            DropDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropDonVi.DataValueField = "ID";
            DropDonVi.DataTextField = "DepName";
            DropDonVi.DataBind();
        }
        private void HienThiLoaiPhieu()
        {
            string ngonngu = Session["languege"].ToString();
            DropLoaiPhieu.DataSource = abillBUS.ListBill();
            DropLoaiPhieu.DataValueField = "abtype";
            if (ngonngu == "lbl_VN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropLoaiPhieu.DataTextField = "abnameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }

            DropLoaiPhieu.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date=DateTime.Today;
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();
            string maphieu = "";
            if (dt.Rows.Count != 0 && aa!="")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") +"00"+ 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();
            string ngonngu = Session["languege"].ToString();
            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;
            string noidungdich = CKEditorControl2.Text;
            string bp = DropDonVi.SelectedItem.Text;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;
            string congty = Session["congty"].ToString();
            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
            //string idphieu = Session["maphieu"].ToString();
            string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();
            

            Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, bophan,congty);
            if (us == null)
            {
                if (ngonngu == "lbl_VN")
                {
                    lbthongbao.Text = "Người dùng này không thuộc bộ phận " + bp;
                }
                else if (ngonngu == "lbl_TW")
                {
                    lbthongbao.Text = "该用户不属于部门 " + bp;
                }
                else if (ngonngu == "lbl_EN")
                {
                    lbthongbao.Text = "The user does not belong to the department" + bp;
                }
            }
            else
            {
                pdna phieun = new pdna();
                {
                    phieun.GSBH = congty;
                    phieun.pdno = maphieu;
                    phieun.pddepid = bophan;
                    phieun.mytitle = tieude;
                    phieun.pdmemovn = noidung;
                    phieun.NoiDungDich = noidungdich;
                    phieun.CFMDate0 = DateTime.Parse(ngaythang);
                    phieun.USERID = user;
                    phieun.Abtype = DropLoaiPhieu.SelectedValue;
                    phieun.bixoa = false;
                    phieun.trangthaidich = true;
                    phieun.IdnguoiDich = user;
                    phieun.CFMID0 = user;
                    phieun.YN = 6;
                    phieun.CFMDate1 = DateTime.Parse(ngaythang);
                    phieun.USERDATE = DateTime.Parse(ngaythang);
                }
                pdnaBUS.InsertPDNA(phieun);
                Session["loaiP"] = loaiP;
                Session["loaiphieu"] = loaiphieu;
                Session["maphieu"] = maphieu;
                Session["bp"] = bophan;
                Session["bophan"] = bp;
                Session["noidung"] = noidung;
                Session["ngaytao"] = ngaythang;
                Session["tieude"] = tieude;
                Response.Redirect("frmPreviewND.aspx");

            }
        }

        protected void DropDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bophan = DropDonVi.SelectedValue.ToString();
            string tenbophan = DropDonVi.SelectedIndex.ToString();
            Session["bophan"] = bophan;
        }

        protected void DropLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = DropLoaiPhieu.SelectedValue.ToString();
            string tenloaiphieu = DropLoaiPhieu.SelectedIndex.ToString();
            Session["loaiphieu"] = loai;
        }

        protected void btnLuuTam_Click(object sender, EventArgs e)
        {
            DateTime date=DateTime.Today;
            dalPDN dal = new dalPDN();
            DataTable dt = dal.DemSoLuongPhieu();
            string aa = dt.Rows[0]["pdno"].ToString().Trim();
            string maphieu = "";
            if (dt.Rows.Count != 0 && aa!="")
            {
                string dem = (int.Parse(aa) + 1).ToString();
                maphieu = dem;
            }
            else
            {
                maphieu = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("yyyyMM") + "00" + 1;
            }
            string bophan = DropDonVi.SelectedItem.Value.ToString();
            string congty = Session["congty"].ToString();
            string tieude = txtTieuDe.Text;
            string noidung = CKEditorControl1.Text;
            string noidungdich = CKEditorControl2.Text;
            string bp = DropDonVi.SelectedItem.Text;
            string loaiP = DropLoaiPhieu.SelectedItem.Text;

            string user = Session["user"].ToString();
            string ngaythang = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
            string ngaythang1 = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("Ngày " + "dd" + "Tháng " + "MM" + "Năm" + "yyyy");
            //string idphieu = Session["maphieu"].ToString();
            string loaiphieu = DropLoaiPhieu.SelectedValue.ToString();
            
            Busers2 us = UserBUS.TimMaNhanVienTheoBoPhan(user, bophan,congty);
            if (us == null)
            {
                lbthongbao.Text = "Người dùng này không nằm trong bộ phận " + bp;
            }
            else
            {
                pdna phieun = new pdna();
                {
                    phieun.GSBH = congty;
                    phieun.pdno = maphieu;
                    phieun.pddepid = bophan;
                    phieun.mytitle = tieude;
                    phieun.pdmemovn = noidung;
                    phieun.NoiDungDich = noidungdich;
                    phieun.CFMDate0 = DateTime.Parse(ngaythang);
                    phieun.USERID = user;
                    phieun.Abtype = DropLoaiPhieu.SelectedValue;
                    phieun.bixoa = false;
                    phieun.trangthaidich = true;
                    phieun.IdnguoiDich = user;
                    phieun.CFMID0 = user;
                    phieun.YN = 5;
                    phieun.CFMDate1 = DateTime.Parse(ngaythang);
                    phieun.USERDATE = DateTime.Parse(ngaythang);
                }
                pdnaBUS.InsertPDNA(phieun);
                Response.Redirect("frmDanhsachphieumoikhoitaoND.aspx");

            }

        }
    }
}