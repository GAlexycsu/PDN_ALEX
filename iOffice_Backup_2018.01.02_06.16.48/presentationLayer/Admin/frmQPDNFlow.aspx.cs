using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using iOffice.BUS;
using iOffice.DTO;
using iOffice.DAO;
using iOffice.Share;
namespace iOffice.presentationLayer.Admin
{
    public partial class frmQPDNFlow:LanguegeBus
    {

        
        static iOfficeDataContext db = new iOfficeDataContext();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiChucVu();
                HienThiDonVi();
                HienThiDonViThongQua();
                HienThiLoaiPhieu();
                HienThiDropLoaiDonVi();
              
            }
            string strNgonngu = (string)Session["languege"];
            if (strNgonngu != null)
            {
                LayngonNgu(35, strNgonngu);
            }
            else
            {
                Response.Redirect("http://portal.footgear.com.vn");
            }
            GanNgonNguVaoConTrol();
            GanNgonNguVaoGridView();
            HienThiDanhSach();
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            cbLoaiPhieu.Text = hasLanguege["abtype"].ToString();
            CheckThongQuaDonVi.Text = hasLanguege["CheckThongQuaDonVi"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        public override void GanNgonNguVaoGridView()
        {
            //GridView1.Columns[0].HeaderText = hasLanguege["IDQuyTrinh"].ToString();
            GridView1.Columns[1].HeaderText = hasLanguege["GSBH"].ToString();
            GridView1.Columns[2].HeaderText = hasLanguege["abtype"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["lbDonVi"].ToString();
            GridView1.Columns[4].HeaderText = hasLanguege["DonViThongQua"].ToString();
            GridView1.Columns[5].HeaderText = hasLanguege["lbNguoiDuyet"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["lbChucVu"].ToString();
            GridView1.Columns[7].HeaderText = hasLanguege["IDCapDuyet"].ToString();
           
        }
        public void HienThiDropLoaiDonVi()
        {
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
          //  string macongty = "LTY";
            DropDownLoaiDV.DataSource = LoaiDonViDAO.QryLoaiDonVi(macongty);
            DropDownLoaiDV.DataValueField = "DepartmentTypeID";
            DropDownLoaiDV.DataTextField = "DepartmentTypeName";
            if (ngonngu == "lbl_VN")
            {
                DropDownLoaiDV.DataTextField = "DepartmentTypeName";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownLoaiDV.DataTextField = "DepartmentTypeNameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownLoaiDV.DataTextField = "DepartmentTypeName";
            }
            DropDownLoaiDV.DataBind();
        }
       
        private void HienThiChucVu()
        {
            string ngonngu = Session["languege"].ToString();
            DropDownChucVu.DataSource = ChucVuBUS.Qrychucvu();
            DropDownChucVu.DataValueField = "IDChucVu";
            if (ngonngu == "lbl_VN")
            {
                DropDownChucVu.DataTextField = "TenChucVu";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownChucVu.DataTextField = "TenChucVuTiengHoa";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownChucVu.DataTextField = "TenChucVu";
            }
           
            DropDownChucVu.DataBind();
        }

        private void HienThiDonVi()
        {
            DropDownLDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan();
            DropDownLDonVi.DataValueField = "ID";
            DropDownLDonVi.DataTextField = "DepName";
            DropDownLDonVi.DataBind();
        }
        private void HienThiDonViThongQua()
        {
            DropDownDonViThongQua.DataSource = BDepartmentBUS.DanhSachBoPhan();
            DropDownDonViThongQua.DataValueField = "ID";
            DropDownDonViThongQua.DataTextField = "DepName";
            DropDownDonViThongQua.DataBind();
        }
        private void HienThiLoaiPhieu()
        {
            string ngonngu = Session["languege"].ToString();
            DropDownLoaiPhieu.DataSource = abillBUS.ListBill();
            DropDownLoaiPhieu.DataValueField = "abtype";
           
            if (ngonngu == "lbl_VN")
            {
                DropDownLoaiPhieu.DataTextField = "abname";
            }
            else if (ngonngu == "lbl_TW")
            {
                DropDownLoaiPhieu.DataTextField = "abnameTW";
            }
            else if (ngonngu == "lbl_EN")
            {
                DropDownLoaiPhieu.DataTextField = "abname";
            }
            DropDownLoaiPhieu.DataBind();
        }
        private void HienThiDanhSach()
        {
            string macongty=Session["congty"].ToString();
           // string macongty="LTY";
            GridView1.DataSource = db.QryQPDNFlow(macongty);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            string macongty = DropCty.SelectedValue.ToString();
          
            string madonvi = DropDownLDonVi.SelectedValue.ToString();
           
            string manguoiduyet = txtNguoiDuyet.Text;
            string chucvu = DropDownChucVu.SelectedValue.ToString();
            ChucVu chuc = ChucVuDAO.TimMaChucVu(chucvu, macongty);
            QPDNFlow quytrinh = new QPDNFlow();
            //quytrinh.IDQuyTrinh = maquytrinh + (QPDNFlowDAO.DemQPDNFlow() + 1).ToString();
            quytrinh.BADEPID = madonvi;
          
            quytrinh.GSBH = macongty;
           
            quytrinh.IDChucVu = DropDownChucVu.SelectedValue.ToString();
            quytrinh.IDCapDuyet = chuc.IDCapDuyet;
            quytrinh.IDLoaiDonVi = int.Parse(DropDownLoaiDV.SelectedValue.ToString());
            if (cbLoaiPhieu.Checked == true)
            {
               quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();

            }
            else
            {
                quytrinh.abtype = "MD";
            }
            if (CheckThongQuaDonVi.Checked == true)
            {
                quytrinh.DonViThongQua = DropDownDonViThongQua.SelectedValue.ToString();
            }
            else
            {
                quytrinh.DonViThongQua = null;
            }
            if (txtNguoiDuyet.Text.Trim() == null)
            {
                quytrinh.NguoiDuyet = "MD";
            }
            else
            {
                quytrinh.NguoiDuyet = manguoiduyet;
            }
            QPDNFlowDAO.ThemQuyTrinh(quytrinh);
            HienThiDanhSach();
        }
    }
}