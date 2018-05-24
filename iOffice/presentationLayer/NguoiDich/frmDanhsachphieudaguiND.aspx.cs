using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmDanhsachphieudaguiND : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(13, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }

            if (strNgonngu == "lbl_VN")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;

            }
            else if (strNgonngu == "lbl_TW")
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
            }
            else if (strNgonngu == "lbl_EN")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
            }
            
              
                GanNgonNguVaoGridView();
                if (!IsPostBack)
                {

                    HienThiDanhSach();

                }

            
        }
        private void HienThiDanhSach()
        {
            //string macongty = Session["congty"].ToString();
            //string manguoidung = Session["user"].ToString();
            //string ngonngu = Session["languege"].ToString();
            //if (ngonngu == "lbl_VN")
            //{
            //    GridView1.DataSource = db.DanhSachVanBanDaGuiTheoNguoiGui(manguoidung, macongty);
            //    GridView1.DataBind();
            //}
            //else if (ngonngu == "lbl_TW")
            //{
            //    GridView2.DataSource = db.DanhSachVanBanDaGuiTheoNguoiGuiTW(manguoidung, macongty);
            //    GridView2.DataBind();
            //}
            //else if (ngonngu == "lbl_EN")
            //{
            //    GridView1.DataSource = db.DanhSachVanBanDaGuiTheoNguoiGui(manguoidung, macongty);
            //    GridView1.DataBind();
            //}
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[2].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle1"].ToString();
                //GridView1.HeaderRow.Cells[4].Text = hasLanguege["YnName"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[2].HeaderText = hasLanguege["abname1"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["pdno1"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["mytitle1"].ToString();
                //GridView1.HeaderRow.Cells[4].Text = hasLanguege["YnName"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView2.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[2].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle1"].ToString();
                //GridView1.HeaderRow.Cells[4].Text = hasLanguege["YnName"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);
                    LinkButton lbtn2 = ((LinkButton)e.Row.Cells[1].Controls[0]);

                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Nội Dung";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";
                        lbtn2.Text = "内容";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Nội Dung";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string maphieu = (string)GridView1.Rows[e.RowIndex].Cells[3].Text;
            Session["maphieu"] = maphieu;
            pdna phieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(maphieu, manguoidung, macongty, true);
            if (phieu.Abtype == "PDN2")
            {
                Response.Redirect("chitietphieugui2ND.aspx");
            }
            else
            {
                Response.Redirect("chitietphieugui1ND.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            string loaiphieu = row.Cells[2].Text;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[7].Text;
            Session["bophan"] = bophan;
            Response.Redirect("tinhtrangtheovanbanND.aspx");
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[0].Controls[0]);
                    LinkButton lbtn2 = ((LinkButton)e.Row.Cells[1].Controls[0]);

                    if (ngonngu == "lbl_VN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Nội Dung";

                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbtn1.Text = "详情";
                        lbtn2.Text = "内容";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbtn1.Text = "Chi Tiết";
                        lbtn2.Text = "Nội Dung";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string maphieu = (string)GridView2.Rows[e.RowIndex].Cells[3].Text;
            Session["maphieu"] = maphieu;
            pdna phieu = pnaDAO.TimKiemVanBanTheoMaNguoiTaoCongTy(maphieu, manguoidung, macongty, true);
            if (phieu.Abtype == "PDN2")
            {
                Response.Redirect("chitietphieugui2ND.aspx");
            }
            else
            {
                Response.Redirect("chitietphieugui1ND.aspx");
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            string loaiphieu = row.Cells[2].Text;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[7].Text;
            Session["bophan"] = bophan;
            Response.Redirect("tinhtrangtheovanbanND.aspx");
        }
    }
}