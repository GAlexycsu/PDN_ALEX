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
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class danhsachphieudadich : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
           
              
                if (!IsPostBack)
                {
                    if (Session["user"] == null)
                    {
                        //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                        Response.Redirect("http://portal.footgear.com.vn");
                    }
                    string strNgonngu = (string)Session["languege"];
                    if (strNgonngu != null)
                    {
                        LayngonNgu(31, strNgonngu);
                    }
                    else
                    {
                        Response.Redirect("http://portal.footgear.com.vn");
                    }
                    
                    GanNgonNguVaoGridView();
                    HienThiDanhSachPhieuDaDich();
                    

                
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
                GridView1.Columns[1].HeaderText = hasLanguege["pdno31"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle31"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME31"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate2"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["pdno31"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle31"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME31"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate2"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["pdno31"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle31"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME31"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate2"].ToString();
            }
        }
        private void HienThiDanhSachPhieuDaDich()
        {
            string macongty = Session["congty"].ToString();
           
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["user"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.QryPhieuDaDichTheoNguoiTao(manguoidung,macongty);
                GridView1.DataBind();
            }

            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.QryPhieuDaDichTheoNguoiTaoTW(manguoidung,macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.QryPhieuDaDichTheoNguoiTao(manguoidung,macongty);
                GridView1.DataBind();
            }
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[1].Text;
            Session["maphieu"] = maphieu;
            string macongty = Session["congty"].ToString();
            pdna timphieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            string maloaiphieu = timphieu.Abtype;
            Session["maloaiphieu"] = maloaiphieu;
            if (timphieu != null && timphieu.Abtype == "PDN2")
            {
                Response.Redirect("frmChitietphieumuahangdich.aspx");
            }
            else
            {
                Response.Redirect("chitietphieudadich.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));

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
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));

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
            HienThiDanhSachPhieuDaDich();
        }

     
    }
}