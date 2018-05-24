using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmCanBoDonVi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiDanhSach();
                HienThiDropDownList();
            }
        }
        private void HienThiDropDownList()
        {
            string congty = DropCty.SelectedValue.ToString();
            DropDownBoPhan.DataSource = BDepartmentBUS.DanhSachBoPhan(congty);
            DropDownBoPhan.DataValueField = "ID";
            DropDownBoPhan.DataTextField = "DepName";
            DropDownBoPhan.DataBind();
        }
        private void HienThiDanhSach()
        {
            
            GridView1.DataSource = CanBoDonViBUS.LayDanhSachCanBoDonVi();
            GridView1.DataBind();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string macongty = DropCty.SelectedValue.ToString();
            string mabophan = DropDownBoPhan.SelectedValue.ToString();
            string manv = txtChuQuan.Text;

            CanBoDonVi canbo = new CanBoDonVi();
            canbo.GSBH = macongty;
            canbo.BADepID = mabophan;
            canbo.UserIDQLDonVi = manv;
            CanBoDonViBUS.ThemCanBoDonVi(canbo);

        }
    }
}