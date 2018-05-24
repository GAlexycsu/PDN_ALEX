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
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class ChiTietPhieuBiHuyCB2 : LanguegeBus
    {
        dalPDN dal = new dalPDN();
        abconDAL dalAbcon = new abconDAL();
        dalPDNLink dalLink = new dalPDNLink();
        int STT = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(30, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                txtTieuDe.Enabled = false;
                txtTieuDeTW.Enabled = false;
                txtPhanHoi.Enabled = false;
                txtNguoiCoDUyet.Enabled = false;
                btnGuiNguoiDich.Enabled = false;
                btnLuu.Enabled = false;
                btnLuu.Attributes.CssStyle.Add("opacity", "0.5");
                btnGuiNguoiDich.Attributes.CssStyle.Add("opacity", "0.5");
                HienThiThongTin();
                HienThiDanhSach();
                ShowFileDinhKem();
                HienThiNguoiDich();
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            CheckChon.Text = hasLanguege["CheckChon"].ToString();
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
            btnGuiNguoiDich.Text = hasLanguege["btnGuiNguoiDich"].ToString();
            btnEdit.Text = hasLanguege["btnEdit"].ToString();
            btnBack.Text = hasLanguege["btnBack"].ToString();
        }
        private void HienThiNguoiDich()
        {
            string ngonngu = Session["languege"].ToString();

            DropDownNguoiDich.DataSource = NguoiDichDAO.QryNguoiDich();
            DropDownNguoiDich.DataValueField = "USERID";
            if (ngonngu == "lbl_VN")
            {
                DropDownNguoiDich.DataTextField = "TenNguoiDich";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownNguoiDich.DataTextField = "TenNguoiDichTiengHoa";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownNguoiDich.DataTextField = "TenNguoiDich";
            }

            DropDownNguoiDich.DataBind();
        }
        public void HienThiThongTin()
        {
            string UserID = Session["user"].ToString();
            string congty = Session["congty"].ToString();
            string maphieu = Session["MaPhieu"].ToString();
            DataTable dt = dal.LayThongTinPhieuCoYKien1(UserID, congty, maphieu);
            if (dt.Rows.Count > 0)
            {
                string mytitle = dt.Rows[0]["mytitle"].ToString();
                string pdnsubject = dt.Rows[0]["pdnsubject"].ToString();
                string Abtype = dt.Rows[0]["Abtype"].ToString();
                string abname = dt.Rows[0]["abname"].ToString();
                string CFMDate0 = dt.Rows[0]["CFMDate0"].ToString();
                string CFMID1 = dt.Rows[0]["CFMID1"].ToString();
                string USERNAME = dt.Rows[0]["USERNAME"].ToString();
                string pdmemovn = dt.Rows[0]["pdmemovn"].ToString();
                string NoiDungDich = dt.Rows[0]["NoiDungDich"].ToString();
                string pdmemovn1 = dt.Rows[0]["pdmemovn1"].ToString();
                string IDDepart = dt.Rows[0]["ID"].ToString();
                string DepName = dt.Rows[0]["DepName"].ToString();
                string UseIntent = dt.Rows[0]["UseIntent"].ToString();
                txtMucDichSuDung.Text = UseIntent;
                txtNguoiChoDuyetID.Text = CFMID1;
                txtNguoiCoDUyet.Text = USERNAME;
                txtTieuDeTW.Text = pdnsubject;
                txtTieuDe.Text = mytitle;

                lblPhieuMuaHang.Text = abname;
                lbldonvidenghi.Text = DepName;
                txtDepartID.Text = IDDepart;
                lblsophieu.Text = maphieu;

                string thang = CFMDate0.Substring(3, 2);
                string ngay = CFMDate0.Substring(0, 2);
                string nam = CFMDate0.Substring(6, 4);
                lblNgaytao.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            }
        }
        private void ShowFileDinhKem()
        {
            string maphieu = Session["maphieu"].ToString();
            string macongty = Session["congty"].ToString();
            DataTable dt = dalLink.QryFileDinhKem(maphieu, macongty);
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
            string maphieu = Session["MaPhieu"].ToString();
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

        protected void CheckChon_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckChon.Checked == true)
            {
                btnEdit.Visible = false;
                btnLuu.Visible = false;
                DropDownNguoiDich.Enabled = true;

            }
            else
            {
                btnEdit.Visible = false;
                btnLuu.Visible = false;
                DropDownNguoiDich.Enabled = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachPhieuChuaDuyetBiTraVeCB.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtTieuDe.Enabled = true;
            txtTieuDeTW.Enabled = true;
            txtAutoComplete.Enabled = true;
            txtdonvitinh.Enabled = true;
            txtGhiChu.Enabled = true;
            txtMaHang.Enabled = true;
            txtSize.Enabled = true;
            txtSoLuong.Enabled = true;
            txtPhanHoi.Enabled = true;
            btnEdit.Enabled = false;
            btnEdit.Attributes.CssStyle.Add("opacity", "0.5");
            btnLuu.Enabled = true;
            btnLuu.Attributes.CssStyle.Add("opacity", "100");

            btnGuiNguoiDich.Enabled = true;
            btnGuiNguoiDich.Attributes.CssStyle.Add("opacity", "100");
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string UserID = Session["user"].ToString();
            string congty = Session["congty"].ToString();
            string maphieu = Session["MaPhieu"].ToString();
            int YN = 4;
            try
            {
                if (txtPhanHoi.Text.Trim() != "")
                {
                    dalAbcon.CapNhatTraLoi(maphieu, congty, UserID, txtNguoiChoDuyetID.Text.Trim(), txtPhanHoi.Text.Trim());
                }

                dal.CapNhatPhieuCoYKienToiNguoiDuyet1(txtTieuDeTW.Text.Trim(), txtTieuDe.Text.Trim(), maphieu, UserID, congty, YN);

                dalAbcon.CapNhatTrangThaiCuaPhieuCoYKien(maphieu, congty, YN, txtNguoiChoDuyetID.Text.Trim());
            }
            catch
            {
                throw;
            }
            btnEdit.Enabled = true;
            btnEdit.Attributes.CssStyle.Add("opcity", "100");
            btnLuu.Enabled = false;
            btnLuu.Attributes.CssStyle.Add("opcity", "0.5");
            Response.Redirect("DanhSachPhieuChuaDuyetBiTraVeCB.aspx");
        }

        protected void btnGuiNguoiDich_Click(object sender, EventArgs e)
        {
            string UserID = Session["user"].ToString();
            string congty = Session["congty"].ToString();
            string maphieu = Session["MaPhieu"].ToString();
            int YN = 3;
            bool isPause = true;
            try
            {
                if (txtPhanHoi.Text.Trim() != "")
                {
                    dalAbcon.CapNhatTraLoi(maphieu, congty, UserID, txtNguoiChoDuyetID.Text.Trim(), txtPhanHoi.Text.Trim());
                }

                dal.CapNhatPhieuCoYKienToiNguoiDuyet2(txtTieuDeTW.Text.Trim(), txtTieuDe.Text.Trim(), maphieu, UserID, congty, txtMucDichSuDung.Text.Trim(), YN);

                dal.CapNhatNguoiDichNHungPhieuCoYKien(DropDownNguoiDich.SelectedValue, txtTieuDe.Text, txtTieuDeTW.Text, txtMucDichSuDung.Text, maphieu, congty, YN, isPause);
            }
            catch
            {
                throw;
            }
            btnEdit.Enabled = true;
            btnEdit.Attributes.CssStyle.Add("opcity", "100");
            btnLuu.Enabled = false;
            btnLuu.Attributes.CssStyle.Add("opcity", "0.5");
            Response.Redirect("DanhSachPhieuChuaDuyetBiTraVeCB.aspx");
        }
    }
}