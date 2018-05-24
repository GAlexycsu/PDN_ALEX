using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmBUser : System.Web.UI.Page
    {
        iOfficeDataContext db = new iOfficeDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("~/presentationLayer/DangNhap.aspx");
            //}
            if (!IsPostBack)
            {
                HienThiDanhSach();
              //  HienThiDropDownList();
            }
        }
        private void HienThiDanhSach()
        {
            string congty = Session["congty"].ToString();
            GridView1.DataSource = UserBUS.ListUser(congty);
            GridView1.DataBind();
        }
        private void HienThiDropDownList()
        {
            string congty = Session["congty"].ToString();
            DropBoPhan.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropBoPhan.DataValueField = "ID";
            DropBoPhan.DataTextField = "DepName";
            DropBoPhan.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList DropCty = GridView1.Rows[e.RowIndex].Cells[1].Controls[0] as DropDownList;
            DropDownList DropBoPhan = GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as DropDownList;
            //TextBox txtMaNV = GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;
            TextBox txtTenNV = GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
            TextBox txtChuKy = GridView1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox;
            string MaNV = (string)GridView1.DataKeys[e.RowIndex].Value;

            Busers2 user = db.Busers2s.Where(p => p.USERID == MaNV).FirstOrDefault();
            user.USERID = MaNV;
            user.USERNAME = txtTenNV.Text;
            user.GSBH = DropCty.Text;
            user.BADEPID = DropBoPhan.Text;
           // user.signatue = txtChuKy.Text;
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            Binary binaryObj;
            if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength > 0)
            {
                string fileName = FileUpload1.FileName;

                byte[] fileByte = FileUpload1.FileBytes;
                binaryObj = new Binary(fileByte);
             


            }
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
           // string chuky = txtChuKy.Text;
            string cty = DropCty.SelectedValue.ToString();
            string bophan = DropBoPhan.SelectedValue.ToString();
            Busers2 user = db.Busers2s.Where(p => p.USERID == manv).FirstOrDefault();
            user.USERID = manv;
            user.USERNAME = tennv;
            user.GSBH = cty;
            user.BADEPID = bophan;
           // user.signatue = binaryObj;
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            HienThiDanhSach();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            HienThiDanhSach();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {

        }

    }
}