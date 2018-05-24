using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class danhsachvanbankhongduyet : LanguegeBus
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
                        LayngonNgu(10,strNgonngu);
                    }
                    else
                    {
                        Response.Redirect("http://portal.footgear.com.vn");
                    }


                    
                   
                    GanNgonNguVaoGridView();
                    HienThiDanhSach();
                    
                }
                
           
        }
        public override void GanNgonNguVaoGridView()
        {
           
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype10"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname10"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno10"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle10"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName10"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC10"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME10"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID10"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName10"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype10"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname10"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno10"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle10"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName10"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC10"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME10"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID10"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName10"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["abtype10"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["abname10"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["pdno10"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["mytitle10"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["YnName10"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["NameABC10"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["USERNAME10"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["ID10"].ToString();
                GridView1.Columns[9].HeaderText = hasLanguege["DepName10"].ToString();
            }
        }
        private void HienThiDanhSach()
        {
            string manguoidung = Session["user"].ToString();
           string macongty="LTY";
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyet(manguoidung,macongty);
                GridView1.DataBind();

            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyetTW(manguoidung,macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.DanhSachVanBanDenKhongDuocDuyetTheoNguoiDuyet(manguoidung,macongty);
                GridView1.DataBind();
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
            string bophan = row.Cells[9].Text;
            Session["bophan"] = bophan;
            Label lblMaLoaiPhieu = (Label)row.FindControl("lblabtype");
            string maloaiphieu = lblMaLoaiPhieu.Text;
            Session["maloaiphieu"] = maloaiphieu;
            Label lblDepart = (Label)row.FindControl("lblDepart");
            string mabophan = lblDepart.Text;
            Session["mabophan"] = mabophan;
            // Response.Redirect("~/presentationLayer/ApproveUser/frmDetails.aspx");

            if (maloaiphieu == "PDN2")
            {
                Response.Redirect("phieumuahangD.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2D.aspx");
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
                        lbtn1.Text = "Detail";

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

       
    }
}