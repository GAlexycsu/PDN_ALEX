using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmEditBoPhan : LanguegeBus
    {
        departDAL dal = new departDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(37, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
           
            if (!IsPostBack)
            {
                string macongty = Session["macongty"].ToString();
                string mabophan = Session["mabophan"].ToString();
                //string tenbophan = Session["tenbophan"].ToString();
                string maloaiDV = Session["maloaiDV"].ToString();
                string machuquan = Session["machuquan"].ToString();
                HienThiDropDownList();
                HienThiDropLoaiDonVi();
               
                txtChuQuan.Text = machuquan;
                DropCty.SelectedValue = macongty;
                DropDownBoPhan.SelectedValue = mabophan;
                DropDownLoaiDonVi.SelectedValue = maloaiDV;
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
        }
        private void HienThiDropDownList()
        {
            string macongty = Session["congty"].ToString();
            DropDownBoPhan.DataSource = dal.QryDonViLenDropBo(macongty);
            DropDownBoPhan.DataValueField = "ID";
            DropDownBoPhan.DataTextField = "DepName";
            DropDownBoPhan.DataBind();
        }
        public void HienThiDropLoaiDonVi()
        {
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            //  string macongty = "LTY";
            DropDownLoaiDonVi.DataSource = LoaiDonViDAO.QryLoaiDonVi(macongty);
            DropDownLoaiDonVi.DataValueField = "DepartmentTypeID";
            DropDownLoaiDonVi.DataTextField = "DepartmentTypeName";
            if (ngonngu == "lbl_VN")
            {
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeName";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeNameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeName";
            }
            DropDownLoaiDonVi.DataBind();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string congty = DropCty.SelectedValue.ToString();
            string bophan = DropDownBoPhan.SelectedValue.ToString();
            string tenbophan = DropDownBoPhan.SelectedItem.ToString();
            string manhanvien = txtChuQuan.Text;
            int idloai = int.Parse(DropDownLoaiDonVi.SelectedValue.ToString());
            BDepartment bs = new BDepartment();
            bs.GSBH = congty;
            bs.ID = bophan;
            bs.DepName = tenbophan;
            bs.IdUserChuQuan = manhanvien;
            bs.DepartmentTypeID = 
            //BDepartmentDAO.SuaBoPhan(bs);
            dal.CapNhatDepart(bophan, congty, manhanvien, idloai);
            Response.Redirect("frmBoPhan.aspx");
        }
    }
}