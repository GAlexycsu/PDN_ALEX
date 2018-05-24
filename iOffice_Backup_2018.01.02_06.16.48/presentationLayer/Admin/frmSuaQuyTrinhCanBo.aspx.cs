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
    public partial class frmSuaQuyTrinhCanBo : LanguegeBus
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("~/presentationLayer/DangNhap.aspx");
                }
                string id = Session["id"].ToString();
                string macongty = Session["macongty"].ToString();
                string maloaiphieu = Session["maloaiphieu"].ToString();
                string madonvi = Session["madonvi"].ToString();
                string madonvithongqua = Session["madonvithongqua"].ToString();
                string manguoiduyet = Session["manguoiduyet"].ToString();
                string machucvu = Session["machucvu"].ToString();
                string macapduyet = Session["macapduyet"].ToString();
                string maloaidonvi = Session["maloaidonvi"].ToString();
                string buoduyet = Session["buocduyet"].ToString();
                if (!IsPostBack)
                {
                    txtNguoiDuyet.Text = manguoiduyet;
                    DropCty.SelectedValue = macongty;
                 
                    // DropDownDonViThongQua.SelectedValue = madonvithongqua;
                    DropDownLDonVi.SelectedValue = madonvi;
                    //DropDownLoaiDV.SelectedValue = maloaidonvi;
                    txtBucoDuyet.Text = buoduyet.ToString();

                    if (!IsPostBack)
                    {
                        if (maloaiphieu == "MD")
                        {
                            HienThiLoaiPhieu();
                            DropDownLoaiPhieu.SelectedValue = maloaiphieu;
                        }
                        else
                        {
                            HienThiLoaiPhieu();
                            DropDownLoaiPhieu.SelectedValue = maloaiphieu;
                        }
                       
                        HienThiDonViThongQua();

                       

                    }
                    DropDownDonViThongQua.Enabled = false;
                    LayngonNgu(35);
                    GanNgonNguVaoConTrol();
                }
            }
            catch (Exception)
            { throw; }
        }
        public override void GanNgonNguVaoConTrol()
        {
            cbLoaiPhieu.Text = hasLanguege["abtype"].ToString();
            CheckThongQuaDonVi.Text = hasLanguege["CheckThongQuaDonVi"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string macongty = DropCty.SelectedValue.ToString();

            string madonvi = DropDownLDonVi.SelectedValue.ToString();

            string manguoiduyet = txtNguoiDuyet.Text;

            int buocduyet = int.Parse(txtBucoDuyet.Text);

            BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
            AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(int.Parse(donvi.DepartmentTypeID.ToString()), macongty);
            QuyTrinhXetDuyetCuaCanBo quytrinh = new QuyTrinhXetDuyetCuaCanBo();
            //quytrinh.IDQuyTrinh = maquytrinh + (QuyTrinhXetDuyetDAO.DemQuyTrinhXetDuyet() + 1).ToString();
            quytrinh.BADEPID = madonvi;
            quytrinh.tendonviTW = donvi.DepName;
            quytrinh.GSBH = macongty;
            quytrinh.BuocDuyet = buocduyet;

            quytrinh.IDLoaiDonVi = loaidonvi.DepartmentTypeID;
            quytrinh.DepartmentTypeNameTW = loaidonvi.DepartmentTypeNameTW;
            if (cbLoaiPhieu.Checked == true)
            {
                quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                quytrinh.abtypenameTW = timloai.abnameTW;
            }
            else
            {
                quytrinh.abtype = "PDN1";
            }
            if (CheckThongQuaDonVi.Checked == true)
            {
                quytrinh.DonViThongQua = DropDownDonViThongQua.SelectedValue.ToString();
                BDepartment donvithongqua = BDepartmentDAO.TimMaDonVi(DropDownDonViThongQua.SelectedValue.ToString(), macongty);
                quytrinh.tendonvithongqua = donvithongqua.DepName;
            }
            else
            {
                quytrinh.DonViThongQua = null;
            }
            if (txtNguoiDuyet.Text.Trim() == "")
            {
                quytrinh.NguoiDuyet = "MD";
            }
            else
            {
                quytrinh.NguoiDuyet = manguoiduyet;
                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                quytrinh.USERNAME = nguoi.USERNAME;
                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                quytrinh.IDChucVu = chuc.IDChucVu;
                quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
            }
            QuyTrinhXetDuyetCuaCanBoDAO.SuaQuyTrinhXetDuyetTheoCanBo(quytrinh);
            Response.Redirect("FQuyTrinhXetDuyetDanhChoCanBo.aspx");
        }

        protected void CheckThongQuaDonVi_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckThongQuaDonVi.Checked == true)
            {
                DropDownDonViThongQua.Enabled = true;
            }
            else
            {
                DropDownDonViThongQua.Enabled = false;
            }
        }

    }
}