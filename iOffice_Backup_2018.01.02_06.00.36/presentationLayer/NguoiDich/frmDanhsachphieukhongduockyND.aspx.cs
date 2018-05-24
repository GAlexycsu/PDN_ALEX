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
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmDanhsachphieukhongduockyND : LanguegeBus
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
            string manguoidung = Session["user"].ToString();
            string macongty = Session["congty"].ToString();
            List<Abcon> QryPhieu = AbconDAO.LayDanhDanhPhieuKhongDuyetTheoNguoiTao(manguoidung, macongty);
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;

            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
            }
            if (QryPhieu.Count() == 0)
            {
                return;
            }
            else
            {
                if (!IsPostBack)
                {
                    HienThiDanhSach();

                }
                string strNgonngu = (string)Session["languege"];
                if (strNgonngu != null)
                {
                    LayngonNgu(27, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoGridView();
            }
           
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public override void GanNgonNguVaoGridView()
        {


            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
                GridView1.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
                GridView1.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
                GridView1.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
                GridView1.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
                GridView1.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
                GridView1.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
                GridView1.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
                GridView1.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView2.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
                GridView2.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
                GridView2.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
                GridView2.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
                GridView2.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
                GridView2.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
                GridView2.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
                GridView2.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
                GridView2.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.HeaderRow.Cells[1].Text = hasLanguege["abtype"].ToString();
                GridView1.HeaderRow.Cells[2].Text = hasLanguege["abname27"].ToString();
                GridView1.HeaderRow.Cells[3].Text = hasLanguege["pdno27"].ToString();
                GridView1.HeaderRow.Cells[4].Text = hasLanguege["mytitle27"].ToString();
                GridView1.HeaderRow.Cells[5].Text = hasLanguege["YnName27"].ToString();
                GridView1.HeaderRow.Cells[6].Text = hasLanguege["NameABC27"].ToString();
                GridView1.HeaderRow.Cells[7].Text = hasLanguege["USERNAME27"].ToString();
                GridView1.HeaderRow.Cells[8].Text = hasLanguege["ID27"].ToString();
                GridView1.HeaderRow.Cells[9].Text = hasLanguege["DepName27"].ToString();
            }

        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            //if (ngonngu == "lbl_VN")
            //{
            //    GridView1.DataSource = db.DanhSachPhieuKhongDuyetTheoNguoiTao(macongty, manguoidung);
            //    GridView1.DataBind();
            //}
            //else if (ngonngu == "lbl_TW")
            //{
            //    GridView2.DataSource = db.DanhSachPhieuKhongDuyetTheoNguoiTaoTW(macongty, manguoidung);
            //    GridView2.DataBind();
            //}
            //else if (ngonngu == "lbl_EN")
            //{
            //    GridView1.DataSource = db.DanhSachPhieuKhongDuyetTheoNguoiTao(macongty, manguoidung);
            //    GridView1.DataBind();
            //}

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            Label lbMaLoaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string maloaiphieu = lbMaLoaiPhieu.Text.Trim();
            Session["maloaiphieu"] = maloaiphieu;
            string loaiphieu = row.Cells[2].Text;
            Session["tenloaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[9].Text;
            Session["bophan"] = bophan;
            Label lblMaBP = (Label)row.FindControl("lblMaDV");
            string mabophan = lblMaBP.Text.Trim();
            Session["mabophan"] = mabophan;
            // Response.Redirect("~/presentationLayer/ApproveUser/frmDetails.aspx");
            if (maloaiphieu == "PDN2")
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
            GridViewRow row = GridView2.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            Label lblMaLoaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string maloaiphieu = lblMaLoaiPhieu.Text.Trim();
            Session["maloaiphieu"] = maloaiphieu;
            string loaiphieu = row.Cells[2].Text;
            Session["tenloaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[9].Text;
            Session["bophan"] = bophan;
            Label lblMaDV = (Label)row.FindControl("lblMaDV");
            string mabophan = lblMaDV.Text.Trim();
            Session["mabophan"] = mabophan;
            // Response.Redirect("~/presentationLayer/ApproveUser/frmDetails.aspx");
            if (maloaiphieu == "PDN2")
            {
                Response.Redirect("phieumuahangND.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2ND.aspx");
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
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