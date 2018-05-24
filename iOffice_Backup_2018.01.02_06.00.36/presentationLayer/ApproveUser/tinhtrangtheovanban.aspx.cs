using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.Share;
using iOffice.BUS;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class tinhtrangtheovanban :LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //LayngonNgu(17);
            //GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                string user = (string)Session["user"];
                if (user == null)
                {
                    Response.Redirect("~/presentationLayer/DangNhap.aspx");
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
                
                HienThiDanhSach();
                GanNgonNguVaoGridView();
            }
           
        }
        public void HienThiDanhSach()
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
        public void GanNgonNguVaoControl()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                btnBack.Text = "Trở Lại";
            }
            else if (ngonngu == "lbl_TW")
            {
                btnBack.Text = "返回";
            }
            else if (ngonngu == "lbl_EN")
            {
                btnBack.Text = "Back";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachVanBanDen.aspx");
        }

    }
}