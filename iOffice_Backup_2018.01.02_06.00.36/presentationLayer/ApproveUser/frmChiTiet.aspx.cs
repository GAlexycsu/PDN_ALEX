using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.BUS;
using iOffice.Share;
using System.Data;
using System.Data.SqlClient;

namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmChiTiet : System.Web.UI.Page
    {
        dalPDNLink dal = new dalPDNLink();
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
            }
            TextBox1.Visible = false;
        }
        private void HienThi()
        {
            string idphieu = Session["maphieu"].ToString();
            //string bophan = Session["bophan"].ToString();

            //string noidung = Session["noidung"].ToString();
            //string ngaytao = Session["ngaythang"].ToString();
            string user = Session["user"].ToString();
            string bp = Session["bp"].ToString();
            string congty = Session["congty"].ToString();
            BDepartment bophan = BDepartmentBUS.TimMaDonVi(bp, congty);
            //string loaiphieu = Session["loaiphieu"].ToString();
            pdna phieu = pdnaBUS.TimVanBanTheoMa(idphieu, congty, true);
            abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);

            
            string tenloaiphieuVN = loaiphieu.abname;
            string tenloaiphieuTW = loaiphieu.abnameTW;

            lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;

            lbBoPhan.Text = bophan.DepName;
            lbSoPhieu.Text = idphieu;
            lbNoiDung.Text = phieu.pdmemovn;
            LbNoiDungDich.Text = phieu.NoiDungDich;
            //lbNgay.Text = phieu.CFMDate0.ToString();
           
            string dinhdang = phieu.CFMDate0.ToString();
            string thang = dinhdang.Substring(3, 2);
            string ngay = dinhdang.Substring(0, 2);
            string nam = dinhdang.Substring(6, 4);
            lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
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