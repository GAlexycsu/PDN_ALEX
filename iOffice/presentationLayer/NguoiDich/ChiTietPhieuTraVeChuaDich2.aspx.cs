using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class ChiTietPhieuTraVeChuaDich2 : System.Web.UI.Page
    {
        int STT = 1;
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal = new dalPDN();
        abconDAL dalAbcon = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                HienThiDanhSach();
                HienThiPhieuMuaHang();
                btncomplete.Enabled = false;
                btncomplete.Attributes.CssStyle.Add("opacity", "0.5");
            }
        }
        public void HienThiDanhSach()
        {
            dalPDN dal = new dalPDN();
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();

            string manguoidich = Session["user"].ToString();

            DataTable dt = dal.TimPhieuTheoMaNguoiDich(idphieu, macongty, manguoidich);
            if (dt.Rows.Count > 0)
            {
                string madonvi = dt.Rows[0]["pddepid"].ToString();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString();

                abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;
                txtNguoiDUyet.Text = dt.Rows[0]["CFMID1"].ToString();
                lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                BDepartment timdonvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                lbldonvidenghi.Text = timdonvi.DepName;
                lblsophieu.Text = idphieu;
                txtMucDich.Text = dt.Rows[0]["UseIntent"].ToString();
                lblTieuDe.Text = dt.Rows[0]["mytitle"].ToString();
                txtTieuDe.Text = dt.Rows[0]["pdnsubject"].ToString();
                string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                string thang = dinhdang.Substring(3, 2);
                string ngay = dinhdang.Substring(0, 2);
                string nam = dinhdang.Substring(6, 4);
                lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";


            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Label lblMaCty1 = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGSBH");
            Label lbMaPhieu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblPDNO");
            Label lbMaHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLBH");
            Label lbTenHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblMemo0");
            Label lbSize = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblSize");
            Label lbDonVT = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblDWBH");
            Label lbGhiChu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLMemo");
            Label lbSoLuong = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblQty");

            lblTenHangD.Text = lbTenHang.Text;
            lblGhiChuD.Text = lbGhiChu.Text;
            //txtAutoComplete.Text = lbTenHang.Text;
            Session["themhang"] = "them";
            Session["mahangd"] = lbMaHang.Text.Trim();
            Session["sizeD"] = lbSize.Text.Trim();
            Session["donvitinhD"] = lbDonVT.Text.Trim();
            Session["SoLuongD"] = lbSoLuong.Text.Trim();
            Session["tenhang"] = lbTenHang.Text.Trim();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            dalPDN dal = new dalPDN();
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string themhang = (string)Session["themhang"];
            string mahangd = (string)Session["mahangd"];
            string sizeD = (string)Session["sizeD"];
            string donvitinhD = (string)Session["donvitinhD"];
            string SoLuongD = (string)Session["SoLuongD"];
            string tenhang1 = txtAutoComplete.Text;
            string tenhang2 = (string)Session["tenhang"];
            string ghichu = txtGhiChu.Text;
            string tenhang = tenhang2 + tenhang1;
            if (themhang != null)
            {
                dal.CapNhatPhieuMuaHangDich(macongty, mahangd, maphieu, sizeD, tenhang, ghichu);
                //  HienThiPhieuMuaHang();
                HienThiDanhSach();
                btncomplete.Enabled = true;
                btncomplete.Attributes.CssStyle.Add("opacity", "100");
            }
            txtAutoComplete.Text = "";
            txtGhiChu.Text = "";
            Session.Remove("themhang");
            Session.Remove("mahangd");
            Session.Remove("sizeD");
            Session.Remove("donvitinhD");
            Session.Remove("tenhang");
            Session.Remove("SoLuongD");
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void btncomplete_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string ngaydich = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
            string maphieu = lblsophieu.Text;
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["user"].ToString();
            string mucdichdudung = txtMucDich.Text;
            int Yn=4;
            //db.CapNhatPhieuMuaHangDich(maphieu, macongty,txtTieuDe.Text, DateTime.Parse(ngaydich), manguoidung,mucdichdudung, trangthaidich);
            
            dal.CapNhatPhieuDichTraVe(manguoidung, macongty, maphieu, txtTieuDe.Text.Trim(), txtMucDich.Text.Trim(), date, Yn);
            dalAbcon.CapNhatTrangThaiCuaPhieuCoYKien(maphieu, macongty, Yn, txtNguoiDUyet.Text.Trim());
            Response.Redirect("danhsachphieuchuadichND.aspx");
          
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieuchuadichND.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);

                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Dịch Phiếu";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "Translate";

                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Translate";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}