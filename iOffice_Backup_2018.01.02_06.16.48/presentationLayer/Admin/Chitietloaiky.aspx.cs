using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class Chitietloaiky : System.Web.UI.Page
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDropDow();
                HienThiDanhSach();
            }
           
        }
        private void HienThiDropDow()
        {
            DropDownLoaiPhieu.DataSource = abillBUS.ListBill();
            DropDownLoaiPhieu.DataValueField = "abtype";
            DropDownLoaiPhieu.DataTextField = "abname";
            DropDownLoaiPhieu.DataBind();
           
        }
        private void HienThiDanhSach()
        {
            GridView1.DataSource = ChiTietLoaiKyBUS.LayDanhSachChiTietLoaiKy();
            GridView1.DataBind();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string maloaiphieu = DropDownLoaiPhieu.SelectedValue.ToString();
            string congty = DropCty.SelectedValue.ToString();
            int buocky = int.Parse(txtBuocky.Text);
            int nhomky = int.Parse(txtNhomKy.Text); ;
            bool kytoanbo = true;
            if (rbKyToanBo.Checked == true)
            {
                kytoanbo = true;
            }
            else
            {
                kytoanbo = false;
            }
            //ChiTietLoaiKy chi= ChiTietLoaiKyBUS.LayBuocKy(int.Parse(txtBuocky.Text),int.Parse(txtBuocky.Text), maloaiphieu);
            //if (chi == null)
            //{
            //    nhomky = int.Parse(txtBuocky.Text);
            //}
            //else
            //{
            //    if (int.Parse(txtBuocky.Text) == chi.abstep)
            //    {
            //        nhomky = int.Parse(chi.abstep.ToString()) + 1;
            //    }
            //    else
            //    {
            //        nhomky = int.Parse(txtBuocky.Text);
            //    }
            //}
            ChiTietLoaiKy chitiet = new ChiTietLoaiKy();
            chitiet.GSBH = congty;
            chitiet.abtype = maloaiphieu;
            chitiet.abstep = buocky;
            chitiet.Nhom = nhomky;
            chitiet.KyToanBo = kytoanbo;
            ChiTietLoaiKyBUS.ThemChiTietLoaiKy(chitiet);

            HienThiDanhSach();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            HienThiDanhSach();
           // GridView row = new GridView();
            //txtBuocky.Text = GridView1.Rows[e.NewEditIndex].Cells[5].Text;
            //txtNhomKy.Text = GridView1.Rows[e.NewEditIndex].Cells[6].Text;

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox buocky = GridView1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox;
            TextBox nhom = GridView1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox;
            TextBox maloai = GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox;
            //TextBox kytoanbo = GridView1.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox;
            int id = int.Parse(GridView1.DataKeys[e.RowIndex]["IDChiTiet"].ToString());
            int buoc = int.Parse(buocky.Text);
            string loai = maloai.Text.ToString();
            int nhomky = int.Parse(nhom.Text);
           // bool ky = bool.Parse(kytoanbo.Text);
            ChiTietLoaiKy chitiet = db.ChiTietLoaiKies.Where(p => p.IDChiTiet == id).FirstOrDefault();
            chitiet.IDChiTiet = id;
            chitiet.abstep = buoc;
            chitiet.abtype = loai;
            chitiet.Nhom = nhomky;
            //chitiet.KyToanBo = ky;
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int mact =int.Parse(row.Cells[3].Text);
            Session["mact"] = mact;
            string maloaiphieu = row.Cells[4].Text;
            Session["maloaiphieu"] = maloaiphieu;
            int nhom = int.Parse(row.Cells[6].Text);
            Session["nhom"] = nhom;
            Response.Redirect("Chitietloaiphieu.aspx");
        }

    }
}