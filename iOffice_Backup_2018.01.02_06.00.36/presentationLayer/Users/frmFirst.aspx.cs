using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Users
{
    public partial class frmFirst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiBoPhan();
                HienThiLoaiPhieu();
            }
        }
        private void HienThiBoPhan()
        {
            string congty = Session["congty"].ToString();
            DropDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropDonVi.DataValueField = "ID";
            DropDonVi.DataTextField = "DepName";
            DropDonVi.DataBind();
        }
        private void HienThiLoaiPhieu()
        {
            string ngonngu = Session["languege"].ToString();
            DropLoaiPhieu.DataSource = abillBUS.ListBill();
            DropLoaiPhieu.DataValueField = "abtype";
            if (ngonngu == "lbl_VN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropLoaiPhieu.DataTextField = "abnameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropLoaiPhieu.DataTextField = "abname";
            }

            DropLoaiPhieu.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string maloaiphieu = DropLoaiPhieu.SelectedValue.ToString();
            if (maloaiphieu == "PDN2")
            {
                
            }
        }
    }
}