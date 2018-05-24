using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.Share;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class ViDu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            string maphieu = "2014062600014";
            string macongty = "LTY";
            List<Abcon> lstChiTietXetDuyet1 = AbconBUS.QryChiTietXetDuyetTheoMaVanBanNguoiTrinhDuyet(maphieu, macongty);
            int max = (from ct1 in lstChiTietXetDuyet1
                       select ct1.Abstep).Max();
            if (max<= 6)
            {
                lbChuNhiemTW.Visible = false;
                lbChuNhiemVN.Visible = false;
                lbChuQuanTKTW.Visible = false;
                lbChuQuanTKVN.Visible = false;
                ImageLevel3.Visible = false;
                ImageLevel4.Visible = false;

            }
            else
            {
                lbChuNhiemTW.Visible = true;
                lbChuNhiemVN.Visible = true;
                lbChuQuanTKTW.Visible = true;
                lbChuQuanTKVN.Visible = true;
                ImageLevel3.Visible = true;
                ImageLevel4.Visible = true;
            }
        }
    }
}