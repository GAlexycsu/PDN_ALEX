using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class ChiTietPhieuHuyCB1 : LanguegeBus
    {
        dalPDN dal = new dalPDN();
        abconDAL dalAbcon = new abconDAL();
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
                TextBox1.Visible = false;
                btnLuu.Enabled = false;
                btnGuiNguoiDich.Enabled = false;
                btnLuu.Attributes.CssStyle.Add("opacity", "0.5");
                btnGuiNguoiDich.Attributes.CssStyle.Add("opacity", "0.5");
                CKEditorControl1.Enabled = false;
                CKEditorControl2.Enabled = false;
                txtTieuDeTW.Enabled = false;
                txtTieuDeVN.Enabled = false;
                DropDownNguoiDich.Enabled = false;
                HienThiThongTin();
                HienThiNguoiDich();
                txtPhanHoi.Enabled = false;
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
            DataTable dt = dal.LayThongTinPhieuCoYKien(UserID, congty, maphieu);
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
                txtNguoiChoDuyetID.Text = CFMID1;
                txtNguoiCoDUyet.Text = USERNAME;
                txtTieuDeTW.Text = pdnsubject;
                txtTieuDeVN.Text = mytitle;
                CKEditorControl1.Text = pdmemovn;
                CKEditorControl2.Text = NoiDungDich;
                lbLoaiPhieu.Text = abname;
                lbBoPhan.Text = DepName;
                txtDepartID.Text = IDDepart;
                lbSoPhieu.Text = maphieu;

                string thang = CFMDate0.Substring(3, 2);
                string ngay = CFMDate0.Substring(0, 2);
                string nam = CFMDate0.Substring(6, 4);
                lbNgay.Text = "Ngày 日  " + ngay + " Tháng 月 " + thang + " Năm 年 " + nam + "";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DanhSachPhieuChuaDuyetBiTraVe.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtTieuDeVN.Enabled = true;
            txtTieuDeTW.Enabled = true;
            txtPhanHoi.Enabled = true;
            CKEditorControl1.Enabled = true; CKEditorControl2.Enabled = true;
            btnEdit.Enabled = false;
           
            btnEdit.Attributes.CssStyle.Add("opacity", "0.5");
            btnLuu.Attributes.CssStyle.Add("opacity", "100");
            btnLuu.Enabled = true;
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

                dal.CapNhatPhieuCoYKienToiNguoiDuyet(txtTieuDeTW.Text.Trim(), txtTieuDeVN.Text.Trim(), CKEditorControl1.Text.Trim(), CKEditorControl2.Text.Trim(), maphieu, UserID, congty, YN);
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
            btnGuiNguoiDich.Enabled = true;
            btnGuiNguoiDich.Attributes.CssStyle.Add("opcity", "100");
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



                dal.CapNhatNguoiDichNHungPhieuCoYKien1(DropDownNguoiDich.SelectedValue, txtTieuDeVN.Text, txtTieuDeTW.Text, maphieu, congty, YN, isPause);
            }
            catch
            {
                throw;
            }
            btnEdit.Enabled = true;
            btnEdit.Attributes.CssStyle.Add("opcity", "100");
            btnLuu.Enabled = false;
            btnLuu.Attributes.CssStyle.Add("opcity", "0.5");
            Response.Redirect("DanhSachPhieuChuaDuyetBiTraVe.aspx");
        }
    }
}