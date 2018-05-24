using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
namespace iOffice.presentationLayer.Users
{

    public partial class DanhSachPhieuChuaDuyetBiTraVe :LanguegeBus
    {
        dalPDN dal = new dalPDN();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(30, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
                Qry();
            }
        }

        public void Qry()
        {
            string UserID=Session["user"].ToString();
            string congty=Session["congty"].ToString();
            DataTable dt = dal.QryPhieuChuaDuyetCoYKien(UserID, congty);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["pdno30"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle30"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME30"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate30"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["pdno30"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle30"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME30"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate30"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[1].HeaderText = hasLanguege["pdno30"].ToString();
                GridView1.Columns[2].HeaderText = hasLanguege["mytitle30"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["USERNAME30"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["CFMDate30"].ToString();
            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string MaPhieu = row.Cells[1].Text;
            Label lblMaLoai =(Label)row.FindControl("lblMaLoaiPhieu");
            string MaLoaiPhieu = lblMaLoai.Text.Trim();
            Session["MaPhieu"] = MaPhieu;
            if (MaLoaiPhieu == "PDN2")
            {
                Response.Redirect("ChiTietPhieuBiHuy2.aspx");
            }
            else
            {
                Response.Redirect("ChiTietPhieuHuy1.aspx");
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

        protected void TimerTraVe_Tick(object sender, EventArgs e)
        {
            
           
        }
    }
}