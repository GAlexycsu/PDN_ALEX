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
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class chitietphieudadich : LanguegeBus
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
                    LayngonNgu(33, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                string maphieu = Session["maphieu"].ToString();
                string macongty = Session["congty"].ToString();
                string manguoidung = Session["user"].ToString();
                //pdna phieu = pnaDAO.LayVanBanTheoNguoiTrinh(maphieu, macongty, manguoidung);
                DataTable dt = dal.TimPhieuTheoMaNguoiTao(maphieu, macongty, manguoidung);
                if (dt.Rows.Count>0)
                {
                    string ngaythang=dt.Rows[0]["CFMDate0"].ToString();
                    string madonvi = dt.Rows[0]["pddepid"].ToString().Trim();
                    string maloaiphieu = dt.Rows[0]["Abtype"].ToString().Trim();
                    string noidung = dt.Rows[0]["pdmemovn"].ToString().Trim();
                    string tieude = dt.Rows[0]["mytitle"].ToString().Trim();
                    string tieudedich = dt.Rows[0]["pdnsubject"].ToString().Trim();
                    string noidungdich = dt.Rows[0]["NoiDungDich"].ToString();
                    int Yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                    Session["loaiphieu"] = maloaiphieu;
                    Session["bp"] = madonvi;
                    Session["noidung"] = noidung;
                    Session["noidungdich"] = noidungdich;
                    Session["tieude"] = tieude;

                   
                        if (Yn==6)
                        {
                            BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, macongty);
                            abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);

                            string tenloaiphieuVN = loaiphieu.abname;
                            string tenloaiphieuTW = loaiphieu.abnameTW;

                            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                            string dinhdang = ngaythang;
                            string thang = dinhdang.Substring(3, 2);
                            string ngay = dinhdang.Substring(0, 2);
                            string nam = dinhdang.Substring(6, 4);
                            lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
                            lbBoPhan.Text = bophan.DepName;
                            lblTieuDe.Text = tieude +" " + tieudedich;

                            lbNoiDung.Text =noidungdich;
                            lbSoPhieu.Text = maphieu;
                            LbNoiDungDich.Text = noidungdich;
                        }
                    
                }
            }
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnUndo.Text = hasLanguege["btnUndo"].ToString();
            btnContinus.Text = hasLanguege["btnContinus"].ToString();
        }
        protected void btnUndo_Click(object sender, EventArgs e)
        {
            Response.Redirect("danhsachphieudadich.aspx");
        }

        protected void btnContinus_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmTrinhDuyetCB.aspx");
        }
    }
}