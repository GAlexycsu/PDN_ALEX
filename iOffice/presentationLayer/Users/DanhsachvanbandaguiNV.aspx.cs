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
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class DanhsachvanbandaguiNV : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
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
                        LayngonNgu(13, strNgonngu);
                    }
                    else
                    {
                        Response.Redirect("http://portal.footgear.com.vn");
                    }

                    GanNgonNguVaoGridView();
                    HienThiDanhSach();
                   
                  
                   
                }
               
            
            
            
            
        }
        private void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.DanhSachVanBanDaGuiTheoNguoiGui(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.DanhSachVanBanDaGuiTheoNguoiGuiTW(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.DanhSachVanBanDaGuiTheoNguoiGuiEN(manguoidung, macongty);
                GridView1.DataBind();
            }
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
                GridView1.Columns[2].HeaderText = hasLanguege["abname1"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno1"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle1"].ToString();
                //GridView1.HeaderRow.Cells[4].Text = hasLanguege["YnName"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["NameABC1"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["USERNAME1"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["DepName1"].ToString();
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
            Response.Redirect("tinhtrangtheovanbanNV.aspx");
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string ngonngu = Session["languege"].ToString();
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbtn1 = ((Label)e.Row.FindControl("lblDeTails"));
                    Label lbtn2 = ((Label)e.Row.FindControl("lblNoiDung"));
                   
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
                        lbtn1.Text = "Detail";
                        lbtn2.Text = "Content";
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
                Response.Redirect("chitietphieugui2NV.aspx");
            }
            else
            {
                Response.Redirect("chitietphieugui1NV.aspx");
            }
           // Abcon phieu = AbconDAO.TimMaPhieuTheoNguoiDuyet(maphieu, Until.uNhanVien.USERID, macongty);
        }

       
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

      
    }
}