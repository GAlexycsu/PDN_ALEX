using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;

namespace iOffice.presentationLayer.Users
{
    public partial class frmSuaphieumuahangNV : System.Web.UI.Page
    {
        int STT = 1;
        static iOfficeDataContext db = new iOfficeDataContext();
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
                HienThiPhieuMuaHang();
                HienThiDanhSach();
                ShowFileDinhKem();
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

            db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'"));
            var list = db.ExecuteQuery<pdna>("select * from pdna where pdno='" + idphieu + "'and GSBH='" + macongty + "' and CFMID0='" + manguoidung + "'");
            foreach (pdna phieu in list)
            {

                abill loaiphieu = abillBUS.SearchAbillByID(phieu.Abtype);
                BDepartment donvi = BDepartmentDAO.TimMaDonVi(phieu.pddepid, macongty);
                string tenloaiphieuVN = loaiphieu.abname;
                string tenloaiphieuTW = loaiphieu.abnameTW;
                txtTieuDe.Text = phieu.mytitle;
                lblPhieuMuaHang.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                lbldonvidenghi.Text = donvi.DepName;
                lblsophieu.Text = idphieu;
                lblMucDichSuDung.Text = phieu.UseIntent;

                string dinhdang = phieu.CFMDate0.ToString();
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            
            HienThiDanhSach();
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
            
            Label lblZSBH=(Label)GridView1.Rows[e.NewEditIndex].FindControl("lblZSBH");
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblmahang = (Label)GridView1.Rows[e.RowIndex].FindControl("lblCustID");
            TextBox tenhang = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtOfSuppliesName");
            TextBox donvi = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBUnit");
            TextBox soluong = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBNumber");
            TextBox ghichu = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBCommnent");
            BOfSupply vattu = new BOfSupply();
            vattu.IDOfSupplies = int.Parse(lblmahang.Text.ToString());
            vattu.OfSuppliesName = tenhang.Text.ToUpper();
            vattu.BUnit = donvi.Text.ToUpper();
            vattu.BNumber = int.Parse(soluong.Text.ToString());
            vattu.BCommnent = ghichu.Text;
            SuppliesDAO.SuaVatTu(vattu);
            GridView1.EditIndex = -1;
            HienThiDanhSach();
        }
        private void KiemTraPhieu()
        {
            string macongty = Session["congty"].ToString();
            string maphieu = Session["maphieu"].ToString();
            List<BOfSupply> kiemtra = SuppliesDAO.QryHangTheoPhieu(maphieu, macongty);
            if (kiemtra.Count == 0)
            {
                tablePMH.Visible = true;
                
            }
            else
            {
                tablePMH.Visible = false;
            }
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string macongty = Session["congty"].ToString();
                string maphieu = Session["maphieu"].ToString();
                TextBox tenhang = (TextBox)GridView1.FooterRow.FindControl("txtAddOfSuppliesName");
                TextBox donvitinh = (TextBox)GridView1.FooterRow.FindControl("txtAddBUnit");
                TextBox soluong = (TextBox)GridView1.FooterRow.FindControl("txtAddBNumber");
                TextBox ghichu = (TextBox)GridView1.FooterRow.FindControl("txtAddBCommnent");
                BOfSupply hang = new BOfSupply();
                hang.GSBH = macongty;
                hang.pdno = maphieu;
                hang.OfSuppliesName = tenhang.Text.ToUpper();
                hang.BUnit = donvitinh.Text.ToUpper();
                hang.BNumber = int.Parse(soluong.Text);
                hang.BCommnent = ghichu.Text;
                SuppliesDAO.ThemVatTu(hang);
                GridView1.EditIndex = -1;
                GridView1.DataSource = pnaDAO.LayPhieuMuaHang(maphieu, macongty);
                GridView1.DataBind();
                tenhang.Focus();
            }
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
            
            
         
            DateTime date=DateTime.Today;
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
            Response.Redirect("FrmView.aspx");
           
        }
        protected void btnTroLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyDocusNV.aspx");
        }

        protected void txtAutoComplete_TextChanged(object sender, EventArgs e)
        {
            if (txtAutoComplete.Text.Trim() == "")
            {
                txtMaHang.Text = "";
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

        protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}