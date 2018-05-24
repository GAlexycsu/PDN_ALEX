using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class DanhsachtinhtrangvanbandaguiNV : LanguegeBus
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
                    LayngonNgu(14, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }

                if (!IsPostBack)
                {
                    GanNgonNguVaoGridView();
                    HienThiDanhSach();
                }




            }


        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        private void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridViewDSTrangThaiPhieu.DataSource = dal.LayTinhTrangVanBanTheoNguoiGui(manguoidung, macongty);
                GridViewDSTrangThaiPhieu.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridViewDSTrangThaiPhieu.DataSource = dal.LayTinhTrangVanBanTheoNguoiGuiTW(manguoidung, macongty);
                GridViewDSTrangThaiPhieu.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridViewDSTrangThaiPhieu.DataSource = dal.LayTinhTrangVanBanTheoNguoiGuiEN(manguoidung, macongty);
                GridViewDSTrangThaiPhieu.DataBind();
            }
        }
        public override void GanNgonNguVaoGridView()
        {

            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridViewDSTrangThaiPhieu.Columns[0].HeaderText = hasLanguege["abname"].ToString();
                GridViewDSTrangThaiPhieu.Columns[1].HeaderText = hasLanguege["pdno"].ToString();
                GridViewDSTrangThaiPhieu.Columns[2].HeaderText = hasLanguege["mytitle"].ToString();
                GridViewDSTrangThaiPhieu.Columns[3].HeaderText = hasLanguege["YnName"].ToString();
                GridViewDSTrangThaiPhieu.Columns[4].HeaderText = hasLanguege["NameABC"].ToString();
                GridViewDSTrangThaiPhieu.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridViewDSTrangThaiPhieu.Columns[6].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridViewDSTrangThaiPhieu.Columns[0].HeaderText = hasLanguege["abname"].ToString();
                GridViewDSTrangThaiPhieu.Columns[1].HeaderText = hasLanguege["pdno"].ToString();
                GridViewDSTrangThaiPhieu.Columns[2].HeaderText = hasLanguege["mytitle"].ToString();
                GridViewDSTrangThaiPhieu.Columns[3].HeaderText = hasLanguege["YnName"].ToString();
                GridViewDSTrangThaiPhieu.Columns[4].HeaderText = hasLanguege["NameABC"].ToString();
                GridViewDSTrangThaiPhieu.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridViewDSTrangThaiPhieu.Columns[6].HeaderText = hasLanguege["DepName"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridViewDSTrangThaiPhieu.Columns[0].HeaderText = hasLanguege["abname"].ToString();
                GridViewDSTrangThaiPhieu.Columns[1].HeaderText = hasLanguege["pdno"].ToString();
                GridViewDSTrangThaiPhieu.Columns[2].HeaderText = hasLanguege["mytitle"].ToString();
                GridViewDSTrangThaiPhieu.Columns[3].HeaderText = hasLanguege["YnName"].ToString();
                GridViewDSTrangThaiPhieu.Columns[4].HeaderText = hasLanguege["NameABC"].ToString();
                GridViewDSTrangThaiPhieu.Columns[5].HeaderText = hasLanguege["USERNAME"].ToString();
                GridViewDSTrangThaiPhieu.Columns[6].HeaderText = hasLanguege["DepName"].ToString();
            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            
        }


    }
}