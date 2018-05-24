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
namespace iOffice.presentationLayer.Users
{
    public partial class danhsachphieudaduyetNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
        dalPDN dal = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {

            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(26, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                GanNgonNguVaoGridView();
                HienThiDanhSach();
            }  
           
            
           
        }
        public void HienThiDanhSach()
        {
            string macongty=Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.QryPhieuDaDuyetTheoNguoiTao(manguoidung,macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.DataSource = dal.QryPhieuDaDuyetTheoNguoiTaoTW(manguoidung, macongty);
                GridView1.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.DataSource = dal.QryPhieuDaDuyetTheoNguoiTao(manguoidung, macongty);
                GridView1.DataBind();
            }
           
        }
        public override void GanNgonNguVaoGridView()
        {
           
             string ngonngu = Session["languege"].ToString();
             if (ngonngu == "lbl_VN")
             {
                 GridView1.Columns[1].HeaderText = hasLanguege["abtype26"].ToString();
                 GridView1.Columns[2].HeaderText = hasLanguege["abname26"].ToString();
                 GridView1.Columns[3].HeaderText = hasLanguege["pdno26"].ToString();
                 GridView1.Columns[4].HeaderText = hasLanguege["mytitle26"].ToString();
                 GridView1.Columns[5].HeaderText = hasLanguege["YnName26"].ToString();
                 GridView1.Columns[6].HeaderText = hasLanguege["NameABC26"].ToString();
                 GridView1.Columns[7].HeaderText = hasLanguege["USERNAME26"].ToString();

                 GridView1.Columns[8].HeaderText = hasLanguege["ID26"].ToString();
                 GridView1.Columns[9].HeaderText = hasLanguege["DepName26"].ToString();
             }
             else if (ngonngu == "lbl_TW")
             {
                 GridView1.Columns[1].HeaderText = hasLanguege["abtype26"].ToString();
                 GridView1.Columns[2].HeaderText = hasLanguege["abname26"].ToString();
                 GridView1.Columns[3].HeaderText = hasLanguege["pdno26"].ToString();
                 GridView1.Columns[4].HeaderText = hasLanguege["mytitle26"].ToString();
                 GridView1.Columns[5].HeaderText = hasLanguege["YnName26"].ToString();
                 GridView1.Columns[6].HeaderText = hasLanguege["NameABC26"].ToString();
                 GridView1.Columns[7].HeaderText = hasLanguege["USERNAME26"].ToString();

                 GridView1.Columns[8].HeaderText = hasLanguege["ID26"].ToString();
                 GridView1.Columns[9].HeaderText = hasLanguege["DepName26"].ToString();
             }
             else if (ngonngu == "lbl_EN")
             {
                 GridView1.Columns[1].HeaderText = hasLanguege["abtype26"].ToString();
                 GridView1.Columns[2].HeaderText = hasLanguege["abname26"].ToString();
                 GridView1.Columns[3].HeaderText = hasLanguege["pdno26"].ToString();
                 GridView1.Columns[4].HeaderText = hasLanguege["mytitle26"].ToString();
                 GridView1.Columns[5].HeaderText = hasLanguege["YnName26"].ToString();
                 GridView1.Columns[6].HeaderText = hasLanguege["NameABC26"].ToString();
                 GridView1.Columns[7].HeaderText = hasLanguege["USERNAME26"].ToString();

                 GridView1.Columns[8].HeaderText = hasLanguege["ID26"].ToString();
                 GridView1.Columns[9].HeaderText = hasLanguege["DepName26"].ToString();
             }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[3].Text;
            Session["maphieu"] = maphieu;
            Label lblMaLoaiPhieu = (Label)row.FindControl("lblMaLoaiPhieu");
            string loaiphieu = lblMaLoaiPhieu.Text.Trim();
            string tenloaiphieu = row.Cells[2].Text;
            Session["tenloaiphieu"] = tenloaiphieu;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[4].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[9].Text;
            Session["bophan"] = bophan;
          //  Response.Redirect("frmDetails2.aspx");
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, manguoidung,macongty);
            if (chitietduyet.Abtype == "PDN2")
            {
                Response.Redirect("phieumuahangNV.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2NV.aspx");
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
           
               

           
        }
       

       

    }
}