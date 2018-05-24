using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer
{
    public partial class CreateUser : System.Web.UI.Page
    {
        BLL_TheLogib bll = new BLL_TheLogib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowSystem();
                HienThiDanhSach();
            }
        }
        public void HienThiDSTimKiem()
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                HienThiDanhSach();
            }
            else
            {
                string UserID = txtTimKiem.Text.Trim();
                DataTable dt = bll.HienThiDanhSachTimKiem(UserID);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
        public void HienThiDanhSach()
        {
            DataTable dt = bll.LayNguoiDungDangNhapVaoHeThong();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public void ShowSystem()
        {
            DataTable dt = bll.LoadSystem();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string ID = dr["ID"].ToString();
                    string name = dr["Name"].ToString();
                    ListBox1.Items.Add(new ListItem(name, ID));
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string UserID = txtUserID.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string acticode = bll.CalculateMD5Hash(UserID + "TheLogin" + pass);
            DataTable ktUser = bll.CheckUser(UserID);
            if (ktUser.Rows.Count > 0)
            {
                bll.UpdatePassword(UserID, acticode);
                foreach (ListItem item in ListBox1.Items)
                {
                    if (item.Selected)
                    {
                        string hethong = item.Value;
                        DataTable ktSystem = bll.KiemTrauUserVoiDangNhap(UserID, hethong);
                        if (ktSystem.Rows.Count == 0)
                        {
                            bll.ThemNguoiDungDangNhapHeThong(UserID, hethong);
                        }
                    }
                }
                HienThiDanhSach();
                lblThongBao.Text = "Succeed";
            }
            else
            {
                bll.ThemUser(UserID, acticode, Email);
                foreach (ListItem item in ListBox1.Items)
                {
                    if (item.Selected)
                    {
                        string hethong = item.Value;
                        DataTable ktSystem = bll.KiemTrauUserVoiDangNhap(UserID, hethong);
                        if (ktSystem.Rows.Count == 0)
                        {
                            bll.ThemNguoiDungDangNhapHeThong(UserID, hethong);
                        }
                    }
                }
                HienThiDanhSach();
                lblThongBao.Text = "Succeed";
            }

        }
        public void Show()
        {
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    string hethong = item.Value;
                }
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblUserID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblUserID");
            Label lblSystemID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSystemID");
            string UserID = lblUserID.Text.Trim();
            string SystemID = lblSystemID.Text.Trim();
            bll.XoaNguoiDungVaoHeThong(UserID, SystemID);
            HienThiDanhSach();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            HienThiDSTimKiem();
        }

        protected void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDSTimKiem();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageMain2.aspx");
        }
    }
}