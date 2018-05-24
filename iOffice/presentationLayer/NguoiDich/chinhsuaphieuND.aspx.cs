using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DTO;


namespace iOffice.presentationLayer.NguoiDich
{
    public partial class chinhsuaphieuND : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(2, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                string macongty = Session["congty"].ToString();
                string idphieu = Session["maphieu"].ToString();
                string bophan = Session["bophan"].ToString();
                string manguoidung = Session["user"].ToString();
                // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, macongty, true);
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
                var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
                foreach (pdna phieu in list)
                {
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;

                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan;
                    lbSoPhieu.Text = idphieu;
                    CKEditorControl1.Text = phieu.pdmemovn;
                }
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            db.ExecuteCommand("update pdna set GSBH='" + macongty + "',pdmemovn=N'" + CKEditorControl1.Text.ToString() + "' where pdno='" + idphieu + "'");
            Response.Redirect("frmPreviewND.aspx");
        }
    }
}