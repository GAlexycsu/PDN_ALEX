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
    public partial class FSualoaiphieu : LanguegeBus
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
            }
            if (!IsPostBack)
            {
               
               
                string idloai = Session["idloai"].ToString();
                string tentiengviet = Session["tentiengviet"].ToString();
                string tentienghoa = Session["tentienghoa"].ToString();
                txtMaLoai.Text = idloai;
                txtTenLoaiVN.Text = tentiengviet;
                txtTenLoaiTW.Text = tentienghoa;
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
                abillDAO.UpdateAbill(loaiphieu);
                Response.Redirect("FDanhSachLoaiPhieu.aspx");
            }
        }
    }
}