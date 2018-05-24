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
using System.Data;
using System.Data.SqlClient;
namespace iOffice.presentationLayer.Admin
{
    public partial class FQPDNFlow : LanguegeBus
    {
        static iOfficeDataContext db = new iOfficeDataContext();
        //private static String MA_CTXetDuyet = "CTXD";
        //string kiemtamaphieu;
       
        //int capduyet=0;
       
        int STT = 1;
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/presentationLayer/DangNhap.aspx");
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
           
            if (!IsPostBack)
            {
                
                HienThiDonVi();
                HienThiLoaiPhieu();
                HienThiDanhSach();
                DropDownLDonVi.Items.Insert(0, "All");
                DropDownLoaiPhieu.Items.Insert(0, " ");
                DropDownABStep.Items.Insert(0, "Select ABStep");
                btnBack.Visible = false;
                btnQuery.Visible = false;
                  // DropDownList1.Items.Insert(0, new ListItem("Add New", ""));
            }
   
          
            
        }
        public string GetSTT()
        {
            return Convert.ToString(STT++);
        }
        public override void GanNgonNguVaoConTrol()
        {
          
            
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
            //GridView1.Columns[10].HeaderText = hasLanguege["lblBuocDuyet"].ToString();
            GridView1.Columns[10].HeaderText = hasLanguege["NguoiDuyet"].ToString();
            GridView1.Columns[11].HeaderText = hasLanguege["USERNAME"].ToString();
            GridView1.Columns[12].HeaderText = hasLanguege["IDChucVu"].ToString();
            GridView1.Columns[13].HeaderText = hasLanguege["TenChucVuTiengHoa"].ToString();
            GridView1.Columns[14].HeaderText = hasLanguege["IDCapDuyet"].ToString();
            GridView1.Columns[15].HeaderText = hasLanguege["IDLoaiDonVi"].ToString();
           
           
        }
    

       
        private void HienThiDonVi()
        {
            DropDownLDonVi.DataSource = BDepartmentBUS.DanhSachBoPhan();
            DropDownLDonVi.DataValueField = "ID";
            DropDownLDonVi.DataTextField = "DepName";
            DropDownLDonVi.DataBind();
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
            quytrinhDal dal = new quytrinhDal();
            string macongty = Session["congty"].ToString();
            // string macongty="LTY";
            GridView1.DataSource = dal.QryQPDNFlow(macongty);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (lbThongBao.Text.Trim() == "")
            {
                lbThongBao.Text = "";
            }
            if (DropDownABStep.SelectedItem.ToString().Trim() == "Select ABStep" || DropDownLoaiPhieu.SelectedItem.ToString().Trim() == "" || txtNguoiDuyet.Text.Trim() == "")
            {
                lbThongBao.Text = "Input Incorect";
            }
            else
            {
                quytrinhDal dal = new quytrinhDal();
                abconDAL dalabcon = new abconDAL();
                departDAL dalDepart = new departDAL();
                if (lbThongBao.Text.Trim() != "")
                {
                    lbThongBao.Text = "";
                }
                string macongty = DropCty.SelectedValue.ToString();

                string madonvi = DropDownLDonVi.SelectedValue.ToString().Trim();
                string maLoaiPhieu = DropDownLoaiPhieu.SelectedValue.ToString().Trim();
                string manguoiduyet = txtNguoiDuyet.Text.Trim().ToUpper();
                int AbStep = int.Parse(DropDownABStep.SelectedValue);
                int ABPS = int.Parse(DropDownABPS.SelectedValue);
                if (madonvi == "All")
                {
                    if (manguoiduyet != "ZZZZZZ")
                    {
                        Busers2 timmanguoiduyet = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                        if (timmanguoiduyet != null)
                        {
                            if (timmanguoiduyet.IDCapDuyet == 7)
                            {
                                AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(2, macongty);
                                QPDNFlow quytrinh = new QPDNFlow();
                                quytrinh.BADEPID = "All";
                                quytrinh.tendonviTW = "All";
                                quytrinh.GSBH = macongty;
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
                                quytrinh.DonViThongQua = null;

                                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                quytrinh.NguoiDuyet = nguoi.USERID;
                                quytrinh.USERNAME = nguoi.USERNAME;
                                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                quytrinh.IDChucVu = chuc.IDChucVu;

                                quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                quytrinh.ABstep = AbStep;
                                quytrinh.ABPS = ABPS + 1;
                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                            }
                            else
                            {
                                DataTable QQTrinh = dal.TimNguoiTrongQuyTrinh(macongty, madonvi, maLoaiPhieu, AbStep, ABPS);
                                if (QQTrinh.Rows.Count > 0)
                                {
                                    int IDCapDuyet = int.Parse(QQTrinh.Rows[0]["IDCapDuyet"].ToString());
                                    if (IDCapDuyet < timmanguoiduyet.IDCapDuyet)
                                    {
                                        DataTable data = dal.DanhSachNguoiDuyet(macongty, maLoaiPhieu, madonvi, AbStep);
                                        if (data.Rows.Count > 0)
                                        {
                                            AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(2, macongty);
                                            QPDNFlow quytrinh = new QPDNFlow();
                                            quytrinh.BADEPID = "All";
                                            quytrinh.tendonviTW = "All";
                                            quytrinh.GSBH = macongty;
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
                                            quytrinh.DonViThongQua = null;

                                            Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                            quytrinh.NguoiDuyet = nguoi.USERID;
                                            quytrinh.USERNAME = nguoi.USERNAME;
                                            ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                            quytrinh.IDChucVu = chuc.IDChucVu;

                                            quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                            quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                            quytrinh.ABstep = AbStep;
                                            quytrinh.ABPS = ABPS;
                                            foreach (DataRow drr in data.Rows)
                                            {
                                                int step = int.Parse(drr["ABstep"].ToString()) + 1;
                                                int abps = int.Parse(drr["ABPS"].ToString());
                                                int idquytrinh = int.Parse(drr["IDQuyTrinh"].ToString());
                                                dal.CapNhatQuyABPSAndAbstep(macongty, maLoaiPhieu, madonvi, idquytrinh, step, abps);
                                            }
                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                        }
                                    }

                                }
                                else
                                {
                                    QPDNFlow quytrinh = new QPDNFlow();
                                    quytrinh.BADEPID = "All";
                                    quytrinh.tendonviTW = "All";
                                    quytrinh.GSBH = macongty;
                                    quytrinh.IDLoaiDonVi = 2;
                                    quytrinh.DepartmentTypeNameTW = "";
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
                                    quytrinh.DonViThongQua = null;

                                    Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                    quytrinh.NguoiDuyet = nguoi.USERID;
                                    quytrinh.USERNAME = nguoi.USERNAME;
                                    ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                    quytrinh.IDChucVu = chuc.IDChucVu;

                                    quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                    quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                    quytrinh.ABstep = AbStep;
                                    quytrinh.ABPS = ABPS;
                                    
                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                }
                             
                            }
                        }
                    }
                    else
                    {
                        QPDNFlow qtrinh = new QPDNFlow();
                        qtrinh.ABPS = 1;
                        qtrinh.ABstep = 1;
                        if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                        {
                            qtrinh.abtype = "PDN1";
                            abill timloai = abillBUS.SearchAbillByID(qtrinh.abtype);
                            qtrinh.abtypenameTW = timloai.abnameTW;
                        }
                        else
                        {
                            qtrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                            abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                            qtrinh.abtypenameTW = timloai.abnameTW;
                        }
                        qtrinh.BADEPID = "All";
                        qtrinh.DepartmentTypeNameTW = "间接单位";
                        qtrinh.GSBH = macongty;
                        qtrinh.IDCapDuyet = 7;
                        qtrinh.IDChucVu = "CQDV";
                        qtrinh.IDLoaiDonVi = 2;
                        qtrinh.NguoiDuyet = "ZZZZZZ";
                        qtrinh.USERNAME = "";
                        qtrinh.TenChucVuTiengHoa = "单位主管";
                        qtrinh.tendonviTW = "All";
                        dal.ThemQPDNFlow(qtrinh.GSBH, qtrinh.abtype, qtrinh.BADEPID, qtrinh.ABstep, qtrinh.ABPS, qtrinh.NguoiDuyet, qtrinh.USERNAME, qtrinh.IDChucVu, qtrinh.abtypenameTW, qtrinh.tendonviTW, int.Parse(qtrinh.IDLoaiDonVi.ToString()), qtrinh.DepartmentTypeNameTW, int.Parse(qtrinh.IDCapDuyet.ToString()), qtrinh.TenChucVuTiengHoa);
                    }
                }
                else
                {
                    if (manguoiduyet.Length >= 5)
                    {
                        DataTable dtnguoiDuyet = dal.TimNguoiDuyet(macongty, manguoiduyet);
                        if (dtnguoiDuyet.Rows.Count != 0 || manguoiduyet == "ZZZZZZ")
                        {
                            // cho tat ca don vi
                            if (madonvi == "All")
                            {


                                if (manguoiduyet == "ZZZZZZ")
                                {
                                    #region Cai nay moi
                                    QPDNFlow qtrinh = new QPDNFlow();
                                    qtrinh.ABPS = 1;
                                    qtrinh.ABstep = 1;
                                    if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                                    {
                                        qtrinh.abtype = "PDN1";
                                        abill timloai = abillBUS.SearchAbillByID(qtrinh.abtype);
                                        qtrinh.abtypenameTW = timloai.abnameTW;
                                    }
                                    else
                                    {
                                        qtrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                                        abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                                        qtrinh.abtypenameTW = timloai.abnameTW;
                                    }
                                    qtrinh.BADEPID = "All";
                                    qtrinh.DepartmentTypeNameTW = "间接单位";
                                    qtrinh.GSBH = macongty;
                                    qtrinh.IDCapDuyet = 7;
                                    qtrinh.IDChucVu = "CQDV";
                                    qtrinh.IDLoaiDonVi = 2;
                                    qtrinh.NguoiDuyet = "ZZZZZZ";
                                    qtrinh.USERNAME = "";
                                    qtrinh.TenChucVuTiengHoa = "单位主管";
                                    qtrinh.tendonviTW = "All";
                                    dal.ThemQPDNFlow(qtrinh.GSBH, qtrinh.abtype, qtrinh.BADEPID, qtrinh.ABstep, qtrinh.ABPS, qtrinh.NguoiDuyet, qtrinh.USERNAME, qtrinh.IDChucVu, qtrinh.abtypenameTW, qtrinh.tendonviTW, int.Parse(qtrinh.IDLoaiDonVi.ToString()), qtrinh.DepartmentTypeNameTW, int.Parse(qtrinh.IDCapDuyet.ToString()), qtrinh.TenChucVuTiengHoa);
                                    #endregion
                                    #region Cai cu
                                    //DataTable dtDepart = dalDepart.QryDonViDeXetQuyTrinh(macongty);
                                    //foreach (DataRow dr in dtDepart.Rows)
                                    //{
                                    //    string MaDonVi = dr["ID"].ToString().Trim();
                                    //    int MaloaiDV = int.Parse(dr["DepartmentTypeID"].ToString());
                                    //    string tenDV = dr["DepName"].ToString();
                                    //    string maCQDV = dr["IdUserChuQuan"].ToString().Trim();
                                    //    QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(manguoiduyet, maLoaiPhieu, MaDonVi, macongty);
                                    //    if (tim == null)
                                    //    {
                                    //        AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(MaloaiDV, macongty);
                                    //        QPDNFlow quytrinh = new QPDNFlow();
                                    //        quytrinh.BADEPID = MaDonVi;
                                    //        quytrinh.tendonviTW = tenDV;
                                    //        quytrinh.GSBH = macongty;
                                    //        quytrinh.IDLoaiDonVi = loaidonvi.DepartmentTypeID;
                                    //        quytrinh.DepartmentTypeNameTW = loaidonvi.DepartmentTypeNameTW;
                                    //        if (DropDownLoaiPhieu.SelectedValue.ToString().Trim() == "")
                                    //        {
                                    //            quytrinh.abtype = "PDN1";
                                    //            abill timloai = abillBUS.SearchAbillByID(quytrinh.abtype);
                                    //            quytrinh.abtypenameTW = timloai.abnameTW;
                                    //        }
                                    //        else
                                    //        {
                                    //            quytrinh.abtype = DropDownLoaiPhieu.SelectedValue.ToString();
                                    //            abill timloai = abillBUS.SearchAbillByID(DropDownLoaiPhieu.SelectedValue.ToString());
                                    //            quytrinh.abtypenameTW = timloai.abnameTW;
                                    //        }
                                    //        quytrinh.DonViThongQua = null;

                                    //        Busers2 nguoi = UserDAO.TimNhanVienTheoMa(maCQDV, macongty);
                                    //        quytrinh.NguoiDuyet = nguoi.USERID;
                                    //        quytrinh.USERNAME = nguoi.USERNAME;
                                    //        ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                    //        quytrinh.IDChucVu = chuc.IDChucVu;
                                    //        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;

                                    //        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                    //        quytrinh.ABstep = AbStep;
                                    //        quytrinh.ABPS = ABPS;
                                    //        DataTable dtquytrinh = dal.TimBuocKyTrongQuytrinhXD(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS,int.Parse(nguoi.IDCapDuyet.ToString()));
                                    //        if (dtquytrinh.Rows.Count > 0)
                                    //        {
                                    //            string ND = dtquytrinh.Rows[0]["NguoiDuyet"].ToString().Trim();
                                    //            if (quytrinh.NguoiDuyet != ND)
                                    //            {
                                    //                foreach (DataRow drQT in dtquytrinh.Rows)
                                    //                {
                                    //                    int ID = int.Parse(drQT["IDQuyTrinh"].ToString());
                                    //                    int abstep = int.Parse(drQT["ABstep"].ToString());
                                    //                    int abps = int.Parse(drQT["ABPS"].ToString()) + 1;
                                    //                    string gsbh = drQT["GSBH"].ToString();
                                    //                    string abtype = drQT["abtype"].ToString();
                                    //                    string badepid = drQT["BADEPID"].ToString();
                                    //                    dal.CapNhatQuyABPS(macongty, abtype, MaDonVi, ID, abstep, abps);
                                    //                }
                                    //                dal.ThemQPDNFlow(macongty, quytrinh.abtype, MaDonVi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()),quytrinh.TenChucVuTiengHoa);
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            DataTable timnguoi = dal.TimNguoiTrongQT(macongty,MaDonVi,quytrinh.abtype,nguoi.USERID);
                                    //            if (timnguoi.Rows.Count == 0)
                                    //            {
                                    //                dal.ThemQPDNFlow(macongty, quytrinh.abtype, MaDonVi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()),quytrinh.TenChucVuTiengHoa);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    #endregion
                                }// khac cai ZZZZZZ
                                else
                                {
                                    if (dtnguoiDuyet.Rows.Count > 0)
                                    {
                                        string manguoi = dtnguoiDuyet.Rows[0]["UserID"].ToString();
                                        int capduyet = int.Parse(dtnguoiDuyet.Rows[0]["IDCapDuyet"].ToString());
                                        if (AbStep == 1)
                                        {
                                            if (capduyet > 7)
                                            {

                                                DataTable dtDepart = dal.QryDonViTrongQuyTrinh(macongty);
                                                foreach (DataRow dr in dtDepart.Rows)
                                                {
                                                    string MaDonVi = dr["ID"].ToString().Trim();
                                                    int MaloaiDV = int.Parse(dr["DepartmentTypeID"].ToString());
                                                    string tenDV = dr["tendonviTW"].ToString();
                                                    //string maCQDV = dr["IdUserChuQuan"].ToString().Trim();
                                                    QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(manguoiduyet, maLoaiPhieu, MaDonVi, macongty);
                                                    if (tim == null)
                                                    {
                                                        AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(MaloaiDV, macongty);
                                                        QPDNFlow quytrinh = new QPDNFlow();
                                                        quytrinh.BADEPID = MaDonVi;
                                                        quytrinh.tendonviTW = tenDV;
                                                        quytrinh.GSBH = macongty;
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
                                                        quytrinh.DonViThongQua = null;

                                                        Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                        quytrinh.NguoiDuyet = nguoi.USERID;
                                                        quytrinh.USERNAME = nguoi.USERNAME;
                                                        ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                        quytrinh.IDChucVu = chuc.IDChucVu;
                                                        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                        quytrinh.ABstep = AbStep;
                                                        quytrinh.ABPS = ABPS;
                                                        DataTable dtquytrinh = dal.TimBuocKyTrongQuytrinhXD(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS, int.Parse(nguoi.IDCapDuyet.ToString()));
                                                        if (dtquytrinh.Rows.Count > 0)
                                                        {
                                                            string ND = dtquytrinh.Rows[0]["NguoiDuyet"].ToString().Trim();
                                                            if (quytrinh.NguoiDuyet != ND)
                                                            {
                                                                foreach (DataRow drQT in dtquytrinh.Rows)
                                                                {
                                                                    int ID = int.Parse(drQT["IDQuyTrinh"].ToString());
                                                                    int abstep = int.Parse(drQT["ABstep"].ToString());
                                                                    int abps = int.Parse(drQT["ABPS"].ToString()) + 1;
                                                                    string gsbh = drQT["GSBH"].ToString();
                                                                    string abtype = drQT["abtype"].ToString();
                                                                    string badepid = drQT["BADEPID"].ToString();
                                                                    dal.CapNhatQuyABPS(macongty, abtype, MaDonVi, ID, abstep, abps);
                                                                }
                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, MaDonVi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            DataTable timnguoi = dal.TimNguoiTrongQT(macongty, MaDonVi, quytrinh.abtype, nguoi.USERID);
                                                            if (timnguoi.Rows.Count == 0)
                                                            {
                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, MaDonVi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                            }
                                                        }
                                                    }
                                                }
                                            }// Cap <=7
                                            else
                                            {
                                                DataTable dtDepart = dalDepart.QryDonViMaNguoiDuyetQuanLy(macongty, manguoiduyet);
                                                if (dtDepart.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr in dtDepart.Rows)
                                                    {
                                                        string MaDonVi = dr["ID"].ToString().Trim();
                                                        int MaloaiDV = int.Parse(dr["DepartmentTypeID"].ToString());
                                                        string tenDV = dr["DepName"].ToString();
                                                        string maCQDV = dr["IdUserChuQuan"].ToString().Trim();
                                                        QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(manguoiduyet, maLoaiPhieu, MaDonVi, macongty);
                                                        if (tim == null)
                                                        {
                                                            AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(MaloaiDV, macongty);
                                                            QPDNFlow quytrinh = new QPDNFlow();
                                                            quytrinh.BADEPID = MaDonVi;
                                                            quytrinh.tendonviTW = tenDV;
                                                            quytrinh.GSBH = macongty;
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
                                                            quytrinh.DonViThongQua = null;

                                                            Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                            quytrinh.NguoiDuyet = nguoi.USERID;
                                                            quytrinh.USERNAME = nguoi.USERNAME;
                                                            ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                            quytrinh.IDChucVu = chuc.IDChucVu;
                                                            quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                            quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                            quytrinh.ABstep = AbStep;
                                                            quytrinh.ABPS = ABPS;
                                                            DataTable dtquytrinh = dal.TimBuocKyTrongQuytrinhXD(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS, int.Parse(nguoi.IDCapDuyet.ToString()));
                                                            if (dtquytrinh.Rows.Count > 0)
                                                            {
                                                                string ND = dtquytrinh.Rows[0]["NguoiDuyet"].ToString().Trim();
                                                                if (quytrinh.NguoiDuyet != ND)
                                                                {
                                                                    foreach (DataRow drQT in dtquytrinh.Rows)
                                                                    {
                                                                        int ID = int.Parse(drQT["IDQuyTrinh"].ToString());
                                                                        int abstep = int.Parse(drQT["ABstep"].ToString());
                                                                        int abps = int.Parse(drQT["ABPS"].ToString()) + 1;
                                                                        string gsbh = drQT["GSBH"].ToString();
                                                                        string abtype = drQT["abtype"].ToString();
                                                                        string badepid = drQT["BADEPID"].ToString();
                                                                        dal.CapNhatQuyABPS(macongty, abtype, MaDonVi, ID, abstep, abps);
                                                                    }
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable timnguoi = dal.TimNguoiTrongQT(macongty, madonvi, quytrinh.abtype, nguoi.USERID);
                                                                if (timnguoi.Rows.Count == 0)
                                                                {
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (madonvi == "All")
                                                            {
                                                                if (capduyet == 7)
                                                                {
                                                                    AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(MaloaiDV, macongty);
                                                                    QPDNFlow quytrinh = new QPDNFlow();
                                                                    quytrinh.BADEPID = "All";
                                                                    quytrinh.tendonviTW = "All";
                                                                    quytrinh.GSBH = macongty;
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
                                                                    quytrinh.DonViThongQua = null;

                                                                    Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                                    quytrinh.NguoiDuyet = nguoi.USERID;
                                                                    quytrinh.USERNAME = nguoi.USERNAME;
                                                                    ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                                    quytrinh.IDChucVu = chuc.IDChucVu;

                                                                    quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                                    quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                                    quytrinh.ABstep = AbStep;
                                                                    quytrinh.ABPS = ABPS + 1;
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                                else
                                                                {
                                                                    DataTable data = dal.DanhSachNguoiDuyet(macongty, maLoaiPhieu, madonvi, AbStep);
                                                                    if (data.Rows.Count > 0)
                                                                    {
                                                                        AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(MaloaiDV, macongty);
                                                                        QPDNFlow quytrinh = new QPDNFlow();
                                                                        quytrinh.BADEPID = "All";
                                                                        quytrinh.tendonviTW = "All";
                                                                        quytrinh.GSBH = macongty;
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
                                                                        quytrinh.DonViThongQua = null;

                                                                        Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                                        quytrinh.NguoiDuyet = nguoi.USERID;
                                                                        quytrinh.USERNAME = nguoi.USERNAME;
                                                                        ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                                        quytrinh.IDChucVu = chuc.IDChucVu;

                                                                        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                                        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                                        quytrinh.ABstep = AbStep;
                                                                        quytrinh.ABPS = ABPS;
                                                                        foreach (DataRow drr in data.Rows)
                                                                        {
                                                                            int step = int.Parse(drr["ABstep"].ToString()) + 1;
                                                                            int abps = int.Parse(drr["ABPS"].ToString());
                                                                            int idquytrinh = int.Parse(drr["IDQuyTrinh"].ToString());
                                                                            dal.CapNhatQuyABPSAndAbstep(macongty, maLoaiPhieu, madonvi, idquytrinh, step, abps);
                                                                        }
                                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (madonvi == "All")
                                                    {
                                                        if (capduyet == 7)
                                                        {
                                                            AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(2, macongty);
                                                            QPDNFlow quytrinh = new QPDNFlow();
                                                            quytrinh.BADEPID = "All";
                                                            quytrinh.tendonviTW = "All";
                                                            quytrinh.GSBH = macongty;
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
                                                            quytrinh.DonViThongQua = null;

                                                            Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                            quytrinh.NguoiDuyet = nguoi.USERID;
                                                            quytrinh.USERNAME = nguoi.USERNAME;
                                                            ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                            quytrinh.IDChucVu = chuc.IDChucVu;

                                                            quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                            quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                            quytrinh.ABstep = AbStep;
                                                            quytrinh.ABPS = ABPS + 1;
                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                        }
                                                        else
                                                        {
                                                            DataTable data = dal.DanhSachNguoiDuyet(macongty, maLoaiPhieu, madonvi, AbStep);
                                                            if (data.Rows.Count > 0)
                                                            {
                                                                AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(2, macongty);
                                                                QPDNFlow quytrinh = new QPDNFlow();
                                                                quytrinh.BADEPID = "All";
                                                                quytrinh.tendonviTW = "All";
                                                                quytrinh.GSBH = macongty;
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
                                                                quytrinh.DonViThongQua = null;

                                                                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                                quytrinh.NguoiDuyet = nguoi.USERID;
                                                                quytrinh.USERNAME = nguoi.USERNAME;
                                                                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                                quytrinh.IDChucVu = chuc.IDChucVu;

                                                                quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                                quytrinh.ABstep = AbStep;
                                                                quytrinh.ABPS = ABPS;
                                                                foreach (DataRow drr in data.Rows)
                                                                {
                                                                    int step = int.Parse(drr["ABstep"].ToString()) + 1;
                                                                    int abps = int.Parse(drr["ABPS"].ToString());
                                                                    int idquytrinh = int.Parse(drr["IDQuyTrinh"].ToString());
                                                                    dal.CapNhatQuyABPSAndAbstep(macongty, maLoaiPhieu, madonvi, idquytrinh, step, abps);
                                                                }
                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }// Abstep>1
                                        else
                                        {
                                            QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(manguoiduyet, maLoaiPhieu, "All", macongty);
                                            if (tim == null)
                                            {
                                                //AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(, macongty);
                                                QPDNFlow quytrinh = new QPDNFlow();
                                                quytrinh.BADEPID = "All";
                                                quytrinh.tendonviTW = "All";
                                                quytrinh.GSBH = macongty;
                                                quytrinh.IDLoaiDonVi = 2;
                                                quytrinh.DepartmentTypeNameTW = "";
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
                                                quytrinh.DonViThongQua = null;

                                                Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                                quytrinh.NguoiDuyet = nguoi.USERID;
                                                quytrinh.USERNAME = nguoi.USERNAME;
                                                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                quytrinh.IDChucVu = chuc.IDChucVu;
                                                quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                quytrinh.ABstep = AbStep;
                                                quytrinh.ABPS = ABPS;
                                                //List<QPDNFlow> listQt = QPDNFlowDAO.DanhSachNguoiDuyetTrong1Cap(macongty, maLoaiPhieu, madonvi, AbStep, ABPS);
                                                DataTable dtQt = dal.KiemNguoiTrongBuocKy(macongty, maLoaiPhieu, madonvi, AbStep, ABPS);
                                                if (dtQt.Rows.Count > 0)
                                                {
                                                    foreach (DataRow qt in dtQt.Rows)
                                                    {
                                                        int abstep = int.Parse(qt["ABstep"].ToString());
                                                        int abps = int.Parse(qt["ABPS"].ToString()) + 1;
                                                        int IDQuyTrinh = int.Parse(qt["IDQuyTrinh"].ToString());
                                                        dal.CapNhatQuyABPS(macongty, maLoaiPhieu, madonvi, IDQuyTrinh, abstep, abps);
                                                    }
                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, quytrinh.BADEPID, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                }
                                                else
                                                {
                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, quytrinh.BADEPID, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                }
                                            }
                                        }


                                    }
                                }

                            }
                            #region cho tung don vi
                            else
                            {
                                #region Cai nay moi
                                if (manguoiduyet != "ZZZZZZ")
                                {
                                    QPDNFlow tim = QPDNFlowDAO.TimNguoiTrongQuyTrinh(manguoiduyet, maLoaiPhieu, madonvi, macongty);
                                    if (tim == null)
                                    {
                                        Busers2 nguoi = UserDAO.TimNhanVienTheoMa(manguoiduyet, macongty);
                                        BDepartment donvi = BDepartmentDAO.TimMaDonVi(madonvi, macongty);
                                        AbDepartmentType loaidonvi = LoaiDonViDAO.TimMaLoaiDonVi(int.Parse(donvi.DepartmentTypeID.ToString()), macongty);
                                        QPDNFlow nguoitrongquytrinh = QPDNFlowDAO.TimNguoiTrongQuyTrinh(macongty, maLoaiPhieu, madonvi, AbStep);
                                        if (nguoitrongquytrinh != null)
                                        {
                                            if (nguoi != null)
                                            {
                                                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                if (AbStep == 1)
                                                {
                                                    if (ABPS == 1)
                                                    {
                                                        QPDNFlow quytrinh = new QPDNFlow();
                                                        quytrinh.BADEPID = madonvi;
                                                        quytrinh.tendonviTW = donvi.DepName;
                                                        quytrinh.GSBH = macongty;
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
                                                        quytrinh.DonViThongQua = null;
                                                        quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                        quytrinh.USERNAME = nguoi.USERNAME;

                                                        quytrinh.IDChucVu = chuc.IDChucVu;
                                                        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                        quytrinh.ABstep = AbStep;
                                                        quytrinh.ABPS = AbStep;
                                                        // chieu lam di
                                                        if (nguoi.IDCapDuyet < nguoitrongquytrinh.IDCapDuyet)
                                                        {
                                                            // List<QPDNFlow> lis = QPDNFlowDAO.DanhSachNguoiTrongQuyTrinh(macongty, maLoaiPhieu, madonvi, AbStep);
                                                            DataTable dtquytrinh = dal.TimAbstepLonHonHoacBangBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep);
                                                            if (dtquytrinh.Rows.Count > 0)
                                                            {
                                                                int abstepTemp = 0;
                                                                int abpsTemp = 0;
                                                                foreach (DataRow dr in dtquytrinh.Rows)
                                                                {

                                                                    int abstep = 1;
                                                                    int abps = 1;
                                                                    int ID = int.Parse(dr["IDQuyTrinh"].ToString());

                                                                    int abstep1 = int.Parse(dr["ABstep"].ToString()) + 1;
                                                                    int abps1 = int.Parse(dr["ABPS"].ToString());
                                                                    if (abstepTemp == abstep1)
                                                                    {
                                                                        abstep = abstepTemp;
                                                                    }
                                                                    else
                                                                    {
                                                                        abstep = abstep1;
                                                                    }
                                                                    if (abps == abpsTemp)
                                                                    {
                                                                        abps = abpsTemp;
                                                                    }
                                                                    else
                                                                    {
                                                                        abps = abps1;
                                                                    }
                                                                    string gsbh = dr["GSBH"].ToString();
                                                                    string abtype = dr["abtype"].ToString();
                                                                    string badepid = dr["BADEPID"].ToString();
                                                                    dal.CapNhatQuyABPSAndAbstep(macongty, abtype, madonvi, ID, abstep, abps);
                                                                }
                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);

                                                            }
                                                            else
                                                            {
                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (nguoi.IDCapDuyet >= nguoitrongquytrinh.IDCapDuyet)
                                                            {

                                                                DataTable dtCapHienTai = dal.TimBuocKyLonHonHoacBangBuocHienTai(macongty, madonvi, maLoaiPhieu, AbStep, ABPS);
                                                                if (dtCapHienTai.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow dr in dtCapHienTai.Rows)
                                                                    {
                                                                        int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                        int abstep = int.Parse(dr["ABstep"].ToString());
                                                                        int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                        string gsbh = dr["GSBH"].ToString();
                                                                        string abtype = dr["abtype"].ToString();
                                                                        string badepid = dr["BADEPID"].ToString();
                                                                        dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                    }
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                                else
                                                                {
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                            }
                                                        }

                                                        //dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                    }// ABPS>1
                                                    else
                                                    {
                                                        QPDNFlow timMaQT = QPDNFlowDAO.TimMaQuyTrinhTruocKhiThem(macongty, maLoaiPhieu, madonvi, AbStep, ABPS);
                                                        if (timMaQT != null)
                                                        {
                                                            if (timMaQT.NguoiDuyet != manguoiduyet)
                                                            {
                                                                if (timMaQT.NguoiDuyet == "ZZZZZZ")
                                                                {
                                                                    QPDNFlow quytrinh = new QPDNFlow();
                                                                    quytrinh.BADEPID = madonvi;
                                                                    quytrinh.tendonviTW = donvi.DepName;
                                                                    quytrinh.GSBH = macongty;
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
                                                                    quytrinh.DonViThongQua = null;
                                                                    quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                                    quytrinh.USERNAME = nguoi.USERNAME;

                                                                    quytrinh.IDChucVu = chuc.IDChucVu;
                                                                    quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                                    quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                                    quytrinh.ABstep = AbStep;
                                                                    quytrinh.ABPS = ABPS;
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }// Nguoi lai khac ZZZZZZ
                                                                else
                                                                {
                                                                    QPDNFlow quytrinh = new QPDNFlow();
                                                                    quytrinh.BADEPID = madonvi;
                                                                    quytrinh.tendonviTW = donvi.DepName;
                                                                    quytrinh.GSBH = macongty;
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
                                                                    quytrinh.DonViThongQua = null;
                                                                    quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                                    quytrinh.USERNAME = nguoi.USERNAME;

                                                                    quytrinh.IDChucVu = chuc.IDChucVu;
                                                                    quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                                    quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                                    quytrinh.ABstep = AbStep;
                                                                    quytrinh.ABPS = ABPS;
                                                                    if (timMaQT.IDCapDuyet > nguoi.IDCapDuyet)
                                                                    {
                                                                        DataTable dtquytrinh = dal.TimBuocKyLonHonHoacBangBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                        if (dtquytrinh.Rows.Count > 0)
                                                                        {
                                                                            foreach (DataRow dr in dtquytrinh.Rows)
                                                                            {
                                                                                int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                string gsbh = dr["GSBH"].ToString();
                                                                                string abtype = dr["abtype"].ToString();
                                                                                string badepid = dr["BADEPID"].ToString();
                                                                                dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                            }
                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);

                                                                        }
                                                                        else
                                                                        {
                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (timMaQT.IDCapDuyet == nguoi.IDCapDuyet)
                                                                        {
                                                                            if (timMaQT.BADEPID == nguoi.BADEPID)
                                                                            {
                                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            QPDNFlow buoctieptheo = QPDNFlowDAO.DanhSachQuyTrinhLonHonBuocTiepTheoABPS(macongty, quytrinh.abtype, madonvi, AbStep, ABPS + 1);
                                                                            if (buoctieptheo == null)
                                                                            {
                                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (nguoi.BADEPID == timMaQT.BADEPID)
                                                                                {
                                                                                    DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                                    if (dtquytrinh.Rows.Count > 0)
                                                                                    {
                                                                                        foreach (DataRow dr in dtquytrinh.Rows)
                                                                                        {
                                                                                            int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                            int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                            int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                            string gsbh = dr["GSBH"].ToString();
                                                                                            string abtype = dr["abtype"].ToString();
                                                                                            string badepid = dr["BADEPID"].ToString();
                                                                                            dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                        }
                                                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    Busers2 timnguoi = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                                                    if (timnguoi != null && timnguoi.BADEPID == quytrinh.BADEPID)
                                                                                    {
                                                                                        DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                                        if (dtquytrinh.Rows.Count > 0)
                                                                                        {
                                                                                            foreach (DataRow dr in dtquytrinh.Rows)
                                                                                            {
                                                                                                int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                                int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                                int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                                string gsbh = dr["GSBH"].ToString();
                                                                                                string abtype = dr["abtype"].ToString();
                                                                                                string badepid = dr["BADEPID"].ToString();
                                                                                                dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                            }
                                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {

                                                                                        DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                                        if (dtquytrinh.Rows.Count > 0)
                                                                                        {
                                                                                            foreach (DataRow dr in dtquytrinh.Rows)
                                                                                            {
                                                                                                int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                                int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                                int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                                string gsbh = dr["GSBH"].ToString();
                                                                                                string abtype = dr["abtype"].ToString();
                                                                                                string badepid = dr["BADEPID"].ToString();
                                                                                                dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                            }
                                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                        }
                                                                                    }

                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                        }
                                                        else
                                                        {

                                                            QPDNFlow quytrinh = new QPDNFlow();
                                                            quytrinh.BADEPID = madonvi;
                                                            quytrinh.tendonviTW = donvi.DepName;
                                                            quytrinh.GSBH = macongty;
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
                                                            quytrinh.DonViThongQua = null;
                                                            quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                            quytrinh.USERNAME = nguoi.USERNAME;

                                                            quytrinh.IDChucVu = chuc.IDChucVu;
                                                            quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                            quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                            quytrinh.ABstep = AbStep;
                                                            quytrinh.ABPS = ABPS;
                                                            dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, quytrinh.ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                        }
                                                    }
                                                }// < ABStep> 1
                                                else
                                                {
                                                    QPDNFlow timMaQT = QPDNFlowDAO.TimMaQuyTrinhTruocKhiThem(macongty, maLoaiPhieu, madonvi, AbStep, ABPS);
                                                    if (timMaQT != null)
                                                    {
                                                        QPDNFlow quytrinh = new QPDNFlow();
                                                        quytrinh.BADEPID = madonvi;
                                                        quytrinh.tendonviTW = donvi.DepName;
                                                        quytrinh.GSBH = macongty;
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
                                                        quytrinh.DonViThongQua = null;
                                                        quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                        quytrinh.USERNAME = nguoi.USERNAME;

                                                        quytrinh.IDChucVu = chuc.IDChucVu;
                                                        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                        quytrinh.ABstep = AbStep;
                                                        quytrinh.ABPS = ABPS;
                                                        if (timMaQT.ABPS == 1)
                                                        {
                                                            if (timMaQT.IDCapDuyet > nguoi.IDCapDuyet)
                                                            {
                                                                DataTable dtquytrinh = dal.TimBuocKyLonHonHoacBangBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                if (dtquytrinh.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow dr in dtquytrinh.Rows)
                                                                    {
                                                                        int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                        int abstep = int.Parse(dr["ABstep"].ToString());
                                                                        int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                        string gsbh = dr["GSBH"].ToString();
                                                                        string abtype = dr["abtype"].ToString();
                                                                        string badepid = dr["BADEPID"].ToString();
                                                                        dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                    }
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);

                                                                }
                                                                else
                                                                {
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (timMaQT.IDCapDuyet == nguoi.IDCapDuyet)
                                                                {

                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS + 1, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);

                                                                }
                                                                else
                                                                {
                                                                    QPDNFlow buoctieptheo = QPDNFlowDAO.DanhSachQuyTrinhLonHonBuocTiepTheoABPS(macongty, quytrinh.abtype, madonvi, AbStep, ABPS + 1);
                                                                    if (buoctieptheo == null)
                                                                    {
                                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS + 1, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (nguoi.BADEPID == timMaQT.BADEPID)
                                                                        {
                                                                            DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                            if (dtquytrinh.Rows.Count > 0)
                                                                            {
                                                                                foreach (DataRow dr in dtquytrinh.Rows)
                                                                                {
                                                                                    int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                    int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                    int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                    string gsbh = dr["GSBH"].ToString();
                                                                                    string abtype = dr["abtype"].ToString();
                                                                                    string badepid = dr["BADEPID"].ToString();
                                                                                    dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                }
                                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                            }
                                                                            else
                                                                            {
                                                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Busers2 timnguoi = UserBUS.TimNhanVienTheoMa(quytrinh.NguoiDuyet, macongty);
                                                                            if (timnguoi != null && timnguoi.BADEPID == quytrinh.BADEPID)
                                                                            {
                                                                                DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                                if (dtquytrinh.Rows.Count > 0)
                                                                                {
                                                                                    foreach (DataRow dr in dtquytrinh.Rows)
                                                                                    {
                                                                                        int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                        int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                        int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                        string gsbh = dr["GSBH"].ToString();
                                                                                        string abtype = dr["abtype"].ToString();
                                                                                        string badepid = dr["BADEPID"].ToString();
                                                                                        dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                    }
                                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                }
                                                                                else
                                                                                {
                                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                }
                                                                            }
                                                                            else
                                                                            {

                                                                                DataTable dtquytrinh = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                                if (dtquytrinh.Rows.Count > 0)
                                                                                {
                                                                                    foreach (DataRow dr in dtquytrinh.Rows)
                                                                                    {
                                                                                        int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                                        int abstep = int.Parse(dr["ABstep"].ToString());
                                                                                        int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                                        string gsbh = dr["GSBH"].ToString();
                                                                                        string abtype = dr["abtype"].ToString();
                                                                                        string badepid = dr["BADEPID"].ToString();
                                                                                        dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                                    }
                                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                                }
                                                                            }

                                                                        }
                                                                    }
                                                                }
                                                            }

                                                        }//?
                                                        else
                                                        {
                                                            if (timMaQT.IDCapDuyet >= nguoi.IDCapDuyet)
                                                            {
                                                                DataTable dtquytrinh = dal.TimBuocKyLonHonHoacBangBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                if (dtquytrinh.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow dr in dtquytrinh.Rows)
                                                                    {
                                                                        int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                        int abstep = int.Parse(dr["ABstep"].ToString());
                                                                        int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                        string gsbh = dr["GSBH"].ToString();
                                                                        string abtype = dr["abtype"].ToString();
                                                                        string badepid = dr["BADEPID"].ToString();
                                                                        dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                    }
                                                                    dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                }
                                                                else
                                                                {
                                                                    DataTable dtquytrinh1 = dal.TimBuocKyLonHonBuocHienTai(macongty, quytrinh.BADEPID, quytrinh.abtype, AbStep, ABPS);
                                                                    if (dtquytrinh1.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow dr in dtquytrinh.Rows)
                                                                        {
                                                                            int ID = int.Parse(dr["IDQuyTrinh"].ToString());
                                                                            int abstep = int.Parse(dr["ABstep"].ToString());
                                                                            int abps = int.Parse(dr["ABPS"].ToString()) + 1;
                                                                            string gsbh = dr["GSBH"].ToString();
                                                                            string abtype = dr["abtype"].ToString();
                                                                            string badepid = dr["BADEPID"].ToString();
                                                                            dal.CapNhatQuyABPS(macongty, abtype, madonvi, ID, abstep, abps);
                                                                        }
                                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }//Chua co nguoi nay them vao
                                                    else
                                                    {
                                                        QPDNFlow quytrinh = new QPDNFlow();
                                                        quytrinh.BADEPID = madonvi;
                                                        quytrinh.tendonviTW = donvi.DepName;
                                                        quytrinh.GSBH = macongty;
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
                                                        quytrinh.DonViThongQua = null;
                                                        quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                        quytrinh.USERNAME = nguoi.USERNAME;

                                                        quytrinh.IDChucVu = chuc.IDChucVu;
                                                        quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                        quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                        quytrinh.ABstep = AbStep;
                                                        quytrinh.ABPS = ABPS;
                                                        dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                                    }
                                                }

                                            }// nguoc lai neu nguoitrongquytrinh==null
                                        }
                                        else
                                        {
                                            if (nguoi != null)
                                            {
                                                ChucVu chuc = ChucVuDAO.TimMaChucVu(nguoi.IDChucVu, macongty);
                                                QPDNFlow quytrinh = new QPDNFlow();
                                                quytrinh.BADEPID = madonvi;
                                                quytrinh.tendonviTW = donvi.DepName;
                                                quytrinh.GSBH = macongty;
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
                                                quytrinh.DonViThongQua = null;
                                                quytrinh.NguoiDuyet = txtNguoiDuyet.Text;

                                                quytrinh.USERNAME = nguoi.USERNAME;

                                                quytrinh.IDChucVu = chuc.IDChucVu;
                                                quytrinh.TenChucVuTiengHoa = chuc.TenChucVuTiengHoa;
                                                quytrinh.IDCapDuyet = nguoi.IDCapDuyet;
                                                quytrinh.ABstep = AbStep;
                                                quytrinh.ABPS = ABPS;
                                                dal.ThemQPDNFlow(macongty, quytrinh.abtype, madonvi, AbStep, ABPS, quytrinh.NguoiDuyet, quytrinh.USERNAME, quytrinh.IDChucVu, quytrinh.abtypenameTW, quytrinh.tendonviTW, int.Parse(quytrinh.IDLoaiDonVi.ToString()), quytrinh.DepartmentTypeNameTW, int.Parse(quytrinh.IDCapDuyet.ToString()), quytrinh.TenChucVuTiengHoa);
                                            }
                                        }
                                    }// ket thuc tim

                                }
                                else
                                {
                                    lbThongBao.Text = "Using All";
                                }
                                #endregion gg

                            }
                            #endregion aa
                        }
                    }
                    else
                    {
                        lbThongBao.Text = "User Name Incorect!";
                    }



                    ///////////////////////////////////// code by Mr Tuan 

                }

                HienThiDanhSach();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row=GridView1.SelectedRow;
            Label lblID = (Label)row.FindControl("lblIDQuyTrinh");
            string id = lblID.Text.Trim();
            Label lblMaCT = (Label)row.FindControl("lblGSBH");
            string macongty = lblMaCT.Text.Trim();
            Label lblMaLoaiPhieu = (Label)row.FindControl("lblabtype");
            string maloaiphieu = lblMaLoaiPhieu.Text.Trim();
            Label lblMaDV = (Label)row.FindControl("lblBADEPID");
            string madonvi = lblMaDV.Text.Trim();
            Label lblMaND = (Label)row.FindControl("lblNguoiDuyet");
            string manguoiduyet = lblMaND.Text.Trim();
            Label lblMaCV = (Label)row.FindControl("lblIDChucVu");
            string machucvu = lblMaCV.Text.Trim();
            Label lblMaCapDuyet = (Label)row.FindControl("lblIDCapDuyet");
            string macapduyet = lblMaCapDuyet.Text.Trim();
            Label lblMaLoaiDV = (Label)row.FindControl("lblIDLoaiDonVi");
            string maloaidonvi = lblMaLoaiDV.Text.Trim();
            Label lblABstep = (Label)row.FindControl("lblABstep");
             string abstep= lblABstep.Text.Trim();
             Label lblABPS = (Label)row.FindControl("lblABPS");
             string abps = lblABPS.Text.Trim();
            ////
            
             Session["id"] = id;
             Session["macongty"] = macongty;
             Session["maloaiphieu"] = maloaiphieu;
             Session["madonvi"] = madonvi;
             Session["manguoiduyet"] = manguoiduyet;
             Session["machucvu"] = machucvu;
             Session["macapduyet"] = macapduyet;
             Session["maloaidonvi"] = maloaidonvi;
             Session["abstep"] = abstep;
             Session["abps"] = abps;
             Response.Redirect("fSuaQuyTrinh.aspx");

             
        }

        protected void CheckThongQuaDonVi_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void cbLoaiPhieu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            quytrinhDal dal = new quytrinhDal();
            string macongty = DropCty.SelectedValue.ToString();

            string madonvi = DropDownLDonVi.SelectedValue.ToString();
           // GridView1.DataSource = QPDNFlowDAO.QryQuyTrinhTheoBoPhan(madonvi, macongty);
            GridView1.DataSource = dal.QryTheoDieuKien(macongty, madonvi);
            GridView1.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            quytrinhDal dal = new quytrinhDal();
            Label lblID = (Label)GridView1.Rows[e.RowIndex].FindControl("lblIDQuyTrinh");
            int idquytrinh =int.Parse(lblID.Text.Trim());

            Label lblMaCT = (Label)GridView1.Rows[e.RowIndex].FindControl("lblGSBH");
            string macongty = lblMaCT.Text.Trim();
            Label lblMaLoaiPhieu = (Label)GridView1.Rows[e.RowIndex].FindControl("lblabtype");
            string maloaiphieu = lblMaLoaiPhieu.Text.Trim();
            Label lblMaDV = (Label)GridView1.Rows[e.RowIndex].FindControl("lblBADEPID");
            string madonvi = lblMaDV.Text.Trim();
            Label lblMaNguoiDuyet = (Label)GridView1.Rows[e.RowIndex].FindControl("lblNguoiDuyet");
            string manguoiduyet = lblMaNguoiDuyet.Text.Trim();
            Label lblMaCD = (Label)GridView1.Rows[e.RowIndex].FindControl("lblIDCapDuyet");
            string macapduyet = lblMaCD.Text.Trim();
            Label lblMaLoaiDV = (Label)GridView1.Rows[e.RowIndex].FindControl("lblIDLoaiDonVi");
            string maloaidonvi = lblMaLoaiDV.Text.Trim();
            Label lblBuocDuyet = (Label)GridView1.Rows[e.RowIndex].FindControl("lblABstep");
            string buoduyet = lblBuocDuyet.Text.Trim();
            Label lblABPS = (Label)GridView1.Rows[e.RowIndex].FindControl("lblABPS");
            int ABPS=int.Parse(lblABPS.Text.Trim());
            QPDNFlow timQuyTrinh = QPDNFlowDAO.TimMaQuytrinh(macongty, madonvi, maloaiphieu, int.Parse(buoduyet), ABPS);
           

           List<QPDNFlow> timABPSMAX = QPDNFlowDAO.TimABPSQuyTrinhMAX(macongty, maloaiphieu, madonvi, int.Parse(buoduyet));
           int max = (from a in timABPSMAX select a.ABPS).Max();
            if (max == 1)
            {
              //  QPDNFlowDAO.XoaQuyTrinh(macongty, maloaiphieu, int.Parse(buoduyet), madonvi, ABPS);
                
                List<QPDNFlow> lsQuytrinh = QPDNFlowDAO.DanhSachQuyTrinhHonBuocHienTai(macongty, maloaiphieu, madonvi, int.Parse(buoduyet));
                dal.XoaQuyTrinh(macongty, madonvi, maloaiphieu, int.Parse(buoduyet), ABPS);
                foreach (QPDNFlow qt in lsQuytrinh)
                {
                    QPDNFlow quytrinh = new QPDNFlow();
                    quytrinh.GSBH = qt.GSBH;
                    quytrinh.BADEPID = qt.BADEPID;
                    quytrinh.abtype = qt.abtype;
                    quytrinh.ABstep = qt.ABstep - 1;
                    quytrinh.ABPS = qt.ABPS;
                   // QPDNFlowDAO.CapNhatQuyTrinh(quytrinh);
                    dal.CapNhatAbStep(qt.GSBH, qt.abtype, qt.BADEPID, qt.IDQuyTrinh, qt.ABstep - 1, qt.ABPS);
                   // db.ExecuteCommand("update QPDNFlow set ABstep='" + quytrinh.ABstep + "' where GSBH='" + qt.GSBH + "' and abtype='" + qt.abtype + "' and BADEPID='" + qt.BADEPID + "' and IDQuyTrinh='" + qt.IDQuyTrinh + "' and ABPS='" + qt.ABPS + "'");
                }
            }
            else
            {
                if (max > 1)
                {
                    //QPDNFlowDAO.XoaQuyTrinh(macongty, maloaiphieu, int.Parse(buoduyet), madonvi, ABPS);
                   
                    List<QPDNFlow> dsqtr = QPDNFlowDAO.DanhSachQuytrinhHonBuocTruoc(macongty, madonvi, maloaiphieu, int.Parse(buoduyet), ABPS);
                    if (dsqtr.Count > 0)
                    {
                        dal.XoaQuyTrinh(macongty, madonvi, maloaiphieu, int.Parse(buoduyet), ABPS);
                        foreach (QPDNFlow qt in dsqtr)
                        {
                            if (qt.ABPS == max)
                            {
                                int abps = int.Parse(qt.ABPS.ToString()) - 1;
                                dal.CapNhatQuyABPS(qt.GSBH, maloaiphieu, madonvi, qt.IDQuyTrinh, qt.ABstep, abps);
                            }

                        }
                    }
                    else
                    {
                        dal.XoaQuyTrinh(macongty, madonvi, maloaiphieu, int.Parse(buoduyet), ABPS);
                    }

                }
            }

            List<Abcon> dsPhieuChuaDuyet = AbconDAO.TimPhieuChuaDuyetTheoBuocDuyetCapDuyet(macongty,madonvi,maloaiphieu,manguoiduyet,int.Parse(buoduyet));
            foreach (Abcon phieu in dsPhieuChuaDuyet)
            {
               List<Abcon> abpsMax = AbconDAO.TimABPSMaxTrongBangABcon(macongty, madonvi, maloaiphieu, phieu.pdno, int.Parse(buoduyet));
               int MaxABPS = (from p in abpsMax select p.abps).Max();
                if (MaxABPS == 1)
                {
                    
                    List<Abcon> dsphieu = AbconDAO.LayBuocHonBuocHienTaiTrongBangABcon(macongty, madonvi, maloaiphieu, phieu.pdno, int.Parse(buoduyet));
                    AbconDAO.XoaAbconNew(macongty, maloaiphieu, phieu.pdno, int.Parse(buoduyet), ABPS);
                    foreach (Abcon p in dsphieu)
                    {
                        Abcon abcon = new Abcon();
                        abcon.Gsbh = p.Gsbh;
                        abcon.from_depart = p.from_depart;
                        abcon.abtype = p.abtype;
                        abcon.pdno = p.pdno;
                        abcon.Abstep = p.Abstep - 1;
                        abcon.abps = p.abps;
                        abcon.IDCT = p.IDCT;
                        AbconDAO.CapNhatAbconNew(abcon);
                    }
                }
                else
                {
                    if (MaxABPS > 1)
                    {
                       
                        List<Abcon> dsPhieu = AbconDAO.QryCapTrongCung1Buoc(macongty, madonvi, maloaiphieu, phieu.pdno, int.Parse(buoduyet), ABPS);
                        AbconDAO.XoaAbconNew(macongty, maloaiphieu, phieu.pdno, int.Parse(buoduyet), ABPS);
                        foreach (Abcon p in dsPhieu)
                        {
                            Abcon abcon = new Abcon();
                            abcon.Gsbh = p.Gsbh;
                            abcon.from_depart = p.from_depart;
                            abcon.abtype = p.abtype;
                            abcon.pdno = p.pdno;
                            abcon.Abstep = p.Abstep;
                            abcon.abps = p.abps-1;
                            abcon.IDCT = p.IDCT;
                            AbconDAO.CapNhatAbconNew(abcon);
                        }
                       
                    }
                }
            }

                HienThiDanhSach();
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            quytrinhDal dal=new quytrinhDal();
            string macongty = Session["congty"].ToString();
            string maloaiphieu = DropDownLoaiPhieu.SelectedValue.ToString();
            if (DropDownLoaiPhieu.SelectedValue.ToString() == " ")
            {
                if (DropDownLDonVi.SelectedValue.ToString() == "All")
                {
                    GridView1.DataSource = dal.QryQPDNFlow(macongty);
                    GridView1.DataBind();
                }
                else
                {
                    if (DropDownLDonVi.SelectedValue.ToString().Trim() != "All")
                    {
                        string madonvi = DropDownLDonVi.SelectedValue.ToString();
                        // GridView1.DataSource = QPDNFlowDAO.QryQuyTrinhTheoBoPhan(madonvi, macongty);
                        GridView1.DataSource = dal.QryTheoDieuKien(macongty, madonvi);
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                if (DropDownLDonVi.SelectedValue.ToString() == "All")
                {
                    GridView1.DataSource = dal.QryTheoLoaiPhieu(macongty, maloaiphieu);
                    GridView1.DataBind();
                }
                else
                {
                    string madonvi = DropDownLDonVi.SelectedValue.ToString();
                    GridView1.DataSource = dal.QryTheoLoaiPhieuDonVi(macongty, maloaiphieu, madonvi);
                    GridView1.DataBind();
                }
            }
            
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
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