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
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.NguoiDich
{
    public partial class ChiTietPhieuTraVeDaDich1 : System.Web.UI.Page
    {
        iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal = new dalPDN();
        abconDAL dalAbcon = new abconDAL();
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
                    txtNguoiDUyet.Text = phieu.CFMID1;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = bophan.DepName;
                    lbLoaiPhieu.Text = loaiphieu.abname;
                    lblTieuDe.Text = phieu.mytitle;
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
            string ngonngu = Session["languege"].ToString();
            DataTable dt = dalAbcon.KiemTraNguoiDuyetPhieu(maphieu, macongty, txtNguoiDUyet.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                string Yn = dt.Rows[0]["Yn"].ToString();
                if (Yn == "4")
                {
                    CKEditorControl1.ReadOnly = false;
                    CKEditorControl1.Enabled = true;
                    btnLuu.Enabled = true;
                }
                else
                {
                    
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao.Text = "Phiếu này đã được xét duyệt nên không thể sửa được";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao.Text = " 这分单已经审核，不可修改";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao.Text = "Can not modify because PDN aproved";
                    }
                }
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
            string ngaydich = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
            PDNSheetFlow kiemtra = PDNSheetFlowDAO.LayPDNSheetFlowCuaBuoc1(maphieu, macongty);
            int Yn = 4;
            if (kiemtra == null)
            {
                // 
                dal.CapNhatPhieuDich1(manguoidung, macongty, maphieu, txtTieuDe.Text.Trim(), CKEditorControl1.Text.Trim(), date, Yn);
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'"));
                var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'");
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
    }
}