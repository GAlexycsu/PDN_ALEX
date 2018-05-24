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
    public partial class fSuaQuyTrinhCuaCanBo : LanguegeBus
    {
        int buoc = 0;
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
                    DropDownLoaiDV.SelectedValue = maloaidonvi;
                  

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
                        
                        HienThiDonVi();
                        HienThiDonViThongQua();

                        HienThiDropLoaiDonVi();

                    }
                    DropDownDonViThongQua.Enabled = false;
                    LayngonNgu(35);
                    //GanNgonNguVaoConTrol();
                }
            }
            catch(Exception)
            { throw; }
        }

        public override void GanNgonNguVaoConTrol()
        {
            cbLoaiPhieu.Text = hasLanguege["abtype"].ToString();
            CheckThongQuaDonVi.Text = hasLanguege["CheckThongQuaDonVi"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
        }

        public void HienThiDropLoaiDonVi()
        {
            string macongty = Session["congty"].ToString();
            string ngonngu = Session["languege"].ToString();
            //  string macongty = "LTY";
            DropDownLoaiDV.DataSource = LoaiDonViDAO.LayDanhSachLoaiDonVi(macongty);
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

            string manguoiduyet1 = Session["manguoiduyet"].ToString();
            int id = int.Parse(Session["id"].ToString());
            string macongty = DropCty.SelectedValue.ToString();

            string madonvi = DropDownLDonVi.SelectedValue.ToString();

            string manguoiduyet = txtNguoiDuyet.Text;

            // int buocduyet = int.Parse(txtBucoDuyet.Text);

            BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
            AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(int.Parse(donvi.DepartmentTypeID.ToString()), macongty);
            QuyTrinhXetDuyetCuaCanBo quytrinh = new QuyTrinhXetDuyetCuaCanBo();
            //quytrinh.IDQuyTrinh = maquytrinh + (QuyTrinhXetDuyetDAO.DemQuyTrinhXetDuyet() + 1).ToString();
            quytrinh.BADEPID = madonvi;
            quytrinh.IDQuyTrinh = id;
            quytrinh.tendonviTW = donvi.DepName;
            quytrinh.GSBH = macongty;
            //quytrinh.BuocDuyet = buocduyet;

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
                quytrinh.tendonvithongqua = chuc.TenChucVuTiengHoa;
                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;

            }
            List<QuyTrinhXetDuyetCuaCanBo> ListQT1 = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoCapDuyet(quytrinh.BADEPID, quytrinh.GSBH, quytrinh.abtype);
            int max1 = (from ct1 in ListQT1
                        select int.Parse(ct1.BuocDuyet.ToString())).Max();
            quytrinh.BuocDuyet = max1 + 1;
            QuyTrinhXetDuyetCuaCanBoDAO.SuaQuyTrinhXetDuyetTheoCanBo(quytrinh);

            QuyTrinhXetDuyetCuaCanBo timquynguoi = QuyTrinhXetDuyetCuaCanBoDAO.TimNguoiTrongQuyTrinh(quytrinh.NguoiDuyet, quytrinh.abtype, quytrinh.BADEPID, quytrinh.GSBH);
            Busers2 timnguoiduyettrong = UserDAO.TimNhanVienTheoMa(quytrinh.NguoiDuyet, quytrinh.GSBH);

            if (timquynguoi != null)
            {

                List<QuyTrinhXetDuyetCuaCanBo> ListQT = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoCapDuyet(quytrinh.BADEPID, quytrinh.GSBH, quytrinh.abtype);
                int min = (from ct1 in ListQT
                           select int.Parse(ct1.BuocDuyet.ToString())).Min();
                int min1 = (from ct1 in ListQT
                            select int.Parse(ct1.IDCapDuyet.ToString())).Min();
                foreach (QuyTrinhXetDuyetCuaCanBo qt in ListQT)
                {
                    QuyTrinhXetDuyetCuaCanBo laynguoidautien = QuyTrinhXetDuyetCuaCanBoDAO.TimCapTiepTheoTrongQuyTrinh1(qt.BADEPID, qt.GSBH, qt.abtype, min1);
                    if (qt.NguoiDuyet == laynguoidautien.NguoiDuyet)
                    {
                        QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                        quy.BuocDuyet = 1;
                        quy.IDQuyTrinh = qt.IDQuyTrinh;
                        buoc = 1;
                        QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                    }
                    else
                    {
                        QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                        quy.BuocDuyet = buoc + 1;
                        quy.IDQuyTrinh = qt.IDQuyTrinh;
                        buoc = int.Parse(quy.BuocDuyet.ToString());
                        QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                    }
                }

            }
            List<Abcon> LayDanhSach = AbconDAO.LayDanhSachVanBanChuaDuyetTheoNguoiDuyet(madonvi, quytrinh.abtype, macongty, manguoiduyet1);
            if (manguoiduyet1 == manguoiduyet)
            { }
            else
            {
                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                foreach (Abcon ct in LayDanhSach)
                {
                    //Abcon tim = AbconDAO.TimNguoiDuyetTrongPhieu(madonvi, macongty, quytrinh.abtype, ct.pdno, manguoiduyet);
                    //int buockietiep=ct.abde+1
                    //Abcon kiemtra = AbconDAO.TimBuocKyTruocTrongPhieu(ct.from_depart, ct.Gsbh, ct.abtype, ct.pdno, buocketiep);
                    Abcon chitiet = new Abcon();
                    chitiet.IDCT = ct.IDCT;
                    chitiet.Auditor = manguoiduyet;
                    chitiet.Gsbh = ct.Gsbh;
                    chitiet.pdno = ct.pdno;
                    chitiet.abmomo = ct.abmomo;
                    chitiet.abtype = ct.abtype;
                    chitiet.abrult = false;
                    chitiet.abde = ct.abde;
                    chitiet.ABC = ct.ABC;
                    chitiet.bixoa = false;
                    chitiet.boqua = false;
                    chitiet.cothutu = true;
                    chitiet.from_depart = ct.from_depart;
                    chitiet.from_user = ct.from_user;
                    chitiet.Id_VB_CD = ct.Id_VB_CD;
                    chitiet.Maintitle = ct.Maintitle;
                    chitiet.Yn = 4;
                    chitiet.IDCapDuyet = nguoi.IDCapDuyet;
                    AbconDAO.SuaChiTietXD1(chitiet, true);
                }
            }
            Response.Redirect("FQuyTrinhXetDuyet.aspx");
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