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
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmDanhsachphieucattrongkhoND : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
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
                LayngonNgu(29, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
                GanNgonNguVaoGridView();
                GanNgonNguVaoConTrol();
                if (!IsPostBack)
                {
                    HienThiDanhSach();
                }
           
            
        }
        public override void GanNgonNguVaoGridView()
        {
                GridView2.Columns[1].HeaderText = hasLanguege["abname29"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["pdno29"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["mytitle29"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["YnName29"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC29"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME29"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["DepName29"].ToString();
        }
        public override void GanNgonNguVaoConTrol()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                Label1.Text = "Danh sách phiếu  lưu trong kho";
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
            DateTime fromdate=DateTime.Parse(txtFromDate.Text.Trim());
            DateTime toDate=DateTime.Parse(txtToDate.Text.Trim());
            DataTable dt = dal.QryPhieuTrongKhoTheoNguoiDich(macongty, manguoidung, fromdate, toDate);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
       

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Label lblMaPhieu=(Label)row.FindControl("lblpdno");
            string UserID=Session["UserID"].ToString();
            string GSBH=Session["congty"].ToString();
            pdna timphieu = pnaDAO.TimKiemMaPhieuTheoNguoiDich(lblMaPhieu.Text.Trim(), GSBH, UserID);
            if (timphieu != null)
            {
                Session["maphieu"] = timphieu.pdno;
                if (timphieu.Abtype == "PDN2")
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("phieumuahangND.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("phieumuahangND.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("frmSuaphieumuahangND.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("frmPreviewND.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("chitietphieudadichND.aspx");
                    }
                }
                else
                {
                    if (timphieu.YN == 1)
                    {
                        Response.Redirect("frmDetails2ND.aspx");
                    }
                    else if (timphieu.YN == 2)
                    {
                        Response.Redirect("frmDetails2ND.aspx");
                    }
                    else if (timphieu.YN == 3)
                    {
                        Response.Redirect("chitietphieuchuadichND.aspx");
                    }
                    else if (timphieu.YN == 5)
                    {
                        Response.Redirect("frmPreviewND.aspx");
                    }
                    else if (timphieu.YN == 6)
                    {
                        Response.Redirect("frmSuaphieumuahangND.aspx");
                    }
                }
            }

            //Response.Redirect("frmDetails2ND.aspx");
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

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dalPDN dal = new dalPDN();
            Label lblMaPhieu = (Label)GridView2.Rows[e.RowIndex].FindControl("lblSoPhieu");
            string macongty = Session["congty"].ToString();
            string UserID = Session["UserID"].ToString();
            DataTable dt = dal.LayTrangThaiTheoBangPDNA(macongty, lblMaPhieu.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                lblTrangThai.Text = dt.Rows[0]["YnName"].ToString();
            }
        }

        
    }
}