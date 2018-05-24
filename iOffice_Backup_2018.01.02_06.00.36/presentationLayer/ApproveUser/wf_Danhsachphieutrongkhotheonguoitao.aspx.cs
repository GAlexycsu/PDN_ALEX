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
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class wf_Danhsachphieutrongkhotheonguoitao : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                txtToDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                // LayngonNgu(29);

                //  GanNgonNguVaoConTrol();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();

                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    divgrid2.Visible = false;
                    divgrid1.Visible = true;

                }
                else if (ngonngu == "lbl_TW")
                {
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    divgrid1.Visible = false;
                    divgrid2.Visible = true;
                }
                else if (ngonngu == "lbl_EN")
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    divgrid1.Visible = true;
                    divgrid2.Visible = false;
                }
                //GanNgonNguVaoGridView();
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
               
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                
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
            DateTime pTuNgay = DateTime.Parse(txtFromDate.Text.Trim());
            DateTime pDenNgay = DateTime.Parse(txtToDate.Text.Trim());
            if (ngonngu == "lbl_VN")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTao(macongty, manguoidung, pTuNgay, pDenNgay);
                if (dt.Rows.Count != 0)
                {
                    divgrid1.Visible = true;
                    divgrid2.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    divgrid1.Visible = false;
                    divgrid2.Visible = false;
                }

            }
            else if (ngonngu == "lbl_TW")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTaoTW(macongty, manguoidung, pTuNgay, pDenNgay);
                if (dt.Rows.Count != 0)
                {
                    divgrid2.Visible = true;
                    divgrid1.Visible = false;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                else
                {
                    divgrid1.Visible = false;
                    divgrid2.Visible = false;
                }
            }
            else if (ngonngu == "lbl_EN")
            {
                DataTable dt = dal.QryPhieuTrongKhoTheoNguoiTao(macongty, manguoidung, pTuNgay, pDenNgay);
                if (dt.Rows.Count != 0)
                {
                    divgrid1.Visible = true;
                    divgrid2.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                else
                {
                    divgrid2.Visible = false;
                    divgrid1.Visible = false;
                }
            }

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            Label lblMaPhieu = (Label)GridView2.Rows[e.RowIndex].FindControl("lblpdno");
            string UserID = Session["UserID"].ToString();
            string GSBH = Session["congty"].ToString();
            DataTable dt = dal.LayTrangThaiDuyetTheoBangTrangThai(GSBH, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count != 0)
            {
                lblTrangThai.Text = dt.Rows[0]["YnName"].ToString();

            }
            else
            {
                DataTable dtt = dal.LayTrangThaiTheoBangPDNA(GSBH, lblMaPhieu.Text.Trim());
                if (dtt.Rows.Count != 0)
                {
                    lblTrangThai.Text = dtt.Rows[0]["YnName"].ToString();
                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblpdno");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            pdna timphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), UserID, macongty, false);
            if (timphieu != null)
            {
                Session["maphieu"] = timphieu.pdno;
                Session["loaiphieu"] = timphieu.Abtype;
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahang.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmChitietphieumuahangdich.aspx");
                    }
                    else if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }

                }
                else
                {
                    if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadich.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadich.aspx");
                    }
                    else if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                }
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GridViewRow row=GridView1.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblpdno");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            pdna timphieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(lblMaPhieu.Text.Trim(), UserID, macongty, false);
            if (timphieu != null)
            {
                Session["maphieu"] = timphieu.pdno;
                Session["loaiphieu"] = timphieu.Abtype;
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahang.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmChitietphieumuahangdich.aspx");
                    }
                    else if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahang.aspx");
                    }

                }
                else
                {
                    if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadich.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("FrmViewCB.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadich.aspx");
                    }
                    else if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

    }
}