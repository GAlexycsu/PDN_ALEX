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
    public partial class wf_Danhsachphieudaduocky : LanguegeBus
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
                    LayngonNgu(26, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }

               
                GanNgonNguVaoGridView();
                HienThiDanhSach();

            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                GridView1.DataSource = dal.QryPhieuDaDuyetTheoNguoiTao(manguoidung, macongty);
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
                GridView1.Columns[2].HeaderText = hasLanguege["abtype26"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname26"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno26"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["YnName26"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[9].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[10].HeaderText = hasLanguege["DepName26"].ToString();
            }
            else if (ngonngu == "lbl_TW")
            {
                GridView1.Columns[2].HeaderText = hasLanguege["abtype26"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname26"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno26"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["YnName26"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[9].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[10].HeaderText = hasLanguege["DepName26"].ToString();
            }
            else if (ngonngu == "lbl_EN")
            {
                GridView1.Columns[2].HeaderText = hasLanguege["abtype26"].ToString();
                GridView1.Columns[3].HeaderText = hasLanguege["abname26"].ToString();
                GridView1.Columns[4].HeaderText = hasLanguege["pdno26"].ToString();
                GridView1.Columns[5].HeaderText = hasLanguege["mytitle26"].ToString();
                GridView1.Columns[6].HeaderText = hasLanguege["YnName26"].ToString();
                GridView1.Columns[7].HeaderText = hasLanguege["NameABC26"].ToString();
                GridView1.Columns[8].HeaderText = hasLanguege["USERNAME26"].ToString();

                GridView1.Columns[9].HeaderText = hasLanguege["ID26"].ToString();
                GridView1.Columns[10].HeaderText = hasLanguege["DepName26"].ToString();
            }


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            GridViewRow row = GridView1.SelectedRow;
            string maphieu = row.Cells[4].Text;
            Session["maphieu"] = maphieu;
            string loaiphieu = row.Cells[2].Text;
            string tenloaiphieu = row.Cells[3].Text;
            Session["tenloaiphieu"] = tenloaiphieu;
            Session["loaiphieu"] = loaiphieu;
            string tieude = row.Cells[5].Text;
            Session["tieude"] = tieude;
            string bophan = row.Cells[10].Text;
            Session["bophan"] = bophan;
            //  Response.Redirect("frmDetails2.aspx");
            pdna chitietduyet = pnaDAO.LayPhieuTheoNguoiGui(maphieu, manguoidung, macongty);
            if (chitietduyet.Abtype == "PDN2")
            {
                Response.Redirect("phieumuahang.aspx");
            }
            else
            {
                Response.Redirect("frmDetails2.aspx");
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
                     LinkButton lbtn2 = ((LinkButton)e.Row.Cells[1].Controls[0]);
                     if (ngonngu == "lbl_VN")
                     {
                         lbtn1.Text = "Chi Tiết";
                         lbtn2.Text = "Xem Quy Trình";

                     }
                     else if (ngonngu == "lbl_TW")
                     {
                         lbtn1.Text = "详情";
                         lbtn2.Text = "检查流程";
                     }
                     else if (ngonngu == "lbl_EN")
                     {
                         lbtn1.Text = "Chi Tiết";
                         lbtn2.Text = "Xem Quy Trình";
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
            Label lbl1 = (Label)GridView1.Rows[e.RowIndex].FindControl("lblpdno");
            Session["maphieu"] = lbl1.Text;
            Response.Redirect("tinhtrangtheovanban.aspx");
        }

        

    }
}