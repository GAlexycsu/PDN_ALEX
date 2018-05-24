using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iOffice.DAO;
using iOffice.DTO;
using iOffice.BUS;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmEditNghiPhep : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(36,strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            if (!IsPostBack)
            {
                HienThiDropDown();
                string macongty = Session["macongty"].ToString();
               
                DateTime tungay =DateTime.Parse(Session["tungay"].ToString());
                DateTime denngay = DateTime.Parse(Session["denngay"].ToString());
                string manguoiduyet =  Session["manguoiduyet"].ToString();
                string manguoiduocuyquyen =  Session["manguoiduocuyquyen"].ToString();
                string makhivanmat = Session["makhivanmat"].ToString();
                txtTuNgay.Text = tungay.ToShortDateString();
                txtDenNgay.Text = denngay.ToShortDateString();
                txtNguoiDuyet.Text = manguoiduyet;
                txtNguoiDuocUyQuyen.Text = manguoiduocuyquyen;
                DropDownVangMat.SelectedValue = makhivanmat.ToString();
                DropCty.SelectedValue = macongty;
            }
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
        public override void GanNgonNguVaoConTrol()
        {
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Session["id"].ToString();
            string macongty = DropCty.SelectedValue.ToString();
            DateTime tungay = DateTime.Parse(txtTuNgay.Text.ToString());
            DateTime denngay = DateTime.Parse(txtDenNgay.Text.ToString());
            string ngonngu = Session["languege"].ToString();
            string manguoiduyet = txtNguoiDuyet.Text;
            string manguoiduocuyquyen = txtNguoiDuocUyQuyen.Text;
            int khivang = int.Parse(DropDownVangMat.SelectedValue.ToString());
            ABJobAgent nghiphep = new ABJobAgent();
            nghiphep.GSBH = macongty;
            nghiphep.ID = int.Parse(id);
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
                    nghiphep.tennguoiuyquyen = nguoiuyquyen.USERNAME;
                    nghiphep.tennguoithaythe = nguoithaythe.USERNAME;
                }


            }

            nghiphep.ThongQua = khivang;
            StatusCode thong = KhiVangMatDAO.TimMaThongQua(khivang);
            nghiphep.TenThongQua = thong.NameTaiwan;
            NghiPhepDAO.SuaDuLieu(nghiphep);
            Response.Redirect("frmNghiPhep.aspx");
        }
    }
}