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
    public partial class frmchitietphieumuahangNV : System.Web.UI.Page
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
                divUpload2.Visible = false;
                HienThi();
                HienThiDanhSachMuaHang();
                HienThiThongTinBiHuy();
                ShowFileDinhKem();
            }
            TextBox1.Visible = false;
        }
        private void ShowFileDinhKem()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dal.QryFileDinhKem(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
                divUpload2.Visible = true;
            }
            else
            {
                divUpload2.Visible = false;
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        private void HienThiThongTinBiHuy()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
            if (phieu != null)
            {
                string sophieucu = phieu.pdno;
                Label1Sophieucu.Visible = true;
                Label2cophieucu.Visible = true;

                Session["sophieucu"] = sophieucu;
                Label2cophieucu.Text = phieu.pdno;
            }
            else
            {
                Label1Sophieucu.Visible = false;
                Label2cophieucu.Visible = false;
            }
        }
        private void HienThi()
        {
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();

            //string noidung = Session["noidung"].ToString();
            //string ngaytao = Session["ngaythang"].ToString();
            string user = Session["user"].ToString();
            string bp = Session["bp"].ToString();
            string congty = Session["congty"].ToString();
            BDepartment bophan = BDepartmentBUS.TimMaDonVi(bp, congty);
            //string loaiphieu = Session["loaiphieu"].ToString();
            pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, congty, true);
            abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);

            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;

            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
            //    lbBoPhan.Text = bophan;
            //    lbNoiDung.Text = phieu.pdmemovn.ToString();
            //    lbNgay.Text =Convert.ToString(phieu.CFMDate0);
            //  Buser users = UserBUS.TimMaNhanVienTheoBoPhan(user, bp);
            lblTieuDe.Text = phieu.mytitle + phieu.pdnsubject;
            lbldonvidenghi.Text = bophan.DepName;
            lbSoPhieu.Text = idphieu;
            lblMucDichSuDung.Text = phieu.UseIntent;
           
            //lbNgay.Text = phieu.CFMDate0.ToString();
            string dinhdang = phieu.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";


            Busers2 user0 = AbconBUS.LayMaNguoiTaoTheoIDVanBan(idphieu, congty);
            if (user0 != null)
            {
                TextBox1.Text = user0.USERID;
                //ImageLevel0.ImageUrl = users.signatue;
                ImageLevel0.Width = 100;
                ImageLevel0.Height = 100;
                ImageLevel0.ImageUrl = "~/MyPhoto.ashx?USERID=" + TextBox1.Text;
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
                if (dt.Rows.Count < 6)
                {
                    DataRow dr = dt.NewRow();
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    DataRow dr3 = dt.NewRow();
                    DataRow dr4 = dt.NewRow();
                    DataRow dr5 = dt.NewRow();
                    DataRow dr6 = dt.NewRow();
                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    dt.Rows.Add(dr3);
                    dt.Rows.Add(dr4);
                    dt.Rows.Add(dr5);
                    dt.Rows.Add(dr6);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnKhoiPhuc_Click(object sender, EventArgs e)
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
    }
}