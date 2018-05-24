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
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class danhsachphieucattrongkhoNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                txtFromDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(29,strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                    GanNgonNguVaoGridView();
                    GanNgonNguVaoConTrol();       
                    HienThiDanhSach();
            }
        }
        public override void GanNgonNguVaoGridView()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName29"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC29"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME29"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName29"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["YnName29"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC29"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME29"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["DepName29"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName29"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC29"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME29"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName29"].ToString();
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                Label1.Text = "Danh sách phiếu đã duyệt lưu trong kho";
            }
            else if (ngonngu == "lbl_TW")
            {
                Label1.Text = "已经审核资料存在资料库";
            }
            else if (ngonngu == "lbl_EN")
            {
                Label1.Text = "List of PDN in  warehouse ";
            }
        }
        private void HienThiDanhSach()
        {
            dalPDN dal = new dalPDN();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            DateTime fromDate = DateTime.Parse(txtFromDate.Text.Trim());
            DateTime ToDate = DateTime.Parse(txtToDate.Text.Trim());
            if (ngonngu == "lbl_VN")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTao(macongty, manguoidung, fromDate, ToDate);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
               
            }
            else if (ngonngu == "lbl_TW")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTaoTW(macongty, manguoidung, fromDate, ToDate);
                if (dt.Rows.Count > 0)
                {
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
            }
            else if (ngonngu == "lbl_EN")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTaoTW(macongty, manguoidung, fromDate, ToDate);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[2].Text;
            Session["maphieu"] = maphieu;
            string loaiphieu = row.Cells[1].Text;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[3].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[6].Text;
            Session["bophan"] = bophan;
            Response.Redirect("frmDetails2NV.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            string macongty = Session["congty"].ToString();
            string maNV = Session["UserID"].ToString();
            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            pdna timphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), maNV, macongty, true);
            if (timphieu != null)
            {
                Session["maphieu"] = timphieu.pdno;
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmChitietphieumuahangdichNV.aspx");
                    }
                }
                else
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadichNV.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadichNV.aspx");
                    }
                }
            }
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
                        lbtn1.Text = "Chi Tiết";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";

                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Chi Tiết";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);

                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";

                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Chi Tiết";

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSoPhieu");
            string maNV = Session["UserID"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dal.LayTrangThaiTheoBangPDNA(macongty, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                lblTrangThai.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            Label lblMaPhieu = (Label)GridView2.Rows[e.RowIndex].FindControl("lblSoPhieu");
            string maCongTy = Session["congty"].ToString();
            DataTable dt = dal.LayTrangThaiTheoBangPDNA(maCongTy, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                LblTrangThai1.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

            GridViewRow row = GridView1.SelectedRow;
            string macongty = Session["congty"].ToString();
            string maNV = Session["UserID"].ToString();
            Label lblMaPhieu = (Label)row.FindControl("lblSoPhieu");
            pdna timphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), maNV, macongty, true);
            if (timphieu != null)
            {
                Session["maphieu"] = timphieu.pdno;
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahangNV.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmChitietphieumuahangdichNV.aspx");
                    }
                }
                else
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2NV.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadichNV.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmView.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadichNV.aspx");
                    }
                }
            }

        }

    }
}