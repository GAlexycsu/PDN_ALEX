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
namespace iOffice.presentationLayer.Users
{
    public partial class frmChitietphieumuahangdichNV :LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDNLink dal = new dalPDNLink();
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
                ShowFileDinhKem();
            }
           
        }
        private void ShowFileDinhKem()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dal.QryFileDinhKem(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                divUpload2.Visible = true;
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
            }
            else
            {
                divUpload2.Visible = false;
            }
        }
        public void HienThiDanhSachMuaHang()
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
            
            string manguoidung = Session["user"].ToString();

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu,macongty, true);
                if (phieu == null)
                {
                    BDepartment donvi = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
                    string noidung = Session["noidung"].ToString();
                    string ngaytao = Session["ngaytao"].ToString();
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;

                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    txtIDLoaiphieu.Text = loaiphieu.abtype;
                    txtIDDonVi.Text = donvi.ID;
                    lbldonvidenghi.Text = donvi.DepName;
                    lblsophieu.Text = idphieu;


                    DateTime date = DateTime.Now;
                    string dinhdang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }
                else
                {
                    BDepartment donvi = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    txtIDLoaiphieu.Text = loaiphieu.abtype;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = donvi.DepName;
                    lblsophieu.Text = idphieu;
                    lblMucDichSuDung.Text = phieu.UseIntent;
                    txtIDDonVi.Text = donvi.ID;
                    string dinhdang = phieu.CFMDate0.ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }

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
            Response.Redirect("frmTrinhDuyet.aspx");
        }

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachvanbandadichNV.aspx");
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
        public override void GanNgonNguVaoConTrol()
        {
            btnUndo.Text = hasLanguege["btnUndo"].ToString();
            btnContinus.Text = hasLanguege["btnContinus"].ToString();
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
    }

}