using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
    public partial class chitietphieudadichNV : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int STT = 1;
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
                    LayngonNgu(33, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                string macongty=Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                pdna phieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty);
                if (phieu.Abtype == "PDN2" && phieu != null)
                {
                    divPhieuDeNghi.Visible = false;
                    divPhieuMuaHang.Visible = true;
                    HienThiDanhSachMuaHang();
                    HienThiPhieuMuaHang();

                }
                else
                {
                    divPhieuDeNghi.Visible = true;
                    divPhieuMuaHang.Visible = false;
                    HienThi();
                }
            }
           
            
        }
        public void HienThiDanhSachMuaHang()
        {
            dalPDN dal = new dalPDN();
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count < 6)
                {
                    DataRow dr = dt.NewRow();
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    DataRow dr3 = dt.NewRow();
                    DataRow dr4 = dt.NewRow();
                    DataRow dr5 = dt.NewRow();
                    DataRow dr6 = dt.NewRow();
                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr1);
                    dt.Rows.Add(dr2);
                    dt.Rows.Add(dr3);
                    dt.Rows.Add(dr4);
                    dt.Rows.Add(dr5);
                    dt.Rows.Add(dr6);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            string bophan = Session["bophan"].ToString();
            string manguoidung = Session["user"].ToString();

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                // pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu,macongty, true);
                if (phieu == null)
                {
                    string noidung = Session["noidung"].ToString();
                    string ngaytao = Session["ngaytao"].ToString();
                    lbldonvidenghi.Text = bophan;
                    lblsophieu.Text = idphieu;


                    DateTime date = DateTime.Now;
                    string dinhdang = DateTime.Parse(date.ToShortDateString()).ToString("dd/MM/yyyy");
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }
                else
                {
                    abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;

                    TenLblLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbldonvidenghi.Text = bophan;
                    lblsophieu.Text = idphieu;
                    lblMucDichSuDung.Text = phieu.UseIntent;

                    string dinhdang = phieu.CFMDate0.ToString();
                    string thang = dinhdang.Substring(3, 2);
                    string ngay = dinhdang.Substring(0, 2);
                    string nam = dinhdang.Substring(6, 4);
                    lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                }

            }
        }
        private void HienThi()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            string manguoidung = Session["user"].ToString();
            // pdna phieu = pnaDAO.LayVanBanTheoNguoiTrinh(maphieu, macongty,manguoidung);
            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + maphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {
                Session["loaiphieu"] = phieu.Abtype;
                Session["bp"] = phieu.pddepid;
                Session["noidung"] = phieu.pdmemovn;
                Session["noidungdich"] = phieu.NoiDungDich;
                Session["tieude"] = phieu.mytitle;

                if (phieu == null)
                {
                    return;
                }
                else
                {
                    if (phieu.trangthaidich == true)
                    {
                        BDepartment bophan = BDepartmentBUS.TimMaDonVi(phieu.pddepid, macongty);
                        abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);

                        string tenloaiphieuVN = loaiphieu.abname;
                        string tenloaiphieuTW = loaiphieu.abnameTW;

                        lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;

                        lbBoPhan.Text = bophan.DepName;

                        // lbNgay.Text =ngaytao ;
                        lbNoiDung.Text = phieu.pdmemovn;
                        lbSoPhieu.Text = phieu.pdno;
                        LbNoiDungDich.Text = phieu.NoiDungDich;
                        string dinhdang = phieu.CFMDate0.ToString();
                        string thang = dinhdang.Substring(3, 2);
                        string ngay = dinhdang.Substring(0, 2);
                        string nam = dinhdang.Substring(6, 4);
                        lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                    }
                }
            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnUndo.Text = hasLanguege["btnUndo"].ToString();
            btnContinus.Text = hasLanguege["btnContinus"].ToString();
        }
        protected void btnUndo_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachvanbandadichNV.aspx");
        }

        protected void btnContinus_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmTrinhDuyet.aspx");
        }
    }
}