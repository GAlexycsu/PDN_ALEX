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
    public partial class frmPreviewND :LanguegeBus
    {
        iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                HienThi();
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
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
            btnEdit.Text = hasLanguege["btnEdit"].ToString();

        }
        private void HienThi()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();
            string manguoidung = Session["user"].ToString();
            //string tenloaiphieu = Session["loaiP"].ToString();
            DateTime date = DateTime.Now;
            //pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, macongty, true);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                if (phieu == null)
                {
                    string noidung = Session["noidung"].ToString();
                    string ngaytao = Session["ngaytao"].ToString();
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    BDepartment donvi = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = donvi.DepName;
                    lbSoPhieu.Text = idphieu;
                    lbNoiDung.Text = noidung;
                    //lbNgay.Text = ngaytao;

                    string dinhdang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    string ngay = dinhdang.Substring(3, 2);
                    string thang = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }
                else
                {
                    BDepartment donvi = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                    lbBoPhan.Text = donvi.DepName;
                    lbSoPhieu.Text = idphieu;
                    lbNoiDung.Text = phieu.pdmemovn;
                    //lbNgay.Text = phieu.CFMDate0.ToString();
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;

                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lblNoiDungDich.Text = phieu.NoiDungDich;
                    string dinhdang = phieu.CFMDate0.ToString();
                    string ngay = dinhdang.Substring(3, 2);
                    string thang = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("frmTrinhDuyetND.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("chinhsuaphieuND.aspx");
        }
    }
}