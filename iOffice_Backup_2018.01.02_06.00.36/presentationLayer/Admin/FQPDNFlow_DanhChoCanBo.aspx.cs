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
    public partial class FQuyTrinhXetDuyetDanhChoCanBo : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        int dem = 0;
        int capduyet = 0;
        int buoc = 0;
        int STT = 1;
        int buocthemvao;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
            }
            LayngonNgu(35);
            GanNgonNguVaoConTrol();
            GanNgonNguVaoGridView();
            if (!IsPostBack)
            {
              
                HienThiDonVi();
                HienThiDonViThongQua();
                HienThiLoaiPhieu();
                HienThiDanhSach();
                DropDownLDonVi.Items.Insert(0, " ");
                DropDownLoaiPhieu.Items.Insert(0, " ");
                btnBack.Visible = false;
                btnQuery.Visible = false;
            }
            DropDownDonViThongQua.Enabled = false;
           
           
            
        }
        public override void GanNgonNguVaoConTrol()
        {
            
            CheckThongQuaDonVi.Text = hasLanguege["CheckThongQuaDonVi"].ToString();
            Button1.Text = hasLanguege["Button1"].ToString();
        }
        public override void GanNgonNguVaoGridView()
        {
            //GridView1.Columns[0].HeaderText = hasLanguege["IDQuyTrinh"].ToString();
            GridView1.Columns[3].HeaderText = hasLanguege["GSBH"].ToString();
            GridView1.Columns[4].HeaderText = hasLanguege["abtype"].ToString();
            GridView1.Columns[5].HeaderText = hasLanguege["abtypenameTW"].ToString();
            GridView1.Columns[6].HeaderText = hasLanguege["BADEPID"].ToString();
            GridView1.Columns[7].HeaderText = hasLanguege["tendonviTW"].ToString();
            GridView1.Columns[8].HeaderText = hasLanguege["BADEPID"].ToString();
            GridView1.Columns[9].HeaderText = hasLanguege["tendonvithongqua"].ToString();
            GridView1.Columns[10].HeaderText = hasLanguege["lblBuocDuyet"].ToString();
            GridView1.Columns[11].HeaderText = hasLanguege["NguoiDuyet"].ToString();
            GridView1.Columns[12].HeaderText = hasLanguege["USERNAME"].ToString();
            GridView1.Columns[13].HeaderText = hasLanguege["IDChucVu"].ToString();
            GridView1.Columns[14].HeaderText = hasLanguege["TenChucVuTiengHoa"].ToString();
            GridView1.Columns[15].HeaderText = hasLanguege["IDCapDuyet"].ToString();
            GridView1.Columns[16].HeaderText = hasLanguege["IDLoaiDonVi"].ToString();
            GridView1.Columns[17].HeaderText = hasLanguege["DepartmentTypeNameTW"].ToString();
           

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
            string macongty = Session["congty"].ToString();
            // string macongty="LTY";
            GridView1.DataSource = db.LayDanhSachQuyTrinhXetDuyetCuaCanBo(macongty);
            GridView1.DataBind();
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
            //quytrinh.BuocDuyet = buocduyet;

            quytrinh.IDLoaiDonVi = loaidonvi.DepartmentTypeID;
            quytrinh.DepartmentTypeNameTW = loaidonvi.DepartmentTypeNameTW;
           
                if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                {
                    quytrinh.abtype = "PDN1";
                    abill timloai = abillBUS.SearchAbillByID(quytrinh.abtype);
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }
                else
                {
                    quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                    abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                    quytrinh.abtypenameTW = timloai.abnameTW;
                }

           
            if (CheckThongQuaDonVi.Checked == true)
            {
                quytrinh.DonViThongQua = DropDownDonViThongQua.SelectedValue.ToString();
                BDepartment donvithongqua = BDepartmentDAO.TimMaDonVi(DropDownDonViThongQua.SelectedValue.ToString(), macongty);
                quytrinh.tendonvithongqua = donvithongqua.DepName;
                Busers2 timnguoi = UserDAO.TimMaNhanVienTheoBoPhan(txtNguoiDuyet.Text, donvithongqua.ID,macongty);
                if (timnguoi == null)
                {
                    quytrinh.NguoiDuyet = null;

                }
                else
                {
                    quytrinh.NguoiDuyet = txtNguoiDuyet.Text;
                    quytrinh.USERNAME = timnguoi.USERNAME;
                    ChucVu chuc = ChucVuDAO.TimMaChucVu(timnguoi.IDChucVu, macongty);
                    quytrinh.IDChucVu = chuc.IDChucVu;
                    quytrinh.tendonvithongqua = chuc.TenChucVuTiengHoa;
                    quytrinh.IDCapDuyet = timnguoi.IDCapDuyet;
                }
            }
            else
            {
                quytrinh.DonViThongQua = null;
                quytrinh.NguoiDuyet = txtNguoiDuyet.Text;
                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                quytrinh.USERNAME = nguoi.USERNAME;
                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                quytrinh.IDChucVu = chuc.IDChucVu;
                quytrinh.tendonvithongqua = chuc.TenChucVuTiengHoa;
                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
            }
            
            #region ThemQuyTrinh
            List<QuyTrinhXetDuyetCuaCanBo> ListQT1 = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoCapDuyet(quytrinh.BADEPID, quytrinh.GSBH, quytrinh.abtype);
            int max1 = (from ct1 in ListQT1
                        select int.Parse(ct1.BuocDuyet.ToString())).Max();
            quytrinh.BuocDuyet = max1 + 1;


            QuyTrinhXetDuyetCuaCanBo timquynguoi = QuyTrinhXetDuyetCuaCanBoDAO.TimNguoiTrongQuyTrinh(quytrinh.NguoiDuyet, quytrinh.abtype, quytrinh.BADEPID, quytrinh.GSBH);
            Busers2 timnguoiduyettrong = UserDAO.TimNhanVienTheoMa(quytrinh.NguoiDuyet, quytrinh.GSBH);

            if (timquynguoi == null && quytrinh.NguoiDuyet!=null)
            {
                QuyTrinhXetDuyetCuaCanBoDAO.ThemQuyTrinhXetDuyetCuaCanBo(quytrinh);// them quy trinh
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
                        capduyet = int.Parse(qt.IDCapDuyet.ToString());
                        QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                    }
                    else
                    {
                        //QuyTrinhXetDuyet laybuoc= QuyTrinhXetDuyetDAO.TimBuocTiepTheoTrongQuyTrinh1(qt.BADEPID, qt.GSBH, qt.abtype, int.Parse(qt.BuocDuyet.ToString()));
                        if (qt.DonViThongQua == null && capduyet == qt.IDCapDuyet)
                        {
                            QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                            quy.BuocDuyet = buoc;
                            quy.IDQuyTrinh = qt.IDQuyTrinh;

                            buoc = int.Parse(quy.BuocDuyet.ToString());
                            capduyet = int.Parse(qt.IDCapDuyet.ToString());
                            QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                        }
                        else
                        {
                            QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                            quy.BuocDuyet = buoc + 1;
                            quy.IDQuyTrinh = qt.IDQuyTrinh;

                            buoc = int.Parse(quy.BuocDuyet.ToString());
                            capduyet = int.Parse(qt.IDCapDuyet.ToString());
                            QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                        }
                    }
                }

            }
            #endregion
            ///////////////////////////////////// code by Mr Tuan 
            QuyTrinhXetDuyetCuaCanBo timng = QuyTrinhXetDuyetCuaCanBoDAO.TimNguoiTrongQuyTrinh(manguoiduyet, quytrinh.abtype, madonvi, macongty);
            List<Abcon> list = AbconDAO.LayDanhSachPhieuTaiCapDuyetChuaDuyet(madonvi, quytrinh.abtype, macongty, int.Parse(timng.BuocDuyet.ToString()));
            foreach (Abcon l in list)
            {
                buocthemvao = l.abde;
                if (l.IDCapDuyet > timng.IDCapDuyet)
                {
                    List<Abcon> danh = AbconDAO.LayDanhSachPhieuTaiCapDuyetChuaDuyet1(l.from_depart, l.abtype, l.Gsbh,l.pdno, int.Parse(timng.BuocDuyet.ToString()));
                    foreach (Abcon aa in danh)
                    {
                        if (timng.BuocDuyet == aa.Abstep && timng.DonViThongQua == null && timng.IDCapDuyet == aa.IDCapDuyet)
                        {
                            Abcon aabcc = new Abcon();
                            aabcc.abtype = aa.abtype;
                            aabcc.pdno = aa.pdno;
                            aabcc.Gsbh = aa.Gsbh;
                            aabcc.IDCT = aa.IDCT;
                            aabcc.Abstep = aa.Abstep;
                            aabcc.abde = aa.abde + 1;
                            AbconDAO.CapNhatPhieuChuyen(aabcc);
                        }
                        else
                        {
                            Abcon aabcc = new Abcon();
                            aabcc.abtype = aa.abtype;
                            aabcc.pdno = aa.pdno;
                            aabcc.Gsbh = aa.Gsbh;
                            aabcc.IDCT = aa.IDCT;
                            aabcc.Abstep = aa.Abstep + 1;
                            aabcc.abde = aa.abde + 1;
                            AbconDAO.CapNhatPhieuChuyen(aabcc);
                        }
                    }
                }
                else
                {
                    if (l.IDCapDuyet == timng.IDCapDuyet && l.Abstep == timng.BuocDuyet)
                    {
                        List<Abcon> danh = AbconDAO.LayDanhSachPhieuTaiCapDuyetChuaDuyet1(l.from_depart, l.abtype, l.Gsbh,l.pdno, int.Parse(timng.BuocDuyet.ToString()));
                        foreach (Abcon aa in danh)
                        {
                            if (timng.BuocDuyet == aa.Abstep && timng.DonViThongQua == null && timng.IDCapDuyet == aa.IDCapDuyet)
                            {
                                Abcon aabcc = new Abcon();
                                aabcc.abtype = aa.abtype;
                                aabcc.pdno = aa.pdno;
                                aabcc.Gsbh = aa.Gsbh;
                                aabcc.IDCT = aa.IDCT;
                                aabcc.Abstep = aa.Abstep;
                                aabcc.abde = aa.abde + 1;
                                AbconDAO.CapNhatPhieuChuyen(aabcc);
                            }
                            else
                            {
                                Abcon aabcc = new Abcon();
                                aabcc.abtype = aa.abtype;
                                aabcc.pdno = aa.pdno;
                                aabcc.Gsbh = aa.Gsbh;
                                aabcc.IDCT = aa.IDCT;
                                aabcc.Abstep = aa.Abstep + 1;
                                aabcc.abde = aa.abde + 1;
                                AbconDAO.CapNhatPhieuChuyen(aabcc);
                            }
                        }
                    }
                    else
                    {
                        List<Abcon> danh = AbconDAO.LayDanhSachPhieuTaiCapDuyetChuaDuyet1(l.from_depart, l.abtype, l.Gsbh,l.pdno, int.Parse(timng.BuocDuyet.ToString()));
                        foreach (Abcon aa in danh)
                        {
                            if (timng.BuocDuyet == aa.Abstep && timng.DonViThongQua == null && timng.IDCapDuyet == aa.IDCapDuyet)
                            {
                                Abcon aabcc = new Abcon();
                                aabcc.abtype = aa.abtype;
                                aabcc.pdno = aa.pdno;
                                aabcc.Gsbh = aa.Gsbh;
                                aabcc.IDCT = aa.IDCT;
                                aabcc.Abstep = aa.Abstep;
                                aabcc.abde = aa.abde + 1;
                                AbconDAO.CapNhatPhieuChuyen(aabcc);
                            }
                            else
                            {
                                Abcon aabcc = new Abcon();
                                aabcc.abtype = aa.abtype;
                                aabcc.pdno = aa.pdno;
                                aabcc.Gsbh = aa.Gsbh;
                                aabcc.IDCT = aa.IDCT;
                                aabcc.Abstep = aa.Abstep + 1;
                                aabcc.abde = aa.abde + 1;
                                AbconDAO.CapNhatPhieuChuyen(aabcc);
                            }
                        }
                    }
                }
                //them phieu
                //kiemtamaphieu = l.pdno;
                Abcon abco = new Abcon();

                abco.ABC = l.ABC;
                abco.abde = buocthemvao;
                abco.ABJOB = l.ABJOB;
                abco.abmomo = l.abmomo;
                abco.Abstep = int.Parse(timng.BuocDuyet.ToString());
                abco.abrult = false;
                abco.abtype = l.abtype;
                abco.Auditor = timng.NguoiDuyet;
                abco.bixoa = false;
                abco.boqua = false;
                abco.cothutu = true;
                abco.from_depart = l.from_depart;
                abco.from_user = l.from_user;
                abco.Gsbh = l.Gsbh;
                abco.Id_VB_CD = l.Id_VB_CD;
                abco.IDCapDuyet = timng.IDCapDuyet;
                abco.IDChiTiet = l.IDChiTiet;

                abco.kytoanbo = true;
                abco.lydokhongduyet = l.lydokhongduyet;
                abco.Maintitle = l.Maintitle;
                abco.ncancel = 0;
                abco.Nhom = l.Nhom;
                abco.Password2 = null;
                abco.pdno = l.pdno;
                abco.received = l.received;
                abco.signatue = null;
                abco.Userdate = l.Userdate;
                abco.Yn = 4;
                AbconBUS.ThemChiTiet(abco);
            }
            HienThiDanhSach();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;

            string id = row.Cells[2].Text;
            string macongty = row.Cells[3].Text;
            string maloaiphieu = row.Cells[4].Text;
            string madonvi = row.Cells[6].Text;
            string madonvithongqua = row.Cells[8].Text;
            string manguoiduyet = row.Cells[11].Text;
            string machucvu = row.Cells[13].Text;
            string macapduyet = row.Cells[15].Text;
            string maloaidonvi = row.Cells[16].Text;
            string buoduyet = row.Cells[10].Text;

            
            Session["id"] = id;
            Session["macongty"] = macongty;
            Session["maloaiphieu"] = maloaiphieu;
            Session["madonvi"] = madonvi;
            Session["madonvithongqua"] = madonvithongqua;
            Session["manguoiduyet"] = manguoiduyet;
            Session["machucvu"] = machucvu;
            Session["macapduyet"] = macapduyet;
            Session["maloaidonvi"] = maloaidonvi;
            Session["buocduyet"] = buoduyet;
            Response.Redirect("frmSuaQuyTrinhCanBo.aspx");
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

        protected void cbLoaiPhieu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string macongty = DropCty.SelectedValue.ToString();

            string madonvi = DropDownLDonVi.SelectedValue.ToString();
            //GridView1.DataSource = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoBoPhan(madonvi, macongty);
            GridView1.DataSource = db.LayQuyTrinhTheoDonViCanBo(madonvi, macongty);
            GridView1.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            // string macongty="LTY";
            GridView1.DataSource = db.LayDanhSachQuyTrinhXetDuyetCuaCanBo(macongty);
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idquytrinh = int.Parse(GridView1.Rows[e.RowIndex].Cells[2].Text);
            //QuyTrinhXetDuyet quytrinh = QuyTrinhXetDuyetDAO.TimMaQuytrinh(idquytrinh);
            string macongty = GridView1.Rows[e.RowIndex].Cells[3].Text;
            string maloaiphieu = GridView1.Rows[e.RowIndex].Cells[4].Text;
            string madonvi = GridView1.Rows[e.RowIndex].Cells[6].Text;
            string madonvithongqua = GridView1.Rows[e.RowIndex].Cells[8].Text;
            string manguoiduyet = GridView1.Rows[e.RowIndex].Cells[11].Text;
            string machucvu = GridView1.Rows[e.RowIndex].Cells[13].Text;
            string macapduyet = GridView1.Rows[e.RowIndex].Cells[15].Text;
            string maloaidonvi = GridView1.Rows[e.RowIndex].Cells[16].Text;
            string buoduyet = GridView1.Rows[e.RowIndex].Cells[10].Text;
            QuyTrinhXetDuyetCuaCanBoDAO.XoaQuyTrinhXetDuyetTheoCanBo(idquytrinh);

            List<QuyTrinhXetDuyetCuaCanBo> ListQT = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoCapDuyet(madonvi, macongty, maloaiphieu);
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
                    capduyet = int.Parse(qt.IDCapDuyet.ToString());
                    QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                }
                else
                {
                    //QuyTrinhXetDuyet laybuoc= QuyTrinhXetDuyetDAO.TimBuocTiepTheoTrongQuyTrinh1(qt.BADEPID, qt.GSBH, qt.abtype, int.Parse(qt.BuocDuyet.ToString()));
                    if (qt.DonViThongQua == null && capduyet == qt.IDCapDuyet)
                    {
                        QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                        quy.BuocDuyet = buoc;
                        quy.IDQuyTrinh = qt.IDQuyTrinh;

                        buoc = int.Parse(quy.BuocDuyet.ToString());
                        capduyet = int.Parse(qt.IDCapDuyet.ToString());
                        QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                    }
                    else
                    {
                        QuyTrinhXetDuyetCuaCanBo quy = new QuyTrinhXetDuyetCuaCanBo();
                        quy.BuocDuyet = buoc + 1;
                        quy.IDQuyTrinh = qt.IDQuyTrinh;

                        buoc = int.Parse(quy.BuocDuyet.ToString());
                        capduyet = int.Parse(qt.IDCapDuyet.ToString());
                        QuyTrinhXetDuyetCuaCanBoDAO.CapNhatQuyTrinh(quy);
                    }
                }
            }
           

            HienThiDanhSach();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            string maloaiphieu = DropDownLoaiPhieu.SelectedValue.ToString();
            if (DropDownLoaiPhieu.SelectedValue.ToString() == " ")
            {
                if (DropDownLDonVi.SelectedValue.ToString() == " ")
                {
                    GridView1.DataSource = db.LayDanhSachQuyTrinhXetDuyetCuaCanBo(macongty);
                    GridView1.DataBind();
                }
                else
                {
                    if (DropDownLDonVi.SelectedValue.ToString().Trim() != "")
                    {
                        string madonvi = DropDownLDonVi.SelectedValue.ToString();
                        //GridView1.DataSource = QuyTrinhXetDuyetCuaCanBoDAO.LayDanhSachQuyTrinhTheoBoPhan(madonvi, macongty);
                        GridView1.DataSource = db.LayQuyTrinhTheoDonViCanBo(madonvi, macongty);
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                if (DropDownLDonVi.SelectedValue.ToString() == " ")
                {
                    GridView1.DataSource = db.LayQuyTrinhTheoLoaiPhieuCanBo(maloaiphieu, macongty);
                    GridView1.DataBind();
                }
                else
                {
                    string madonvi = DropDownLDonVi.SelectedValue.ToString();
                    GridView1.DataSource = db.LayQuyTrinhTheoDonViCanBoVaLoaiPhieu(madonvi, macongty, maloaiphieu);
                    GridView1.DataBind();
                }
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string macongty = Session["congty"].ToString();
            // string macongty="LTY";
            GridView1.DataSource = db.LayDanhSachQuyTrinhXetDuyetCuaCanBo(macongty);
            GridView1.DataBind();
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trangthu = e.NewPageIndex;
            int sodong = GridView1.PageSize;
            STT = trangthu * sodong + 1;
            HienThiDanhSach();
        }
    }
}