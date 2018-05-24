using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data.SqlClient;
using System.Data;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmChitietphieumuahangdich : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                HienThiDanhSachMuaHang();
                HienThiPhieuMuaHang();
            }
            txtIDLoaiphieu.Visible = false;
            txtIDDonVi.Visible = false;
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
                DataRow dr7 = dt.NewRow();
                dt.Rows.Add(dr);
                dt.Rows.Add(dr1);
                dt.Rows.Add(dr2);
                dt.Rows.Add(dr3);
                dt.Rows.Add(dr4);
                dt.Rows.Add(dr5);
                dt.Rows.Add(dr6);
                dt.Rows.Add(dr7);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();

            string manguoidung = Session["user"].ToString();
            DataTable dt = dal.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {

                string ngaythang = dt.Rows[0]["CFMDate0"].ToString();
                string madonvi = dt.Rows[0]["pddepid"].ToString().Trim();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString().Trim();
                string noidung = dt.Rows[0]["pdmemovn"].ToString().Trim();
                string tieude = dt.Rows[0]["mytitle"].ToString().Trim();
                string tieudedich = dt.Rows[0]["pdnsubject"].ToString().Trim();
                string noidungdich = dt.Rows[0]["NoiDungDich"].ToString();
                int Yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                    BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    txtIDLoaiphieu.Text = loaiphieu.abtype;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = donvi.DepName;
                    lblsophieu.Text = idphieu;
                    lblMucDichSuDung.Text = dt.Rows[0]["UseIntent"].ToString();
                    txtIDDonVi.Text = donvi.ID;
                    string dinhdang = ngaythang;
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
               

            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

        protected void btnContinus_Click(object sender, EventArgs e)
        {
            string maloaiphieu = txtIDLoaiphieu.Text;
            string madonvi = txtIDDonVi.Text;
            Session["loaiphieu"] = maloaiphieu;
            Session["bp"] = madonvi;
            Response.Redirect("frmTrinhDuyetCB.aspx");
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnUndo.Text = hasLanguege["btnUndo"].ToString();
            btnContinus.Text = hasLanguege["btnContinus"].ToString();
        }
        protected void btnUndo_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieudadich.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[1].Text;
            Session["maphieu"] = maphieu;
            string macongty = Session["congty"].ToString();
            pdna timphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            string maloaiphieu = timphieu.Abtype;
            Session["loaiphieu"] = maloaiphieu;
        }

    }
}