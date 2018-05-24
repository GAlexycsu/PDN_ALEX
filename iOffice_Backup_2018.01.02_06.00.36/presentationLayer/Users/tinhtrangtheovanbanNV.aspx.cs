using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.Share;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class tinhtrangtheovanbanNV : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal=new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = (string)Session["user"];
            if (user == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }

            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(17, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                string ngonngu = Session["languege"].ToString();
                if (ngonngu == "lbl_VN")
                {
                    btnTroVe.Text = "Trở Về Trang Trước";
                    GridViewDSTrangThaiPhieu.Visible = true;
                    GridView1.Visible = false;
                }
                else if (ngonngu == "lbl_TW")
                {
                    btnTroVe.Text = "返回";
                    GridViewDSTrangThaiPhieu.Visible = false;
                    GridView1.Visible = true;
                }
                else if (ngonngu == "lbl_EN")
                {
                    btnTroVe.Text = "Back";
                    GridViewDSTrangThaiPhieu.Visible = true;
                    GridView1.Visible = false;
                }
                HienThiDanhSach();

            }
            //LayngonNgu(17);
            //GanNgonNguVaoGridView();
           
        }
        private void HienThiDanhSach()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridViewDSTrangThaiPhieu.DataSource = db.QryTinhTrangVanBanTheoMaVanBan(maphieu, macongty);
                GridViewDSTrangThaiPhieu.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = db.QryTinhTrangVanBanTheoMaVanBanTW(maphieu, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridViewDSTrangThaiPhieu.DataSource = db.QryTinhTrangVanBanTheoMaVanBan(maphieu, macongty);
                GridViewDSTrangThaiPhieu.DataBind();
            }
        }
        public override void GanNgonNguVaoGridView()
        {
            string abc = hasLanguege["mytitle"].ToString();
           
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[0].Text = hasLanguege["abname"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[1].Text = hasLanguege["pdno"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[2].Text = hasLanguege["mytitle"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[3].Text = hasLanguege["YnName"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[4].Text = hasLanguege["NameABC"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[5].Text = hasLanguege["USERNAME"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[6].Text = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.HeaderRow.Cells[0].Text = hasLanguege["abname"].ToString();
                GridView1.HeaderRow.Cells[1].Text = hasLanguege["pdno"].ToString();
                GridView1.HeaderRow.Cells[2].Text = hasLanguege["mytitle"].ToString();
                GridView1.HeaderRow.Cells[3].Text = hasLanguege["YnName"].ToString();
                GridView1.HeaderRow.Cells[4].Text = hasLanguege["NameABC"].ToString();
                GridView1.HeaderRow.Cells[5].Text = hasLanguege["USERNAME"].ToString();
                GridView1.HeaderRow.Cells[6].Text = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[0].Text = hasLanguege["abname"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[1].Text = hasLanguege["pdno"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[2].Text = hasLanguege["mytitle"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[3].Text = hasLanguege["YnName"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[4].Text = hasLanguege["NameABC"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[5].Text = hasLanguege["USERNAME"].ToString();
                GridViewDSTrangThaiPhieu.HeaderRow.Cells[6].Text = hasLanguege["DepName"].ToString();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewDSTrangThaiPhieu.SelectedRow;
            string maphieu = row.Cells[0].Text;
            string maphieu1 = row.Cells[1].Text;
            string maphieu2= row.Cells[2].Text;
            string maphieu3 = row.Cells[3].Text;
            string maphieu4 = row.Cells[4].Text;
            string maphieu5 = row.Cells[5].Text;
            string maphieu6 = row.Cells[6].Text;
        }

        protected void btnTroVe_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhsachvanbandaguiNV.aspx");
        }
    }
}