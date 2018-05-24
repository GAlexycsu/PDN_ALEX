using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DTO;
namespace iOffice.presentationLayer.Users
{
    public partial class chinhsuaphieuNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
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
                string macongty = Session["congty"].ToString();
                string idphieu = Session["maphieu"].ToString();
                string bophan = Session["bophan"].ToString();
                string manguoidung = Session["user"].ToString();
               // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, macongty, true);
                 db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
                var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty+ "' and CFMID0='" + manguoidung + "'");
                foreach (pdna phieu in list)
                {
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    txtTieuDe.Text = phieu.mytitle;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan;
                    lbSoPhieu.Text = idphieu;
                    CKEditorControl1.Text = phieu.pdmemovn;
                }
            }
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnLuu.Text=hasLanguege["btnLuu"].ToString();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            string noidung=CKEditorControl1.Text.ToString() ;
            db.ExecuteCommand("update pdna set pdmemovn=N'" + CKEditorControl1.Text.ToString() + "',mytitle=N'" + txtTieuDe.Text.Trim() + "',CFMDate0=GETDATE()  where pdno='" + idphieu + "'and  GSBH='" + macongty + "'");
           // db.SuaPhieuDeNghiTT(macongty, idphieu, noidung);
            Response.Redirect("FrmView.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmView.aspx");
        }
    }
}