using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.ApproveUser
{
    public partial class chinhsuaphieu : LanguegeBus
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
                    LayngonNgu(2, strNgonngu);
                }
                else
                {
                    Response.Redirect("http://portal.footgear.com.vn");
                }
                GanNgonNguVaoConTrol();
                string macongty = Session["congty"].ToString();
                string idphieu = Session["maphieu"].ToString();
                //string bophan = Session["bophan"].ToString();
                string manguoidung = Session["user"].ToString();
                DataTable dt = dal.TimPhieuTheoMaNguoiTao(idphieu, macongty, manguoidung);
                if (dt.Rows.Count>0)
                {
                    string madonvi = dt.Rows[0]["pddepid"].ToString();
                    string maloaiphieu = dt.Rows[0]["Abtype"].ToString();
                    string tentieude = dt.Rows[0]["mytitle"].ToString();
                    BDepartment timdonvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                    abill loaiphieu = abillBUS.SearchAbillByID(maloaiphieu);
                    string tenloaiphieuVN = loaiphieu.abname;
                    string tenloaiphieuTW = loaiphieu.abnameTW;
                    txtTieuDe.Text = tentieude;
                    lbLoaiPhieu.Text = tenloaiphieuVN + " " + tenloaiphieuTW;
                    lbBoPhan.Text = timdonvi.DepName;
                    lbSoPhieu.Text = idphieu;
                    CKEditorControl1.Text = dt.Rows[0]["pdmemovn"].ToString();
                }
            }
        }
        public override void GanNgonNguVaoConTrol()
        {
            btnLuu.Text = hasLanguege["btnLuu"].ToString();
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string idphieu = Session["maphieu"].ToString();
            string noidung = CKEditorControl1.Text.ToString();
            db.ExecuteCommand("update pdna set pdmemovn=N'" + CKEditorControl1.Text.ToString() + "',mytitle=N'" + txtTieuDe.Text.Trim() + "',CFMDate0=GETDATE()  where pdno='" + idphieu + "'and  GSBH='" + macongty + "'");
            // db.SuaPhieuDeNghiTT(macongty, idphieu, noidung);
            Response.Redirect("FrmViewCB.aspx");
        }

        protected void btnCalcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmViewCB.aspx");
        }
    }
}