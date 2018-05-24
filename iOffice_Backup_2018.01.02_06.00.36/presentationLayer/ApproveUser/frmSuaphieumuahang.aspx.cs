using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class frmSuaphieumuahang : System.Web.UI.Page
    {
        int STT = 1;
        static iOfficeDataContext db = new iOfficeDataContext();
        dalPDNLink dal = new dalPDNLink();
        dalPDN dap = new dalPDN();
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
                HienThiPhieuMuaHang();
                HienThiDanhSach();
                ShowFileDinhKem();
            }
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            // Try to use parameterized inline query/sp to protect sql injection
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP " + count + " dwbh FROM clzl where dwbh!='NULL' and dwbh  LIKE '" + prefixText + "%'", conn);
            SqlDataReader oReader;
            conn.Open();
            List<string> CompletionSet = new List<string>();
            oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (oReader.Read())
                CompletionSet.Add(oReader["dwbh"].ToString());
            return CompletionSet.ToArray();
        }
        [WebMethod]
        public static string[] GetCategory(string term)
        {
            List<string> retCategory = new List<string>();
            // string ConnectionString = @"Data Source=192.168.11.15;Initial Catalog=LY_ERP;User ID=Programer;Password=P@ssw0rd";
            // string ConnectionString = @"Data Source=192.168.11.6;Initial Catalog=LY_ERP;User ID=sa;Password=tuan123";
            string connectionString = ConfigurationManager.ConnectionStrings["TheLogiS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select  distinct top 20 ywpm, cldh  from clzl where ywpm like +@SearchText+'%'", con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchText", term);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        retCategory.Add(string.Format("{0}^^{1}", dr["ywpm"], dr["cldh"]));

                    }
                    return retCategory.ToArray();
                }

            }
            //return retCategory.ToArray();
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
        public void HienThiDanhSach()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            dalPDN dal = new dalPDN();
            DataTable dt = dal.QryHangTheoMaHang(idphieu, macongty);
            
             GridView1.DataSource = dt;
             GridView1.DataBind();
           
        }
        private void HienThiPhieuMuaHang()
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();

            string manguoidung = Session["user"].ToString();

            DataTable dt = dap.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
            if (dt.Rows.Count>0)
            {


                string ngaythang = dt.Rows[0]["CFMDate0"].ToString();
                string madonvi = dt.Rows[0]["pddepid"].ToString().Trim();
                string maloaiphieu = dt.Rows[0]["Abtype"].ToString().Trim();
                string noidung = dt.Rows[0]["pdmemovn"].ToString().Trim();
                string tieude = dt.Rows[0]["mytitle"].ToString().Trim();
                string tieudedich = dt.Rows[0]["pdnsubject"].ToString().Trim();
                string noidungdich = dt.Rows[0]["NoiDungDich"].ToString();
                int Yn = int.Parse(dt.Rows[0]["Yn"].ToString());
                BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;
                txtTieuDe.Text = tieude;
                lblPhieuMuaHang.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                lbldonvidenghi.Text = donvi.DepName;
                lblsophieu.Text = idphieu;
                lblMucDichSuDung.Text = dt.Rows[0]["UseIntent"].ToString();

                string dinhdang = ngaythang;
                string thang = dinhdang.Substring(3, 2);
                string ngay = dinhdang.Substring(0, 2);
                string nam = dinhdang.Substring(6, 4);
                lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";


            }
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string user = Session["user"].ToString();
            string tenhang = txtAutoComplete.Text.Trim();
            string donvitinh = txtdonvitinh.Text.ToUpper();
            string soluong = txtSoLuong.Text.Trim();
            string ghichu = txtGhiChu.Text.Trim();
            string mahang = txtMaHang.Text.Trim();
            string Size = "";
            string congty = Session["congty"].ToString();
            string maphieu = Session["maphieu"].ToString();
            string themhang = (string)Session["themhang"];
            string mahangcu = (string)Session["mahangcu"];
            string sizecu = (string)Session["sizecu"];
            
          
          
            DateTime date = DateTime.Today;
            if (txtSize.Text.Trim() == "")
            {
                Size = "ZZZZZZ";
            }
            else
            {
                try
                {
                    decimal sl = decimal.Parse(txtSize.Text.Trim());
                    Size = sl.ToString();
                }
                catch
                {
                    Size = "ZZZZZZ";
                }
            }
            dalPDN dal = new dalPDN();
            DataTable dtTim = dal.TimMaHangTrongPhieu(congty, mahang, maphieu);
            if (themhang == null)
            {
                if (dtTim.Rows.Count > 0)
                {
                    dal.SuaHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                }
                else
                {
                    dal.ThemHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                }
                HienThiDanhSach();

            }
            else
            {
                if (mahangcu != null && mahangcu == mahang)
                {
                    if (sizecu == Size)
                    {
                        dal.SuaHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                    }
                    else
                    {
                        dal.XoaHang(congty, mahangcu, maphieu, sizecu);
                        dal.ThemHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                    }
                    HienThiDanhSach();
                    Session.Remove("themhang");
                    Session.Remove("mahangcu");
                    Session.Remove("sizecu");
                }
                else
                {
                    dal.XoaHang(congty, mahangcu, maphieu, sizecu);
                  
                    if (dtTim.Rows.Count > 0)
                    {
                        dal.SuaHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                     
                    }
                    else
                    {
                        dal.ThemHang1(congty, mahang, maphieu, Size, decimal.Parse(soluong), tenhang, ghichu);
                        
                    }
                    HienThiDanhSach();
                    Session.Remove("themhang");
                    Session.Remove("mahangcu");
                    Session.Remove("sizecu");
                }
            }
            txtAutoComplete.Enabled = true;
            txtMaHang.Enabled = true;
            txtSize.Enabled = true;
            txtAutoComplete.Text = "";
            txtdonvitinh.Text = "";
            txtGhiChu.Text = "";
            txtMaHang.Text = "";
            txtSize.Text = "";
            txtSoLuong.Text = "";
           
           
        }

        protected void btnComplete_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string maphieu = Session["maphieu"].ToString();
            pdna phieu = pnaDAO.TimVanBanTheoMa(maphieu, macongty, true);
            db.ExecuteCommand("update pdna set mytitle=N'" + txtTieuDe.Text.Trim() + "',CFMDate0=GETDATE()  where pdno='" + maphieu + "'and  GSBH='" + macongty + "'");
            Session["loaiphieu"] = phieu.Abtype.ToString();
            Response.Redirect("FrmViewCB.aspx");
        }

        protected void btnTroLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyDocusRe.aspx");
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Label lblMaCty1 = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblGSBH");
            Label lbMaPhieu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblPDNO");
            Label lbMaHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLBH");
            Label lbTenHang = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblMemo0");
            Label lbSize = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblSize");
            Label lbDonVT = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblDWBH");
            Label lbGhiChu = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblCLMemo");
            Label lbSoLuong = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblQty");
            
            Label lblZSBH = (Label)GridView1.Rows[e.NewEditIndex].FindControl("lblZSBH");
            txtAutoComplete.Text = lbTenHang.Text.Trim();
            txtdonvitinh.Text = lbDonVT.Text.Trim();
            txtMaHang.Text = lbMaHang.Text.Trim();
            txtSize.Text = lbSize.Text.Trim();
            txtSoLuong.Text = lbSoLuong.Text.Trim();
            txtGhiChu.Text = lbGhiChu.Text.Trim();
            //txtAutoComplete.Enabled = false;
            //txtMaHang.Enabled = false;
            //txtSize.Enabled = false;
            Session["congty"] = lblMaCty1.Text.Trim();
         
            Session["ZSBH"] = lblZSBH.Text.Trim();
            Session["maphieu"] = lbMaPhieu.Text.Trim();
            Session["themhang"] = "them";
            Session["mahangcu"] = lbMaHang.Text.Trim();
            Session["sizecu"] = lbSize.Text.Trim();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblMaCty1 = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGSBH");
            Label lbMaPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblPDNO");
            Label lbMaHang = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCLBH");
            Label lbSize = (Label)GridView1.Rows[e.RowIndex].FindControl("lblSize");

            dalPDN dal = new dalPDN();
            dal.XoaHang(lblMaCty1.Text, lbMaHang.Text, lbMaPhieu.Text, lbSize.Text);
            HienThiDanhSach();
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