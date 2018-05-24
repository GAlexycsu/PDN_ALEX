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
    public partial class DanhSachPhieuTrongKhoTheoNguoiDuyet :LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
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

            string macongty=Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            DateTime pTuNgay = DateTime.Parse(txtFromDate.Text.Trim());
            DateTime pDenNgay = DateTime.Parse(txtToDate.Text.Trim());
            if (ngonngu == "lbl_VN")
            {
                DataTable dt = dal.LayTrangDanhSachPhieuTrongKho(macongty, manguoidung,pTuNgay,pDenNgay);
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
                DataTable dt = dal.LayTrangDanhSachPhieuTrongKhoTW(macongty, manguoidung,pTuNgay,pDenNgay);
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
                DataTable dt = dal.LayTrangDanhSachPhieuTrongKho(macongty, manguoidung,pTuNgay,pDenNgay);
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
            Response.Redirect("frmDetails2.aspx");
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            
            string ngonngu = Session["languege"].ToString();
            
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblpdno");
            string macongty = Session["congty"].ToString();
            string maNV = Session["UserID"].ToString();
            Abcon timphieu = AbconDAO.TimMaPhieuTheoNguoiDuyet(lblMaPhieu.Text.Trim(), maNV, macongty);
            Session["maphieu"] = lblMaPhieu.Text.Trim();
            if (timphieu != null)
            {
                if (timphieu.abtype == "PDN2")
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("chitietphieumuahang.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }

                }
                else
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("frmDetails.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                }
            }
          
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
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
     

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal=new dalPDN();
            string UserID = Session["user"].ToString();
            string GSBH = Session["congty"].ToString();
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblpdno");
            DataTable dt = dal.LayTrangThaiCuaPhieuTheoNguoiDuyet(GSBH, lblMaPhieu.Text.Trim(), UserID);
            if (dt.Rows.Count != 0)
            {
                lblTrangThai2.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

       

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);
                    LinkButton lbtn2 = ((LinkButton)e.Row.Cells[0].Controls[0]);
                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Status";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";
                        lbtn2.Text = "Status";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Status";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblMaPhieu = (Label)row.FindControl("lblpdno");
            string macongty = Session["congty"].ToString();
            string maNV = Session["UserID"].ToString();
            Abcon timphieu = AbconDAO.TimMaPhieuTheoNguoiDuyet(lblMaPhieu.Text.Trim(), maNV, macongty);
            Session["maphieu"] = lblMaPhieu.Text.Trim();
            if (timphieu != null)
            {
                if (timphieu.abtype == "PDN2")
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("chitietphieumuahang.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }

                }
                else
                {
                    if (timphieu.Yn == 4)
                    {
                        Response.Redirect("frmDetails.aspx");
                    }
                    else if (timphieu.Yn == 2)
                    {
                        Response.Redirect("phieumuahangD.aspx");
                    }
                    else if (timphieu.Yn == 1)
                    {
                        Response.Redirect("frmDetails2.aspx");
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            string UserID = Session["user"].ToString();
            string GSBH = Session["congty"].ToString();
            Label lblMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblpdno");
            DataTable dt = dal.LayTrangThaiCuaPhieuTheoNguoiDuyet(GSBH, lblMaPhieu.Text.Trim(), UserID);
            if (dt.Rows.Count != 0)
            {
                lblTrangThai1.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}