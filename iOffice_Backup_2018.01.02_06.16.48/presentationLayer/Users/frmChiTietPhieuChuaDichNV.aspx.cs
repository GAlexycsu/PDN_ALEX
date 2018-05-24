using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.Share;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class frmChiTietPhieuChuaDichNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDN dal = new dalPDN();
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
                    LayngonNgu(3, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                List<pdna> list = db.pdnas.ToList();
                if (list.Count() > 0)
                {
                    //pdna phieu = pnaDAO.LayVanBanChuaDichTheoNguoiTrinhKy(maphieu, macongty, manguoidung);
                    DataTable dt=dal.TimPhieuGuiNguoiDich(maphieu,macongty,manguoidung);
                    if (dt.Rows.Count>0)
                    {
                        string madonvi=dt.Rows[0]["pddepid"].ToString();
                        string abtype=dt.Rows[0]["Abtype"].ToString();
                        string noidung=dt.Rows[0]["pdmemovn"].ToString();
                        string ngayt=dt.Rows[0]["CFMDate0"].ToString();
                        BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                        abill loaiphieu = abillBUS.SearchAbillByID(abtype);

                        string tenloaiphieuVN = loaiphieu.abname;
                        string tenloaiphieuTW = loaiphieu.abnameTW;

                        lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                        lbBoPhan.Text = bophan.DepName;

                        //lbNgay.Text = ;
                        lblNoiDung.Text = noidung;
                        lbSoPhieu.Text = maphieu;
                        string dinhdang = ngayt;
                        string thang = dinhdang.Substring(3, 2);
                        string ngay = dinhdang.Substring(0, 2);
                        string nam = dinhdang.Substring(6, 4);
                        lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    }
                }
            }
            // string ngaythang = DateTime.Parse(phieu.CFMDate0.ToString("dd/MM/yyyy"));
           
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("danhsachvanbanchuadichNV.aspx");
        }
    }
}