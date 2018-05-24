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
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmchitietphieumuahang : LanguegeBus
    {
        int STT = 1;
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDNLink dal = new dalPDNLink();
        dalPDN dalPDN = new dalPDN();
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
                divUpload2.Visible = true;
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
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
           
            string user = Session["user"].ToString();
            //string bp = Session["bp"].ToString();
            string congty = Session["congty"].ToString();
         
           
            //pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, congty, true);
            DataTable dt = dalPDN.TimPhieuTheoMaPhieu(idphieu, congty);
            if (dt.Rows.Count > 0)
            {
                string madonvi = dt.Rows[0]["pddepid"].ToString();
                string maloaip = dt.Rows[0]["Abtype"].ToString();
                int dout = int.Parse(dt.Rows[0]["ABC"].ToString());
                BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, congty);
                abill loaiphieu = abillBUS.SearchAbillByID(maloaip);

                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;

                lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;

                lbldonvidenghi.Text = bophan.DepName;
                lbSoPhieu.Text = idphieu;
                lblMucDichSuDung.Text = dt.Rows[0]["UseIntent"].ToString();
                lblTieuDe.Text = dt.Rows[0]["mytitle"].ToString() + "-" + dt.Rows[0]["pdnsubject"].ToString();
                //lbNgay.Text = phieu.CFMDate0.ToString();
                string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                string thang = dinhdang.Substring(3, 2);
                string ngay = dinhdang.Substring(0, 2);
                string nam = dinhdang.Substring(6, 4);
                lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            }

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

        protected void btnContinues_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/ApproveUser/frmApproval.aspx");
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/presentationLayer/ApproveUser/DanhSachVanBanDen.aspx");
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