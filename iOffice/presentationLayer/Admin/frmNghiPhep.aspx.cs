using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.BUS;
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmNghiPhep : LanguegeBus
    {
        int STT = 1;
        quytrinhDal dal = new quytrinhDal();
        abconDAL dalABcon = new abconDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(36, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoGridView();
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                HienThiDropDown();
                txtFromDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
                txtToDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
                HienThiDanhSach();
            }
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        public override void GanNgonNguVaoGridView()
        {
            GridView1.Columns[1].HeaderText=hasLanguege["lbCty"].ToString();
            GridView1.Columns[2].HeaderText = hasLanguege["lblTuNgay"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["lblDenNgay"].ToString();
            GridView1.Columns[4].HeaderText = hasLanguege["lblNguoiDuyet"].ToString();
            GridView1.Columns[5].HeaderText = hasLanguege["lblTenNguoiUyQuyen"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["lblMaNguoiDuocUyQuyen"].ToString();
            GridView1.Columns[7].HeaderText = hasLanguege["lblTenNguoiDcUyQuyen"].ToString();
            //GridView1.Columns[8].HeaderText = hasLanguege[""].ToString();
            GridView1.Columns[9].HeaderText = hasLanguege["lblKhiVangMat"].ToString();
           
        }
        private void HienThiDropDown()
        {
            string ngonngu = Session["languege"].ToString();
            DropDownVangMat.DataSource = KhiVangMatDAO.Qry();
            DropDownVangMat.DataValueField = "ID";
            //DropDownVangMat.DataTextField = "NameVietNam";

            if (ngonngu == "lbl_VN")
            {
                DropDownVangMat.DataTextField = "NameVietNam";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownVangMat.DataTextField = "NameTaiwan";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownVangMat.DataTextField = "NameEnglish";
            }
            DropDownVangMat.DataBind();
        }
        private void HienThiDanhSach()
        {
            //string macongty=Session["congty"].ToString();
            string macongty="LTY";
            GridView1.DataSource = dal.KhiVangMat(macongty);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string macongty = DropCty.SelectedValue.ToString();
            DateTime tungay=DateTime.Parse(txtFromDate.Text.ToString());
            DateTime denngay=DateTime.Parse(txtToDate.Text.ToString());
            string ngonngu = Session["languege"].ToString();
            string manguoiduyet = txtNguoiDuyet.Text;
            string manguoiduocuyquyen = txtNguoiDuocUyQuyen.Text;
            int khivang = int.Parse(DropDownVangMat.SelectedValue.ToString());
            ABJobAgent nghiphep = new ABJobAgent();
            nghiphep.GSBH = macongty;
            nghiphep.TuNgay = tungay;
            nghiphep.DenNgay = denngay;
            if (txtNguoiDuyet.Text.Trim() == "" && txtNguoiDuocUyQuyen.Text.Trim() == "")
            {
                return;
            }
            else
            {
                Busers2 nguoiuyquyen = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                Busers2 nguoithaythe = UserDAO.TimNhanVienTheoMa(manguoiduocuyquyen, macongty);
                if (nguoiuyquyen == null && nguoithaythe == null)
                {
                    if (ngonngu == "lbl_VN")
                    {
                        lblThongBao.Text = "Mã người Ủy Quyền hoặc Mã Người Thay Thế không có trong hệ thống";
                    }
                    else if (ngonngu == "lbl_TW")
                    {
                        lblThongBao.Text = "系统没有这个委托人编号或者代理人编号";
                    }
                    else if (ngonngu == "lbl_EN")
                    {
                        lblThongBao.Text = "Mã người Ủy Quyền hoặc Mã Người Thay Thế không có trong hệ thống";
                    }
                }
                else
                {
                    nghiphep.IDNguoiDuyet = manguoiduyet;
                    nghiphep.IDNguoiDuocUyQuyen = manguoiduocuyquyen;
                    nghiphep.tennguoiuyquyen=nguoiuyquyen.USERNAME;
                    nghiphep.tennguoithaythe=nguoithaythe.USERNAME;
                }
                
                
            }
           
            nghiphep.ThongQua = khivang;
            nghiphep.TenThongQua = DropDownVangMat.SelectedItem.Text;
            NghiPhepDAO.ThemDuLieu(nghiphep);
            //List<Abcon> danhsach = AbconDAO.DanhSachPhieuChoDuyetTheoNguoiDuyet(macongty, manguoiduyet);
            DataTable danhsach = dalABcon.DanhSachPhieuTheoNguoiDuyet(macongty, manguoiduyet);
            if (danhsach.Rows.Count > 0)
            {
                foreach (DataRow phieu in danhsach.Rows)
                {
                    string pdno = phieu["pdno"].ToString();
                    int IDCT = int.Parse(phieu["IDCT"].ToString());
                    dalABcon.CapNhatUyQuyenAbcon(macongty, manguoiduocuyquyen, pdno, IDCT);
                }
            }
            HienThiDanhSach();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblID = (Label)row.FindControl("lblID");
            int id = int.Parse(lblID.Text.Trim());
            Session["id"] = id;
            Label lblMaCT = (Label)row.FindControl("lblGSBH");
            string macongty = lblMaCT.Text;
            Session["macongty"] = macongty;
             DateTime tungay=DateTime.Parse(row.Cells[2].Text);
             DateTime denngay = DateTime.Parse(row.Cells[3].Text);
             string manguoiduyet = row.Cells[4].Text;
             string manguoiduocuyquyen = row.Cells[6].Text;
             string makhivanmat = row.Cells[8].Text;
             Session["tungay"] = tungay;
             Session["denngay"] = denngay;
             Session["manguoiduyet"] = manguoiduyet;
             Session["manguoiduocuyquyen"] = manguoiduocuyquyen;
             Session["makhivanmat"] = makhivanmat;
             Response.Redirect("frmEditNghiPhep.aspx");

             
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }

       
        protected void btnBack_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime pTuNgay;
            DateTime pDenNgay;
            string GSBH = DropCty.SelectedValue.ToString();
            if (txtFromDate.Text.Trim() == "" || txtToDate.Text.Trim() == "")
            {
                pTuNgay = DateTime.Today;
                pDenNgay = DateTime.Today;
                HienThiDanhSach();
            }
            else
            {
                pTuNgay = DateTime.Parse(txtFromDate.Text.Trim());
                pDenNgay = DateTime.Parse(txtToDate.Text.Trim());
                GridView1.DataSource = dal.TimKiemKhiVangMat(GSBH, pTuNgay, pDenNgay);
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblID");
            int id = int.Parse(lblID.Text.Trim());

            dal.XoaNguoiUyQuyen(id);
            HienThiDanhSach();
        }

        
    }
}