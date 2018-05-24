using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmDanhsachphieudaduyetND : LanguegeBus
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
            
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(26, strNgonngu);
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
           

                if (!IsPostBack)
                {
                   
                    GanNgonNguVaoGridView();
                    HienThiDanhSach();

                }

           
            
        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            //if (ngonngu == "lbl_VN")
            //{
            //    GridView1.DataSource = db.DanhSachPhieuDaDuyetTheoNguoiTao(macongty, manguoidung);
            //    GridView1.DataBind();
            //}
            //else if (ngonngu == "lbl_TW")
            //{
            //    GridView2.DataSource = db.DanhSachPhieuDaDuyetTheoNguoiTaoTW(macongty, manguoidung);
            //    GridView2.DataBind();
            //}
            //else if (ngonngu == "lbl_EN")
            //{
            //    GridView1.DataSource = db.DanhSachPhieuDaDuyetTheoNguoiTao(macongty, manguoidung);
            //    GridView1.DataBind();
            //}

        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[0].HeaderText = hasLanguege["abtype26"].ToString();
                GridView1.Columns[1].HeaderText = hasLanguege["abname26"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno26"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName26"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[7].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["DepName26"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.Columns[0].HeaderText = hasLanguege["abtype26"].ToString();
                GridView2.Columns[1].HeaderText = hasLanguege["abname26"].ToString();
                GridView2.Columns[2].HeaderText = hasLanguege["pdno26"].ToString();
                GridView2.Columns[3].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView2.Columns[4].HeaderText = hasLanguege["YnName26"].ToString();
                GridView2.Columns[5].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView2.Columns[6].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[7].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["DepName26"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[0].HeaderText = hasLanguege["abtype26"].ToString();
                GridView1.Columns[1].HeaderText = hasLanguege["abname26"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["pdno26"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["YnName26"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[7].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["DepName26"].ToString();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[2].Text;
            Session["maphieu"] = maphieu;
            Label lbMaLoaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string maloaiphieu = lbMaLoaiPhieu.Text.Trim();
            string tenloaiphieu = row.Cells[1].Text;
            Session["tenloaiphieu"] = tenloaiphieu;
            Session["loaiphieu"] = maloaiphieu;
            string tieude = row.Cells[3].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[8].Text;
            Session["bophan"] = bophan;
            //  Response.Redirect("frmDetails2.aspx");
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, manguoidung, macongty);
            if (chitietduyet.Abtype == "PDN2")
            {
                Response.Redirect("phieumuahangND.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2ND.aspx");
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            GridViewRow row = GridView2.SelectedRow;
            string maphieu = row.Cells[2].Text;
            Session["maphieu"] = maphieu;
            Label lbMaLoaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string loaiphieu = lbMaLoaiPhieu.Text.Trim();
            string tenloaiphieu = row.Cells[1].Text;
            Session["tenloaiphieu"] = tenloaiphieu;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[3].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[8].Text;
            Session["bophan"] = bophan;
            //  Response.Redirect("frmDetails2.aspx");
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, manguoidung, macongty);
            if (chitietduyet.Abtype == "PDN2")
            {
                Response.Redirect("phieumuahangND.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2ND.aspx");
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
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[10].Controls[0]);

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
                    LinkButton lbtn1 = ((LinkButton)e.Row.Cells[10].Controls[0]);

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

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

    }
}