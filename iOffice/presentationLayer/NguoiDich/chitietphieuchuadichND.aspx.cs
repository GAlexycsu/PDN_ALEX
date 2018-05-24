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
    public partial class chitietphieuchuadichND : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(25, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                //pdna phieu = pnaDAO.LayVanBanChuaDichTheoNguoiDich(maphieu, macongty, manguoidung);
                  db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty+ "' and IDNguoiDich='" + manguoidung + "'"));
                  var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and IDNguoiDich='" + manguoidung + "'");
              foreach (pdna phieu in list)
              {
                  // string ngaythang = DateTime.Parse(phieu.CFMDate0.ToString("dd/MM/yyyy"));
                  BDepartment bophan = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                  abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);

                  string tenloaiphieuVN = loaiphieu.abname;
                  string tenloaiphieuTW = loaiphieu.abnameTW;

                  lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                  lbBoPhan.Text = bophan.DepName;

                  //lbNgay.Text = ;
                  lbNoiDung.Text = phieu.pdmemovn;
                  lbSoPhieu.Text = phieu.pdno;
                  lblTieuDe.Text = phieu.mytitle;
                  string dinhdang = phieu.CFMDate0.ToString();
                  string thang = dinhdang.Substring(3, 2);
                  string ngay = dinhdang.Substring(0, 2);
                  string nam = dinhdang.Substring(6, 4);
                  lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
              }
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            string ngonngu = Session["languege"].ToString();
            if (ngonngu == "lbl_VN")
            {
                btnLuu.Text = "Lưu ";
            }
            else if (ngonngu == "lbl_TW")
            {
                btnLuu.Text = "同意";
            }
            else if (ngonngu == "lbl_EN")
            {
                btnLuu.Text = "Save ";
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            string manguoidung = Session["user"].ToString();
          
              DateTime date = DateTime.Now;
          //  string ngaydich = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
            pdna phieu = pnaDAO.LayVanBanChuaDichTheoNguoiDich(maphieu, macongty, manguoidung);
            pdna phieudich = new pdna();
            phieudich.pdno = maphieu;
            phieudich.CFMDate2 = date;
            phieudich.GSBH = macongty;

            phieudich.NoiDungDich = CKEditorControl1.Text;
            phieudich.trangthaidich = true;
            phieudich.IdnguoiDich =manguoidung;
           
            //db.CapNhatPhieuDich(phieudich.pdno, phieudich.GSBH, phieudich.NoiDungDich, phieudich.CFMDate2,txtTieuDe.Text, phieudich.IdnguoiDich, phieudich.trangthaidich);
            dalPDN dal = new dalPDN();
            dal.CapNhatPhieuDich(manguoidung, macongty, maphieu, txtTieuDe.Text, CKEditorControl1.Text, date);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieudich.pdno + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'"));
               var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + phieudich.pdno + "'and GSBH='" + macongty + "' and IdnguoiDich='" + manguoidung + "'");
            foreach (pdna phieu1 in list)
            //pdna phieu1 = pnaDAO.LayVanBanDaDichTheoNguoiDich(maphieu, macongty, manguoidung);
            {
                if (phieu1.trangthaidich == true)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lbThongBao.Text = "Lưu thành công, văn bản đã dịch sẽ gửi đến người nhờ dịch";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lbThongBao.Text = "存档成功，资料已经翻译完成请确认";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lbThongBao.Text = "Save Success.";
                    }
                    btnLuu.Enabled = false;
                    Response.Redirect("frmChiTietDichND.aspx");
                }
            }
        }
       
        protected void CKEditorControl1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}