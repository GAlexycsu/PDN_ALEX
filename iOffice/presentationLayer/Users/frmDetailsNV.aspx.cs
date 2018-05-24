using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Users
{
   
    public partial class frmDetailsNV : System.Web.UI.Page
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDNLink dal = new dalPDNLink();
        dalPDN dalP = new dalPDN();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    //Response.Redirect("~/presentationLayer/DangNhap.aspx");
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                divUpload2.Visible = false;
                HienThi();
                HienThiThongTinBiHuy();
                ShowFileDinhKem();
            }
            TextBox1.Visible = false;
        }
        private void ShowFileDinhKem()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dal.QryFileDinhKem(maphieu, macongty);
            if (dt.Rows.Count > 0)
            {
                divUpload2.Visible = true;
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
                
            }
            else
            {
                divUpload2.Visible = false;
            }
        }
        private void HienThiThongTinBiHuy()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            pdna phieu = pnaDAO.TimPhieuDaTungBiHuy(maphieu, macongty);
            if (phieu != null)
            {
                string sophieucu = phieu.oldpdno;
                Label1Sophieucu.Visible = true;
                Label2cophieucu.Visible = true;

                Session["sophieucu"] = sophieucu;
                Label2cophieucu.Text = sophieucu;
            }
            else
            {
                Label1Sophieucu.Visible = false;
                Label2cophieucu.Visible = false;
            }
        }

        private void HienThi()
        {
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();

            //string noidung = Session["noidung"].ToString();
            //string ngaytao = Session["ngaythang"].ToString();
            string user=Session["user"].ToString();
           
            string congty = Session["congty"].ToString();
           
            DataTable dt = dalP.TimPhieuTheoMaNguoiTao(idphieu, congty, user);
             if (dt.Rows.Count>0)
             {
                 string madonvi = dt.Rows[0]["pddepid"].ToString();
                 string maloaiphieu = dt.Rows[0]["Abtype"].ToString();
                 int Abc = int.Parse(dt.Rows[0]["ABC"].ToString());
                 BDepartment bophan = BDepartmentBUS.TimMaDonVi(madonvi, congty);
                 abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                 aABC douutien = ABCDAO.TimDoUuTien(Abc);
                 string tenloaiphieuVN = loaiphieu.abname;
                 string tenloaiphieuTW = loaiphieu.abnameTW;

                 if (douutien != null)
                 {
                     lblDoUutien.Text = douutien.NameABC + "-" + douutien.NameABCTW;
                 }
                 lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                 

                 lblTieuDe.Text = dt.Rows[0]["mytitle"].ToString() +" " + dt.Rows[0]["pdnsubject"].ToString();
                 lbBoPhan.Text = bophan.DepName;
                 lbSoPhieu.Text = idphieu;
                 lbNoiDung.Text = dt.Rows[0]["pdmemovn"].ToString();
                 LbNoiDungDich.Text = dt.Rows[0]["NoiDungDich"].ToString();
                 //lbNgay.Text = phieu.CFMDate0.ToString();
                 string dinhdang = dt.Rows[0]["CFMDate0"].ToString();
                 string thang = dinhdang.Substring(3, 2);
                 string ngay = dinhdang.Substring(0, 2);
                 string nam = dinhdang.Substring(6, 4);
                 lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";

             }
            Busers2 user0 = AbconBUS.LayMaNguoiTaoTheoIDVanBan(idphieu, congty);
            if (user0 != null)
            {
                TextBox1.Text = user0.USERID;
                //ImageLevel0.ImageUrl = users.signatue;
                ImageLevel0.Width = 100;
                ImageLevel0.Height = 100;
                ImageLevel0.ImageUrl = "~/MyPhoto.ashx?USERID=" + TextBox1.Text;
            }

        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            LinkButton linkbtn = sender as LinkButton;
            GridViewRow grdRow = linkbtn.NamingContainer as GridViewRow;
            string filePath = gvDetails.DataKeys[grdRow.RowIndex].Value.ToString();

            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}