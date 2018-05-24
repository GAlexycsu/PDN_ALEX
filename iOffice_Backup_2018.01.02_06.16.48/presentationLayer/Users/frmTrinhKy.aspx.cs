using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Users
{
    public partial class frmTrinhKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                HienthiDanhSach();
            }

        }
        private void HienthiDanhSach()
        {
            //string bophan = Session["bp"].ToString();
            //string congty = Session["congty"].ToString();
            string congty = "LTY";
         
            //GridDSNguoiDuyet.DataSource = UserBUS.QryNguoiDuyetTheoCapDuyet(congty,bophan);
            GridDSNguoiDuyet.DataSource = UserBUS.QryNguoiDuyetTheoCapDuyets(congty);
            GridDSNguoiDuyet.DataBind();
            
        }
    }
}