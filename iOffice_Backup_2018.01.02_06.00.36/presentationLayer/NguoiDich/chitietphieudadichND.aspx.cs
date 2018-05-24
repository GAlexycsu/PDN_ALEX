using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.Share;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class chitietphieudadichND : System.Web.UI.Page
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            //pdna phieu = pnaDAO.LayVanBanDaDichTheoNguoiDich(maphieu, macongty, manguoidung);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'"));
             var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {

                BDepartment bophan = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                if (!IsPostBack)
                {

                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;

                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan.DepName;
                    lbLoaiPhieu.Text = loaiphieu.abname;
                    //lbNgay.Text = ;
                    txtTieuDe.Text = phieu.pdnsubject;
                    lbNoiDung.Text = phieu.pdmemovn;
                    lbSoPhieu.Text = phieu.pdno;
                    string dinhdang = phieu.CFMDate0.ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    CKEditorControl1.Text = phieu.NoiDungDich;
                    CKEditorControl1.ReadOnly = true;
                    CKEditorControl1.Enabled = false;
                    btnLuu.Enabled = false;
                }
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();

            PDNSheetFlow kiemtra = PDNSheetFlowDAO.LayPDNSheetFlowCuaBuoc1(maphieu, macongty);
            if (kiemtra==null)
            {
                CKEditorControl1.ReadOnly = false;
                CKEditorControl1.Enabled = true;
                btnLuu.Enabled = true;
            }
            else
            {
                lbThongbaoloi.Text = "Phiếu này đã được xét duyệt nên không thể sửa được";
            }
            btnSua.Enabled = false;
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["user"].ToString();
            string NOIDUNG = CKEditorControl1.Text;
            DateTime date = DateTime.Now;
         
            PDNSheetFlow kiemtra = PDNSheetFlowDAO.LayPDNSheetFlowCuaBuoc1(maphieu, macongty);
            if (kiemtra==null)
            {
               // CKEditorControl1.ReadOnly = false;
                pdna phieu = pnaDAO.LayVanBanDaDichTheoNguoiDich(maphieu, macongty, manguoidung);
                pdna phieudich = new pdna();
                phieudich.GSBH = macongty;
                phieudich.pdno = phieu.pdno;
                phieu.CFMDate2 = date;
                phieudich.CFMDate4 = date;
                phieudich.NoiDungDich = CKEditorControl1.Text;
                phieudich.trangthaidich = true;
                phieudich.IdnguoiDich = manguoidung;
              //  pnaDAO.CapNhatPhieuDich(phieudich, macongty);
               db.CapNhatPhieuDich(phieudich.pdno, phieudich.GSBH, phieudich.NoiDungDich, phieudich.CFMDate2,txtTieuDe.Text, phieudich.IdnguoiDich, phieudich.trangthaidich);
               // pdna phieu1 = pnaDAO.LayVanBanDaDichTheoNguoiDich(maphieu, macongty, manguoidung);
               db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieudich.pdno + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'"));
               var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieudich.pdno + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'");
               foreach (pdna phieu1 in list)
               {
                   if (phieu1.trangthaidich == true)
                   {
                       if (ngonngu == "lbl_VN")
                       {
                           lbThongBao.Text = "Lưu thành công, văn bản đã dịch sẽ gửi đến người nhờ dịch";
                       }
                       else if (ngonngu == "lbl_TW")
                       {
                           lbThongBao.Text = "审核成功";
                       }
                       else if (ngonngu == "lbl_EN")
                       {
                           lbThongBao.Text = "Save Success.";
                       }
                       Response.Redirect("frmChiTietDichND.aspx");
                   }
               }
            }
            else
            {
                lbThongbaoloi.Text = "Phiếu này đã được xét duyệt nên không thể sửa được";
            }
        }

        protected void CKEditorControl1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}