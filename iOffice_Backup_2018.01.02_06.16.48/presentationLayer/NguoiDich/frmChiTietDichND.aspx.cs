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
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class frmChiTietDichND : System.Web.UI.Page
    {
        static iOfficeDataContext db = new iOfficeDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            if (!IsPostBack)
            {
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
               // pdna phieu = pnaDAO.LayVanBanDaDichTheoNguoiDich(maphieu, macongty, manguoidung);
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                // string ngaythang = DateTime.Parse(phieu.CFMDate0.ToString("dd/MM/yyyy"));
                BDepartment bophan = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;

                lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                lbBoPhan.Text = bophan.DepName;
                lblTieuDe.Text = phieu.mytitle +"-"+ phieu.pdnsubject;
                //lbNgay.Text = ;
                lbNoiDung.Text = phieu.pdmemovn;
                LbNoiDungDich.Text = phieu.NoiDungDich;
                lbSoPhieu.Text = phieu.pdno;
                string dinhdang = phieu.CFMDate0.ToString();
                string thang = dinhdang.Substring(3, 2);
                string ngay = dinhdang.Substring(0, 2);
                string nam = dinhdang.Substring(6, 4);
                lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            }
            }
            GanNgonNguVaoConTrol();
        }
        public void GanNgonNguVaoConTrol()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                btnUndo.Text = "Quay về trang chủ ";
            }
            else if (ngonngu == "lbl_TW")
            {
                btnUndo.Text = "返回主页";
            }
            else if (ngonngu == "lbl_EN")
            {
                btnUndo.Text = "Back ";
            }
        }
        protected void btnUndo_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieuchuadichND.aspx");
        }
    }
}