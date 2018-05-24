using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class FDanhSachLoaiPhieu : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(38, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
                
                HienThiDanhSach();
            }
            
        }
        public void HienThiDanhSach()
        {
            GridView1.DataSource = abillDAO.ListBill();
            GridView1.DataBind();
                 
        }
        public override void GanNgonNguVaoGridView()
        {
             GridView1.Columns[2].HeaderText=hasLanguege["idloai"].ToString();
             GridView1.Columns[3].HeaderText=hasLanguege["tentiengviet"].ToString();
             GridView1.Columns[4].HeaderText=hasLanguege["tentienghoa"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string maloaiphieu = txtMaLoai.Text.Trim();
            string tentiengviet = txtTenLoaiVN.Text;
            string tentienghoa = txtTenLoaiTW.Text;
            abill loaiphieu = new abill();
            if (txtMaLoai.Text.Trim() == "")
            {

            }
            else
            {
                loaiphieu.abtype = maloaiphieu;
                loaiphieu.abname = tentiengviet;
                loaiphieu.abnameTW = tentienghoa;
                abillDAO.InsertAbill(loaiphieu);
                abill timmaloai = abillDAO.SearchAbillByID(maloaiphieu);
                if (timmaloai != null)
                {
                    HienThiDanhSach();
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            string idloai = row.Cells[2].Text;
            string tentiengviet = row.Cells[3].Text;
            string tentienghoa = row.Cells[4].Text;
            Session["idloai"] = idloai;
            Session["tentiengviet"] = tentiengviet;
            Session["tentienghoa"] = tentienghoa;
            Response.Redirect("FSualoaiphieu.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idloaiphieu = (string)(GridView1.Rows[e.RowIndex].Cells[2].Text);
            abillDAO.DeleteAbill(idloaiphieu);
            HienThiDanhSach();
        }
    }
}