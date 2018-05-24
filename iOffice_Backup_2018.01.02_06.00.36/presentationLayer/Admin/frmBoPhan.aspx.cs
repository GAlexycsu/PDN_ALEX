using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.SiteMater;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmBoPhan : LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        int STT=1;
        departDAL dal = new departDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
            }
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
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
                HienThiDropDownList();
                HienThiDropLoaiDonVi();
                HienThiDanhSach();
            }
           

        }
        public override void GanNgonNguVaoConTrol()
        {
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
        }
        public override void GanNgonNguVaoGridView()
        {
           
            GridView1.Columns[1].HeaderText = hasLanguege["GSBH"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["lbDonVi"].ToString();
            GridView1.Columns[5].HeaderText = hasLanguege["lblLoaiDonVi"].ToString();
            GridView1.Columns[7].HeaderText = hasLanguege["lblChuQuan"].ToString();
           
        }
        private void HienThiDropDownList()
        {
            string congty = DropCty.SelectedValue.ToString();
            DropDownBoPhan.DataSource = dal.QryDonViLenDropBo(congty);
            DropDownBoPhan.DataValueField = "ID";
            DropDownBoPhan.DataTextField = "DepName";
            DropDownBoPhan.DataBind();
        }
        private void HienThiDanhSach()
        {
            string congty = DropCty.SelectedValue.ToString();
            DataTable dt = dal.QryDonVi(congty);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            if (lblThongBao.Text.Trim() != "")
            {
                lblThongBao.Text = "";
            }
            string congty = DropCty.SelectedValue.ToString();
            string bophan = DropDownBoPhan.SelectedValue.ToString();
            string tenbophan = DropDownBoPhan.SelectedItem.ToString();
            string manhanvien = txtChuQuan.Text.Trim();
            if (manhanvien == "")
            {
                lblThongBao.Text = "Input Incorrect";
            }
            else
            {
                BDepartment bs = new BDepartment();
                bs.GSBH = congty;
                bs.ID = bophan;
                bs.DepName = tenbophan;
                bs.IdUserChuQuan = manhanvien;
                bs.DepartmentTypeID = int.Parse(DropDownLoaiDonVi.SelectedValue.ToString());
                BDepartmentBUS.SuaBoPhan(bs);
            }
           
        }
        public void HienThiDropLoaiDonVi()
        {
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            //  string macongty = "LTY";
           
         
            if (ngonngu == "lbl_VN")
            {
                DropDownLoaiDonVi.DataSource = LoaiDonViDAO.QryLoaiDonVi(macongty);
                DropDownLoaiDonVi.DataValueField = "DepartmentTypeID";
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeName";
                DropDownLoaiDonVi.DataBind();
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownLoaiDonVi.DataSource = LoaiDonViDAO.QryLoaiDonVi(macongty);
                DropDownLoaiDonVi.DataValueField = "DepartmentTypeID";
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeNameTW";
                DropDownLoaiDonVi.DataBind();
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownLoaiDonVi.DataSource = LoaiDonViDAO.QryLoaiDonVi(macongty);
                DropDownLoaiDonVi.DataValueField = "DepartmentTypeID";
                DropDownLoaiDonVi.DataTextField = "DepartmentTypeName";
                DropDownLoaiDonVi.DataBind();
            }
           
        }
        protected void DropCty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string congty = DropCty.SelectedValue.ToString();
            GridView1.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            GridView1.DataBind();
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string macongty = DropCty.SelectedValue.ToString();
            DataTable dt = dal.QryDonVi(macongty);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label labMaCty = (Label)row.FindControl("lblGSBH");
            string macongty = labMaCty.Text.Trim();
            Label lblMaDV = (Label)row.FindControl("lblID");
            string mabophan = lblMaDV.Text.Trim();
            Label lblTenDV = (Label)row.FindControl("lblDepName");
            string tenbophan = lblTenDV.Text.Trim();
            Label lblMaLoaiDV = (Label)row.FindControl("lblDepartmentTypeID");

            string maloaiDV = lblMaLoaiDV.Text.Trim();
            Label lblChuQuan = (Label)row.FindControl("lblIdUserChuQuan");
            string machuquan = lblChuQuan.Text.Trim();
            Session["macongty"] = macongty;
            Session["mabophan"] = mabophan;
            Session["tenbophan"] = tenbophan;
            Session["maloaiDV"] = maloaiDV;
            Session["machuquan"] = machuquan;
            Response.Redirect("frmEditBoPhan.aspx");
        }

        protected void DropCty_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string congty = DropCty.SelectedValue.ToString();
            GridView1.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            GridView1.DataBind();
        }

        protected void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            if (txtTimkiem.Text.Trim() == "")
            {
                HienThiDanhSach();
            }
            else
            {
                DataTable dt = dal.TimKiemDonViTheoDieuKien(macongty, txtTimkiem.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            if (txtTimkiem.Text.Trim() == "")
            {
                DataTable dt = dal.TimKiemDonViTheoDieuKien(macongty, txtTimkiem.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
            HienThiDanhSach();
        }
    }
}