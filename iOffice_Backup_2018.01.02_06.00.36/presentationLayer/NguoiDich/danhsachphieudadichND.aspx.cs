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
    public partial class danhsachphieudadichND : LanguegeBus
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
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(23, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
              if(!IsPostBack)
              {
                    GanNgonNguVaoGridView();
                    HienThiDanhSachDaDich();
               
               
            }
           
        }
        public override void GanNgonNguVaoGridView()
        {
            GridView1.Columns[1].HeaderText = hasLanguege["pdno23"].ToString();
            GridView1.Columns[2].HeaderText = hasLanguege["mytitle23"].ToString();
           GridView1.Columns[3].HeaderText = hasLanguege["USERNAME23"].ToString();
           GridView1.Columns[4].HeaderText = hasLanguege["CFMDate23"].ToString();
            
        }
        private void HienThiDanhSachDaDich()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            GridView1.DataSource = db.QryPhieuDaDichTheoNguoiDich(macongty, manguoidung);
            GridView1.DataBind();
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
                Response.Redirect("frmSuaphieumuahangND.aspx");
            }
            else
            {
                Response.Redirect("chitietphieudadichND.aspx");
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
            HienThiDanhSachDaDich();
        }
    }
}